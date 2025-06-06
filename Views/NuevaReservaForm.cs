﻿#nullable disable
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
        // — Flujos de datos que recibe el formulario —
        public bool IsEditMode { get; set; } = false;
        public int EditingReservaId { get; set; } = -1;

        /// <summary>
        /// Ahora recibimos directamente el ID de la cabina seleccionada.
        /// </summary>
        public int SelectedCabinaId { get; set; } = 0;

        public DateTime SelectedInicio { get; set; }
        public DateTime SelectedFin { get; set; }

        /// <summary>
        /// Propiedad auxiliar para exponer el contenido de txtDni
        /// (en modo edición, MainForm la asigna con el DNI original).
        /// </summary>
        public string Dni
        {
            get => txtDni.Text;
            set => txtDni.Text = value;
        }

        // Vista‐modelo inyectado
        private readonly ReservaViewModel _vm;

        // Aquí guardaremos el usuario que el operador elige en tiempo de ejecución
        private Usuario _usuarioSeleccionado;

        public NuevaReservaForm(ReservaViewModel vm)
        {
            InitializeComponent();
            _vm = vm;

            // 1) Al cargar el formulario, inicializamos los DateTimePickers
            //    y, si venimos en modo edición, intentamos precargar el usuario
            this.Load += async (_, __) =>
            {
                dtpInicio.Value = SelectedInicio;
                dtpFin.Value = SelectedFin;

                if (IsEditMode && !string.IsNullOrWhiteSpace(Dni))
                {
                    // Precargamos al usuario basándonos en el DNI que vino de MainForm
                    var candidatos = await _vm.BuscarUsuariosAsync(Dni.Trim());
                    var u = candidatos.FirstOrDefault();
                    if (u != null)
                    {
                        _usuarioSeleccionado = u;
                        txtDni.Text = $"{u.Apellidos}, {u.Nombre}";
                    }
                }
            };

            // 2) Cuando el usuario pulsa ENTER dentro de txtDni, disparamos la búsqueda
            txtDni.KeyDown += async (_, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true; // evita el 'ding' de Windows

                    await EjecutarBusquedaUsuarioAsync();
                }
            };

            // 3) Evento del botón “Buscar” (txtDni se usa como filtro)
            btnBuscarUsuario.Click += async (_, __) =>
            {
                await EjecutarBusquedaUsuarioAsync();
            };

            // 4) Botón “Aceptar”: crear o actualizar la reserva
            btnAceptar.Click += async (_, __) =>
            {
                // 4.1) Validar que haya un usuario seleccionado
                if (_usuarioSeleccionado == null)
                {
                    MessageBox.Show("Debes buscar y seleccionar primero un usuario válido.",
                                    "Usuario no seleccionado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // 4.2) Validar rangos de fecha/hora
                if (dtpInicio.Value >= dtpFin.Value)
                {
                    MessageBox.Show("La fecha/hora de inicio debe ser anterior a la de fin.",
                                    "Fechas Inválidas",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // 4.3) Validar que SelectedCabinaId sea distinto de cero
                if (SelectedCabinaId == 0)
                {
                    MessageBox.Show("No se pudo determinar la cabina seleccionada.",
                                    "Error Interno",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                // 4.4) Crear o actualizar la entidad Reserva
                bool ok;
                if (IsEditMode)
                {
                    // MODO EDICIÓN: incluimos el Id para que EF Core sepa qué registro modificar
                    var reservaEditar = new Reserva
                    {
                        Id = EditingReservaId,
                        CabinaId = SelectedCabinaId,
                        UsuarioId = _usuarioSeleccionado.Id,
                        Inicio = dtpInicio.Value,
                        Fin = dtpFin.Value
                    };
                    ok = await _vm.UpdateReservaAsync(reservaEditar);
                }
                else
                {
                    // MODO CREACIÓN: NO asignamos Id → dejamos que SQL Server genere la identidad
                    var reservaNueva = new Reserva
                    {
                        CabinaId = SelectedCabinaId,
                        UsuarioId = _usuarioSeleccionado.Id,
                        Inicio = dtpInicio.Value,
                        Fin = dtpFin.Value
                    };
                    ok = await _vm.CreateReservaAsync(reservaNueva);
                }

                if (!ok)
                {
                    MessageBox.Show("Ya existe otra reserva en ese rango de tiempo.",
                                    "Conflicto de Horario",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                // 4.5) Todo salió bien: devolvemos OK y cerramos
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            // 5) Botón “Cancelar”: simplemente cierra
            btnCancelar.Click += (_, __) => this.Close();
        }

        /// <summary>
        /// Lógica común para buscar usuarios según el texto actual de txtDni,
        /// seleccionar al primero que coincida y mostrar su nombre formateado.
        /// </summary>
        private async Task EjecutarBusquedaUsuarioAsync()
        {
            string filtro = txtDni.Text?.Trim();
            if (string.IsNullOrWhiteSpace(filtro))
            {
                MessageBox.Show("Escribe un DNI o nombre/apellidos para buscar.",
                                "Filtro vacío",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Llamamos al ViewModel para buscar usuarios activos que coincidan
            var listaUsuarios = await _vm.BuscarUsuariosAsync(filtro);

            if (listaUsuarios == null || listaUsuarios.Count == 0)
            {
                MessageBox.Show("No se encontró ningún usuario con ese filtro.",
                                "Sin resultados",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                _usuarioSeleccionado = null;
                return;
            }

            // Si hay más de uno, mostramos un cuadro para que elija cuál
            if (listaUsuarios.Count > 1)
            {
                // Construimos un string con “Índice - Apellidos Nombre (DNI)” para cada opción
                string opciones = "";
                for (int i = 0; i < listaUsuarios.Count; i++)
                {
                    var us = listaUsuarios[i];
                    opciones += $"{i + 1}. {us.Apellidos} {us.Nombre} ({us.Dni})\n";
                }

                opciones += "\nEscribe el número de la opción que corresponda en el cuadro de texto.";

                string entrada = Microsoft.VisualBasic.Interaction.InputBox(
                    opciones,
                    "Múltiples usuarios encontrados",
                    "1");

                if (!int.TryParse(entrada, out int seleccion) ||
                    seleccion < 1 ||
                    seleccion > listaUsuarios.Count)
                {
                    MessageBox.Show("Selección inválida. Debes escribir un número válido.",
                                    "Selección Errónea",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    _usuarioSeleccionado = null;
                    return;
                }

                _usuarioSeleccionado = listaUsuarios[seleccion - 1];
            }
            else
            {
                // Si solo hay uno, lo seleccionamos directamente
                _usuarioSeleccionado = listaUsuarios[0];
            }

            // Finalmente, mostramos en txtDni su APELLIDO1 APELLIDO2, NOMBRE
            txtDni.Text = $"{_usuarioSeleccionado.Apellidos}, {_usuarioSeleccionado.Nombre}";
            MessageBox.Show(
                $"Usuario seleccionado:\n{_usuarioSeleccionado.Apellidos}, {_usuarioSeleccionado.Nombre} ({_usuarioSeleccionado.Dni})",
                "Usuario Encontrado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
