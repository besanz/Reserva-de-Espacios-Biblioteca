using System;
using System.Windows.Forms;
using Reserva_de_Espacios_Biblioteca.Models;

namespace Reserva_de_Espacios_Biblioteca.Views
{
    public partial class ReservaForm : Form
    {
        private CabinType _cabinType;
        private DateTime _start;
        private TimeSpan _duration;

        public ReservaForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Llama desde MainForm antes de ShowDialog.
        /// </summary>
        public void Initialize(CabinType cabinType, DateTime start, TimeSpan duration)
        {
            _cabinType = cabinType;
            _start = start;
            _duration = duration;

            lblTipoCabina.Text = $"Cabina: {cabinType}";
            dtpFecha.Value = start.Date;
            dtpHoraInicio.Value = start;
            dtpHoraFin.Value = start.Add(duration);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Por ahora sólo muestro un mensaje para que veas que funciona.
            MessageBox.Show(
                $"Reservado {_cabinType} de {_start:HH:mm} a {_start.Add(_duration):HH:mm}" +
                $"\nDuración: {_duration.TotalHours:N1}h",
                "Reserva",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // En el futuro aquí llamarás a tu ViewModel:
            // await _vm.CreateReservaAsync( new Reserva { ... } );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
