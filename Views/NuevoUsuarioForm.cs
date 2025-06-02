using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reserva_de_Espacios_Biblioteca.Data.Entities;
using Reserva_de_Espacios_Biblioteca.ViewModels;

namespace Reserva_de_Espacios_Biblioteca.Views
{
    public partial class NuevoUsuarioForm : Form
    {
        // — flujo — 
        // Cuando MainForm invoque ShowDialog, puede leer estas propiedades:
        public Usuario CreatedUsuario { get; private set; } = null!; // Rellenado al guardar

        private readonly ReservaViewModel _vm;

        public NuevoUsuarioForm(ReservaViewModel vm)
        {
            InitializeComponent();
            _vm = vm;

            // Al pulsar Guardar o Cancelar:
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (_, __) => this.Close();
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            // 1) Validación de campos obligatorios
            string dni = txtDni.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            bool estaActivo = chkActivo.Checked;

            if (string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show("El campo DNI es obligatorio.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El campo Nombre es obligatorio.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(apellidos))
            {
                MessageBox.Show("El campo Apellidos es obligatorio.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("El campo Email no tiene un formato válido.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2) Construyo la entidad Usuario:
            var nuevo = new Usuario
            {
                Dni = dni,
                Nombre = nombre,
                Apellidos = apellidos,
                Email = email,
                Telefono = telefono,
                EstaActivo = estaActivo,
                FechaRegistro = DateTime.Now
            };

            // 3) Llamo a la VM para insertarlo en BD.
            //    Asumimos que ReservaViewModel tiene un método CreateUsuarioAsync:
            bool ok = await _vm.CreateUsuarioAsync(nuevo);
            if (!ok)
            {
                MessageBox.Show("Ya existe un usuario con ese DNI.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4) Si se guardó correctamente, asigno la propiedad CreatedUsuario
            CreatedUsuario = nuevo;

            // 5) Devuelvo DialogResult.OK para que MainForm sepa que se creó:
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Chequea sintaxis básica de correo (solo patrón muy simple para ilustrar).
        /// </summary>
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Patrón muy sencillo: algo@algo.algo
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);
        }
    }
}
