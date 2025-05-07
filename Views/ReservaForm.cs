using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Reserva_de_Espacios_Biblioteca.ViewModels;

namespace Reserva_de_Espacios_Biblioteca.Views
{
    public partial class ReservaForm : Form
    {
        private readonly ReservaViewModel _vm;
        private readonly IServiceProvider _sp;

        public ReservaForm(ReservaViewModel vm, IServiceProvider sp)
        {
            InitializeComponent();
            _vm = vm;
            _sp = sp;

            // Cuando cambias la fecha, recarga el calendario
            dtpFecha.ValueChanged += async (_, __) => await CargarHorarioAsync();

            // Al pulsar "Nueva reserva", pedimos un ViewModel nuevo y abrimos el diálogo
            btnNuevaReserva.Click += async (_, __) =>
            {
                var vmNuevo = _sp.GetRequiredService<ReservaViewModel>();
                using var dlg = new NuevaReservaForm(vmNuevo);
                if (dlg.ShowDialog() == DialogResult.OK)
                    await CargarHorarioAsync();
            };

            // Carga inicial del calendario
            Load += async (_, __) => await CargarHorarioAsync();
        }

        private async Task CargarHorarioAsync()
        {
            var table = await _vm.GetScheduleTableAsync(dtpFecha.Value);
            dgvHorario.DataSource = table;
        }
    }
}
