#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reserva_de_Espacios_Biblioteca.Data.Entities;
using Reserva_de_Espacios_Biblioteca.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Reserva_de_Espacios_Biblioteca.Views
{
    public partial class MenuReservasForm : Form
    {
        private readonly ReservaViewModel _vm;
        private readonly IServiceProvider _sp;

        /// <summary>
        /// Clase interna para mostrar las reservas en el DataGridView
        /// </summary>
        private class ReservationDisplay
        {
            public int Id { get; set; }
            public string Cabina { get; set; }
            public string Usuario { get; set; }
            public string Dni { get; set; }
            public DateTime Inicio { get; set; }
            public DateTime Fin { get; set; }
        }

        private List<ReservationDisplay> _listaReservasDia = new();

        public MenuReservasForm(ReservaViewModel vm, IServiceProvider sp)
        {
            InitializeComponent();
            _vm = vm;
            _sp = sp;

            // 1) Al cambiar la fecha, recargamos las reservas de ese día:
            dtpFecha.ValueChanged += async (s, e) =>
            {
                await LoadReservationsForDateAsync(dtpFecha.Value.Date);
            };

            // 2) Al hacer clic en “Nueva Reserva”:
            btnNuevaReserva.Click += BtnNuevaReserva_Click;

            // 3) Cuando se selecciona una fila en el grid:
            dgvReservas.SelectionChanged += DgvReservas_SelectionChanged;

            // 4) Cuando se pide guardar cambios en detalle:
            btnGuardarCambios.Click += BtnGuardarCambios_Click;

            // 5) Cuando se pide eliminar reserva:
            btnEliminarReserva.Click += BtnEliminarReserva_Click;
        }

        /// <summary>
        /// Al mostrarse el formulario, cargamos datos en memoria y luego la lista de reservas para hoy.
        /// </summary>
        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // 1) Aseguramos que Cabinas y Reservas se carguen en memoria
            await _vm.CargarDatosAsync();

            // 2) Cargamos las reservas del día actual
            await LoadReservationsForDateAsync(dtpFecha.Value.Date);
        }

        /// <summary>
        /// Carga todas las reservas para el 'date' indicado, las convierte a ReservationDisplay
        /// y las enlaza al DataGridView.
        /// </summary>
        private async Task LoadReservationsForDateAsync(DateTime date)
        {
            // 1) Filtrar _vm.Reservas por fecha exacta
            var reservasDelDia = _vm.Reservas
                .Where(r => r.Inicio.Date == date.Date)
                .OrderBy(r => r.Inicio)
                .ToList();

            // 2) Construir lista de ReservationDisplay
            var lista = new List<ReservationDisplay>();
            foreach (var r in reservasDelDia)
            {
                var cabinaObj = _vm.Cabinas.FirstOrDefault(c => c.Id == r.CabinaId);
                string nombreCabina = cabinaObj?.Nombre ?? $"(ID {r.CabinaId})";

                var usuarioObj = await _vm.GetUsuarioByIdAsync(r.UsuarioId);
                string nombreUsuario = usuarioObj != null
                    ? $"{usuarioObj.Apellidos}, {usuarioObj.Nombre}"
                    : $"(ID {r.UsuarioId})";
                string dniUsuario = usuarioObj?.Dni ?? string.Empty;

                lista.Add(new ReservationDisplay
                {
                    Id = r.Id,
                    Cabina = nombreCabina,
                    Usuario = nombreUsuario,
                    Dni = dniUsuario,
                    Inicio = r.Inicio,
                    Fin = r.Fin
                });
            }

            _listaReservasDia = lista;

            // 3) Asignar lista al DataGridView
            dgvReservas.DataSource = _listaReservasDia;

            // 4) Configurar las columnas solo la primera vez
            if (dgvReservas.Columns.Count > 0 && dgvReservas.Columns[0].HeaderText != "ID")
            {
                dgvReservas.Columns.Clear();

                // Columna: Id (oculta)
                var colId = new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    HeaderText = "ID",
                    DataPropertyName = "Id",
                    Visible = false
                };
                dgvReservas.Columns.Add(colId);

                // Columna: Cabina
                var colCabina = new DataGridViewTextBoxColumn
                {
                    Name = "colCabina",
                    HeaderText = "Cabina",
                    DataPropertyName = "Cabina",
                    Width = 120
                };
                dgvReservas.Columns.Add(colCabina);

                // Columna: Usuario
                var colUsuario = new DataGridViewTextBoxColumn
                {
                    Name = "colUsuario",
                    HeaderText = "Usuario",
                    DataPropertyName = "Usuario",
                    Width = 180
                };
                dgvReservas.Columns.Add(colUsuario);

                // Columna: DNI
                var colDni = new DataGridViewTextBoxColumn
                {
                    Name = "colDni",
                    HeaderText = "DNI",
                    DataPropertyName = "Dni",
                    Width = 80
                };
                dgvReservas.Columns.Add(colDni);

                // Columna: Inicio
                var colInicio = new DataGridViewTextBoxColumn
                {
                    Name = "colInicio",
                    HeaderText = "Hora Inicio",
                    DataPropertyName = "Inicio",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
                };
                dgvReservas.Columns.Add(colInicio);

                // Columna: Fin
                var colFin = new DataGridViewTextBoxColumn
                {
                    Name = "colFin",
                    HeaderText = "Hora Fin",
                    DataPropertyName = "Fin",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
                };
                dgvReservas.Columns.Add(colFin);
            }

            // 5) Limpiar panel de detalle
            ClearDetailPanel();
        }

        /// <summary>
        /// Se ejecuta al cambiar la fila seleccionada en el DataGridView:
        /// muestra los datos en el panel de detalle.
        /// </summary>
        private void DgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                ClearDetailPanel();
                return;
            }

            var fila = dgvReservas.SelectedRows[0].DataBoundItem as ReservationDisplay;
            if (fila == null)
            {
                ClearDetailPanel();
                return;
            }

            txtCabinaDetalle.Text = fila.Cabina;
            txtUsuarioDetalle.Text = fila.Usuario;
            txtDniDetalle.Text = fila.Dni;
            dtpInicioDetalle.Value = fila.Inicio;
            dtpFinDetalle.Value = fila.Fin;

            btnGuardarCambios.Enabled = true;
            btnEliminarReserva.Enabled = true;
        }

        /// <summary>
        /// Limpia todos los campos del panel de detalle y deshabilita botones.
        /// </summary>
        private void ClearDetailPanel()
        {
            txtCabinaDetalle.Text = "";
            txtUsuarioDetalle.Text = "";
            txtDniDetalle.Text = "";
            dtpInicioDetalle.Value = DateTime.Today;
            dtpFinDetalle.Value = DateTime.Today.AddMinutes(15);
            btnGuardarCambios.Enabled = false;
            btnEliminarReserva.Enabled = false;
        }

        /// <summary>
        /// “Nueva Reserva”: abre NuevaReservaForm con cabina por defecto y hora 08:00–08:15 del día seleccionado.
        /// </summary>
        private async void BtnNuevaReserva_Click(object sender, EventArgs e)
        {
            // Verificar que haya al menos una cabina en memoria
            if (_vm.Cabinas == null || !_vm.Cabinas.Any())
            {
                MessageBox.Show("No hay cabinas definidas en el sistema.", "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tomamos la primera cabina como valor por defecto
            int primeraCabinaId = _vm.Cabinas.First().Id;
            DateTime inicioPorDefecto = dtpFecha.Value.Date.AddHours(8);
            DateTime finPorDefecto = inicioPorDefecto.AddMinutes(15);

            // Resolver NuevaReservaForm desde el contenedor
            var formNuevo = (NuevaReservaForm)_sp.GetService(typeof(NuevaReservaForm));
            if (formNuevo == null)
            {
                MessageBox.Show("No se pudo instanciar el formulario de Nueva Reserva.", "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            formNuevo.SelectedCabinaId = primeraCabinaId;
            formNuevo.SelectedInicio = inicioPorDefecto;
            formNuevo.SelectedFin = finPorDefecto;
            formNuevo.IsEditMode = false;

            var res = formNuevo.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                // Recargar reservas para la fecha actual
                await LoadReservationsForDateAsync(dtpFecha.Value.Date);
            }
        }

        /// <summary>
        /// “Guardar Cambios” / “Editar Reserva”: valida conflictos y luego llama a UpdateReservaAsync.
        /// </summary>
        private async void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0) return;

            var fila = dgvReservas.SelectedRows[0].DataBoundItem as ReservationDisplay;
            if (fila == null) return;

            DateTime nuevoInicio = dtpInicioDetalle.Value;
            DateTime nuevoFin = dtpFinDetalle.Value;

            if (nuevoInicio >= nuevoFin)
            {
                MessageBox.Show("La hora de inicio debe ser anterior a la hora de fin.", "Fechas Inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar la reserva original en memoria
            var reservaOriginal = _vm.Reservas.FirstOrDefault(r => r.Id == fila.Id);
            if (reservaOriginal == null)
            {
                MessageBox.Show("No se encontró la reserva en memoria.", "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Construir reserva con los datos modificados
            var reservaModificada = new Reserva
            {
                Id = reservaOriginal.Id,
                CabinaId = reservaOriginal.CabinaId,
                UsuarioId = reservaOriginal.UsuarioId,
                Inicio = nuevoInicio,
                Fin = nuevoFin
            };

            bool ok = await _vm.UpdateReservaAsync(reservaModificada);
            if (!ok)
            {
                MessageBox.Show("Existe un conflicto de horario con otra reserva.", "Conflicto de Horario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Recargar grilla
            await LoadReservationsForDateAsync(dtpFecha.Value.Date);
            MessageBox.Show("Reserva actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// “Eliminar Reserva”: confirma y luego invoca DeleteReservaAsync.
        /// </summary>
        private async void BtnEliminarReserva_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0) return;

            var fila = dgvReservas.SelectedRows[0].DataBoundItem as ReservationDisplay;
            if (fila == null) return;

            var respuesta = MessageBox.Show(
                $"¿Seguro que deseas eliminar la reserva para “{fila.Cabina}” de “{fila.Usuario}” ({fila.Inicio:HH:mm}–{fila.Fin:HH:mm})?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            bool ok = await _vm.DeleteReservaAsync(fila.Id);
            if (!ok)
            {
                MessageBox.Show("No se pudo eliminar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Recargar grilla
            await LoadReservationsForDateAsync(dtpFecha.Value.Date);
            MessageBox.Show("Reserva eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
