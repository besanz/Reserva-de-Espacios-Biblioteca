using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reserva_de_Espacios_Biblioteca.Data.Entities;
using Reserva_de_Espacios_Biblioteca.ViewModels;

namespace Reserva_de_Espacios_Biblioteca.Views
{
    public partial class MenuUsuariosForm : Form
    {
        private readonly ReservaViewModel _vm;
        private Usuario? _usuarioActual;    // Usuario seleccionado o null
        private bool _isEditing = false;    // Indica si estamos en modo edición

        public MenuUsuariosForm(ReservaViewModel vm)
        {
            InitializeComponent();
            _vm = vm;

            // 1) Asociar eventos
            btnBuscar.Click += async (object? _, EventArgs __) => await CargarUsuariosAsync();
            dgvUsuarios.SelectionChanged += DgvUsuarios_SelectionChanged;

            btnNuevo.Click += BtnNuevo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            btnToggleActivo.Click += BtnToggleActivo_Click;

            // 2) Configurar DataGridView manualmente
            dgvUsuarios.AutoGenerateColumns = false;
            SetupGridColumns();

            // 3) Deshabilitar campos por defecto
            HabilitarCampos(false);
        }

        /// <summary>
        /// Configura las columnas fijas de la grilla de usuarios.
        /// </summary>
        private void SetupGridColumns()
        {
            dgvUsuarios.Columns.Clear();

            // Columna Id (oculta)
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Visible = false
            };
            dgvUsuarios.Columns.Add(colId);

            // Columna DNI
            var colDni = new DataGridViewTextBoxColumn
            {
                Name = "colDni",
                HeaderText = "DNI",
                DataPropertyName = "Dni",
                Width = 80
            };
            dgvUsuarios.Columns.Add(colDni);

            // Columna Apellidos
            var colApellidos = new DataGridViewTextBoxColumn
            {
                Name = "colApellidos",
                HeaderText = "Apellidos",
                DataPropertyName = "Apellidos",
                Width = 120
            };
            dgvUsuarios.Columns.Add(colApellidos);

            // Columna Nombre
            var colNombre = new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Width = 100
            };
            dgvUsuarios.Columns.Add(colNombre);

            // Columna Email
            var colEmail = new DataGridViewTextBoxColumn
            {
                Name = "colEmail",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 150
            };
            dgvUsuarios.Columns.Add(colEmail);

            // Columna Teléfono
            var colTelefono = new DataGridViewTextBoxColumn
            {
                Name = "colTelefono",
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono",
                Width = 80
            };
            dgvUsuarios.Columns.Add(colTelefono);

            // Columna EstaActivo
            var colActivo = new DataGridViewCheckBoxColumn
            {
                Name = "colActivo",
                HeaderText = "Activo",
                DataPropertyName = "EstaActivo",
                Width = 60
            };
            dgvUsuarios.Columns.Add(colActivo);
        }

        /// <summary>
        /// Carga (o recarga) la grilla de usuarios invocando BuscarUsuariosAsync.
        /// </summary>
        private async Task CargarUsuariosAsync()
        {
            string filtro = txtBuscar.Text?.Trim() ?? "";
            var lista = await _vm.BuscarUsuariosAsync(filtro);

            // Enlazamos la lista a la grilla (convertimos a List para que refresque bien)
            dgvUsuarios.DataSource = lista.ToList();

            // Limpiar detalles y deshabilitar botones de edición
            _usuarioActual = null;
            LimpiarDetalles();
            HabilitarCampos(false);
            btnEditar.Enabled = false;
            btnToggleActivo.Enabled = false;
        }

        /// <summary>
        /// Cuando cambia la selección en la grilla, mostramos sus detalles en el panel derecho.
        /// </summary>
        private void DgvUsuarios_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                _usuarioActual = null;
                LimpiarDetalles();
                btnEditar.Enabled = false;
                btnToggleActivo.Enabled = false;
                return;
            }

            var row = dgvUsuarios.SelectedRows[0];
            _usuarioActual = row.DataBoundItem as Usuario;
            if (_usuarioActual != null)
            {
                txtDni.Text = _usuarioActual.Dni;
                txtApellidos.Text = _usuarioActual.Apellidos;
                txtNombre.Text = _usuarioActual.Nombre;
                txtEmail.Text = _usuarioActual.Email;
                txtTelefono.Text = _usuarioActual.Telefono;
                chkEstaActivo.Checked = _usuarioActual.EstaActivo;

                btnEditar.Enabled = true;
                btnToggleActivo.Enabled = true;
                btnToggleActivo.Text = _usuarioActual.EstaActivo ? "Desactivar" : "Activar";
            }
        }

        /// <summary>
        /// Limpia todos los campos de detalle (panel derecho).
        /// </summary>
        private void LimpiarDetalles()
        {
            txtDni.Text = "";
            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            chkEstaActivo.Checked = false;
        }

        /// <summary>
        /// Habilita o deshabilita todos los controles del detalle según el parámetro 'editable'.
        /// </summary>
        private void HabilitarCampos(bool editable)
        {
            txtDni.ReadOnly = !editable;
            txtApellidos.ReadOnly = !editable;
            txtNombre.ReadOnly = !editable;
            txtEmail.ReadOnly = !editable;
            txtTelefono.ReadOnly = !editable;
            chkEstaActivo.Enabled = editable;

            btnGuardar.Enabled = editable;
            btnCancelar.Enabled = editable;

            // Mientras se edita o crea, bloqueamos Nuevo/Editar/Buscar
            btnNuevo.Enabled = !editable;
            btnEditar.Enabled = !editable && _usuarioActual != null;
            btnBuscar.Enabled = !editable;
            txtBuscar.Enabled = !editable;
            dgvUsuarios.Enabled = !editable;
            btnToggleActivo.Enabled = !editable && _usuarioActual != null;
        }

        /// <summary>
        /// “Nuevo”: limpia campos y entra en modo creación.
        /// </summary>
        private void BtnNuevo_Click(object? sender, EventArgs e)
        {
            _usuarioActual = null;
            LimpiarDetalles();
            _isEditing = false;
            HabilitarCampos(true);
        }

        /// <summary>
        /// “Editar”: habilita edición para el usuario seleccionado.
        /// </summary>
        private void BtnEditar_Click(object? sender, EventArgs e)
        {
            if (_usuarioActual == null) return;
            _isEditing = true;
            HabilitarCampos(true);
        }

        /// <summary>
        /// “Guardar”: crea o actualiza un usuario según _isEditing.
        /// </summary>
        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            // Validaciones mínimas
            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("DNI, Apellidos y Nombre son obligatorios.",
                                "Datos incompletos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (_isEditing && _usuarioActual != null)
            {
                // Actualizar existente
                _usuarioActual.Dni = txtDni.Text.Trim();
                _usuarioActual.Apellidos = txtApellidos.Text.Trim();
                _usuarioActual.Nombre = txtNombre.Text.Trim();
                _usuarioActual.Email = txtEmail.Text.Trim();
                _usuarioActual.Telefono = txtTelefono.Text.Trim();
                _usuarioActual.EstaActivo = chkEstaActivo.Checked;

                bool fueOk = await _vm.UpdateUsuarioAsync(_usuarioActual);
                if (!fueOk)
                {
                    MessageBox.Show("Error al actualizar usuario (quizá DNI duplicado).",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // Crear nuevo
                var nuevo = new Usuario
                {
                    Dni = txtDni.Text.Trim(),
                    Apellidos = txtApellidos.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    EstaActivo = chkEstaActivo.Checked
                };

                bool fueOk = await _vm.CreateUsuarioAsync(nuevo);
                if (!fueOk)
                {
                    MessageBox.Show("Error al crear usuario (quizá DNI ya existe).",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
            }

            _isEditing = false;
            await CargarUsuariosAsync();
            HabilitarCampos(false);
        }

        /// <summary>
        /// “Cancelar” durante la edición: revierte cambios y recarga detalles.
        /// </summary>
        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            _isEditing = false;
            HabilitarCampos(false);

            if (_usuarioActual != null)
                DgvUsuarios_SelectionChanged(null, null);
            else
                LimpiarDetalles();
        }

        /// <summary>
        /// “Desactivar” / “Activar” al usuario seleccionado.
        /// </summary>
        private async void BtnToggleActivo_Click(object? sender, EventArgs e)
        {
            if (_usuarioActual == null) return;

            bool nuevoEstado = !_usuarioActual.EstaActivo;
            bool fueOk = await _vm.ToggleActivoUsuarioAsync(_usuarioActual.Id, nuevoEstado);
            if (!fueOk)
            {
                MessageBox.Show("No se pudo cambiar el estado del usuario.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Refrescar estado en memoria y en pantalla
            _usuarioActual.EstaActivo = nuevoEstado;
            chkEstaActivo.Checked = nuevoEstado;
            btnToggleActivo.Text = nuevoEstado ? "Desactivar" : "Activar";

            dgvUsuarios.Refresh(); // Refresca solo la fila actual en la grilla
        }
    }
}
