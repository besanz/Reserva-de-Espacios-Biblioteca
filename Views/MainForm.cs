using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Reserva_de_Espacios_Biblioteca.ViewModels;

namespace Reserva_de_Espacios_Biblioteca.Views
{
    public partial class MainForm : Form
    {
        private readonly ReservaViewModel _vm;
        private readonly IServiceProvider _sp;

        private readonly TimeSpan WorkStart = TimeSpan.FromHours(8);
        private readonly TimeSpan WorkEnd = TimeSpan.FromHours(20);
        private const int PixelsPerHour = 60; // 60px = 1 hora

        public MainForm(ReservaViewModel vm, IServiceProvider sp)
        {
            InitializeComponent();

            _vm = vm;
            _sp = sp;

            // Cuando el usuario cambie de día en el MonthCalendar:
            mcFecha.DateChanged += async (_, __) => await RenderDayViewAsync();

            // Pintar la rejilla horaria
            pnlScheduler.Paint += PnlScheduler_Paint;

            // Al cargar la ventana, dibuja el día actual
            Load += async (_, __) => await RenderDayViewAsync();
        }

        // Dibuja las líneas horizontales y verticales de la rejilla
        private void PnlScheduler_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            int cols = _vm.Cabinas.Count;
            if (cols == 0) return;

            int columnWidth = pnlScheduler.ClientSize.Width / cols;
            int totalSlots = (int)((WorkEnd - WorkStart).TotalHours * 4);

            // Líneas horizontales (cada 15 minutos)
            for (int i = 0; i <= totalSlots; i++)
            {
                int y = (int)(i * (PixelsPerHour / 4.0));
                g.DrawLine(Pens.LightGray, 0, y, pnlScheduler.ClientSize.Width, y);
            }

            // Líneas verticales entre cabinas
            for (int i = 1; i < cols; i++)
            {
                int x = i * columnWidth;
                g.DrawLine(Pens.LightGray, x, 0, x, pnlScheduler.ClientSize.Height);
            }
        }

        // Carga las reservas y crea los paneles "flotantes"
        private async Task RenderDayViewAsync()
        {
            pnlScheduler.SuspendLayout();
            pnlScheduler.Controls.Clear();

            // Asegurar que las cabinas están cargadas
            if (!_vm.Cabinas.Any())
                await _vm.CargarDatosAsync();

            // Obtén reservas del día seleccionado
            var date = mcFecha.SelectionStart.Date;
            var reservas = _vm.Reservas.Where(r => r.Inicio.Date == date).ToList();
            if (!reservas.Any())
            {
                await _vm.CargarDatosAsync();
                reservas = _vm.Reservas.Where(r => r.Inicio.Date == date).ToList();
            }

            int cols = _vm.Cabinas.Count;
            int columnWidth = pnlScheduler.ClientSize.Width / cols;

            // Por cada reserva, crea un Panel con Label y ToolTip
            foreach (var r in reservas)
            {
                int colIndex = _vm.Cabinas.ToList().FindIndex(c => c.Id == r.CabinaId);
                if (colIndex < 0) continue;

                var from = r.Inicio.TimeOfDay - WorkStart;
                var to = r.Fin.TimeOfDay - WorkStart;
                int y = (int)(from.TotalHours * PixelsPerHour);
                int height = (int)((to - from).TotalHours * PixelsPerHour);

                var box = new Panel
                {
                    BackColor = Color.LightBlue,
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(colIndex * columnWidth, y),
                    Size = new Size(columnWidth - 2, height),
                };

                var lbl = new Label
                {
                    Dock = DockStyle.Fill,
                    Text = $"{r.SocioDni}\n{r.Inicio:HH:mm}-{r.Fin:HH:mm}",
                    TextAlign = ContentAlignment.TopLeft,
                    AutoSize = false
                };
                box.Controls.Add(lbl);

                toolTip1.SetToolTip(box,
                    $"Cabina: {_vm.Cabinas[colIndex].Nombre}\n" +
                    $"DNI: {r.SocioDni}\n" +
                    $"{r.Inicio:HH:mm} → {r.Fin:HH:mm}"
                );

                pnlScheduler.Controls.Add(box);
            }

            pnlScheduler.ResumeLayout();
            pnlScheduler.Invalidate();  // fuerza repaint de la rejilla
        }
    }
}
