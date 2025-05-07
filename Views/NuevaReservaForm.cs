using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reserva_de_Espacios_Biblioteca.Data.Entities;
using Reserva_de_Espacios_Biblioteca.ViewModels;

namespace Reserva_de_Espacios_Biblioteca.Views
{
    public partial class NuevaReservaForm : Form
    {
        private readonly ReservaViewModel _vm;
        public string SelectedCabinaName { get; set; }
        public DateTime SelectedInicio { get; set; }
        public DateTime SelectedFin { get; set; }

        public NuevaReservaForm(ReservaViewModel vm)
        {
            InitializeComponent();
            _vm = vm;

            Load += async (_, __) =>
            {
                await _vm.CargarDatosAsync();
                cbCabinas.DataSource = _vm.Cabinas;
                cbCabinas.DisplayMember = nameof(Cabina.Nombre);
                cbCabinas.ValueMember = nameof(Cabina.Id);

                // Si viene pre-seleccionada
                if (!string.IsNullOrEmpty(SelectedCabinaName))
                {
                    cbCabinas.SelectedIndex = _vm.Cabinas
                      .ToList().FindIndex(c => c.Nombre == SelectedCabinaName);
                }
                dtpInicio.Value = SelectedInicio;
                dtpFin.Value = SelectedFin;
            };

            btnAceptar.Click += async (_, __) =>
            {
                var r = new Reserva
                {
                    CabinaId = (int)cbCabinas.SelectedValue,
                    SocioDni = txtDni.Text,
                    Inicio = dtpInicio.Value,
                    Fin = dtpFin.Value
                };
                await _vm.CreateReservaAsync(r);
                DialogResult = DialogResult.OK;
                Close();
            };
        }
    }

}
