#nullable disable
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reserva_de_Espacios_Biblioteca.Data.Entities;   // Reserva, Cabina, Usuario
using Reserva_de_Espacios_Biblioteca.ViewModels;      // ReservaViewModel

namespace Reserva_de_Espacios_Biblioteca.Views
{
    public partial class MainForm : Form
    {
        private readonly ReservaViewModel _vm;
        private readonly IServiceProvider _sp;

        public MainForm(ReservaViewModel vm, IServiceProvider sp)
        {
            InitializeComponent();

            _vm = vm;
            _sp = sp;

            // ─── 1) Configuramos ambos DataGridView ───────────────────────────────
            ConfigureDataGrid(dgvIndividual);
            ConfigureDataGrid(dgvGrupal);

            // Inicialmente deshabilitamos los botones Editar/Eliminar
            btnEditarReserva.Enabled = false;
            btnEliminarReserva.Enabled = false;
            btnEditarReserva2.Enabled = false;
            btnEliminarReserva2.Enabled = false;

            // ─── 2) Eventos MouseUp en los grids para crear reserva si hay selección ─
            dgvIndividual.MouseUp += async (_, __) =>
            {
                if (Control.MouseButtons == MouseButtons.Left && dgvIndividual.SelectedRows.Count > 0)
                {
                    await OpenNewReservationFromGrid(dgvIndividual, "Cabina Individual");
                }
            };
            dgvGrupal.MouseUp += async (_, __) =>
            {
                if (Control.MouseButtons == MouseButtons.Left && dgvGrupal.SelectedRows.Count > 0)
                {
                    await OpenNewReservationFromGrid(dgvGrupal, "Cabina Grupal");
                }
            };

            // ─── 3) Doble‐clic en celdas para editar reserva ────────────────────────
            dgvIndividual.CellDoubleClick += DataGrid_CellDoubleClick;
            dgvGrupal.CellDoubleClick += DataGrid_CellDoubleClick;

            // ─── 4) Click derecho en celdas para crear reserva ──────────────────────
            dgvIndividual.CellMouseClick += Grid_CellMouseClick;
            dgvGrupal.CellMouseClick += Grid_CellMouseClick;

            // ─── 5) Botones debajo de “Cabina Individual” ──────────────────────────
            btnNuevaReserva.Click += async (_, __) =>
            {
                await OpenNewReservationWithDefaults("Cabina Individual");
            };
            btnEditarReserva.Click += async (_, __) =>
            {
                await EditSelectedReservation(dgvIndividual, "Cabina Individual");
            };
            btnEliminarReserva.Click += async (_, __) =>
            {
                await DeleteSelectedReservation(dgvIndividual, "Cabina Individual");
            };

            // ─── 6) Botones debajo de “Cabina Grupal” ──────────────────────────────
            btnNuevaReserva2.Click += async (_, __) =>
            {
                await OpenNewReservationWithDefaults("Cabina Grupal");
            };
            btnEditarReserva2.Click += async (_, __) =>
            {
                await EditSelectedReservation(dgvGrupal, "Cabina Grupal");
            };
            btnEliminarReserva2.Click += async (_, __) =>
            {
                await DeleteSelectedReservation(dgvGrupal, "Cabina Grupal");
            };

            // ─── 7) Cada vez que cambie la selección en un grid, actualizamos estado de botones ─
            dgvIndividual.SelectionChanged += (_, __) =>
            {
                UpdateButtonsState(dgvIndividual, btnEditarReserva, btnEliminarReserva);
            };
            dgvGrupal.SelectionChanged += (_, __) =>
            {
                UpdateButtonsState(dgvGrupal, btnEditarReserva2, btnEliminarReserva2);
            };

            // ─── 8) Al mostrarse el formulario, cargamos datos ─────────────────────
            this.Shown += async (_, __) =>
            {
                await LoadDataAsync();
            };
        }

        #region Configuración inicial de DataGridView y botones

        /// <summary>
        /// Configura el estilo y el comportamiento común de un DataGridView de cabinas.
        /// </summary>
        private void ConfigureDataGrid(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = true;

            // Pinta en gris las horas que ya pasaron
            dgv.CellFormatting += (s, e) =>
            {
                if (dgv.Columns[e.ColumnIndex].Name == "Hora"
                    && TimeSpan.TryParse(e.Value?.ToString(), out var ts)
                    && ts < DateTime.Now.TimeOfDay)
                {
                    e.CellStyle.ForeColor = Color.Gray;
                }
            };

            // Intercepta el CellPainting para dibujar “Apellidos, ” en normal y “Nombre” en negrita
            dgv.CellPainting += DataGrid_CellPainting;
        }

        /// <summary>
        /// Dibuja la parte “Apellido1 Apellido2, ” con fuente normal
        /// y la parte “Nombre” con fuente en negrita dentro de cada celda.
        /// </summary>
        private void DataGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var dgv = (DataGridView)sender;

            // Solo intervenimos en filas de contenido (no cabecera) y columnas distintas de "Hora"
            if (e.RowIndex < 0 || e.ColumnIndex == 0)
                return;

            var texto = e.FormattedValue?.ToString();
            if (string.IsNullOrEmpty(texto))
                return;

            // Separamos en dos partes usando la coma
            int comaIndex = texto.IndexOf(',');
            string parteApellidos, parteNombre;
            if (comaIndex > 0)
            {
                parteApellidos = texto.Substring(0, comaIndex + 1);          // incluye la coma
                parteNombre = texto.Substring(comaIndex + 1).TrimStart();    // lo que quede tras la coma
            }
            else
            {
                // Si no hay coma, pintamos todo en fuente normal
                parteApellidos = texto;
                parteNombre = string.Empty;
            }

            // Bloqueamos la pintura por defecto
            e.Handled = true;

            // Pintamos primero el fondo y bordes
            e.PaintBackground(e.ClipBounds, true);

            using (Font fuenteNormal = new Font(e.CellStyle.Font, FontStyle.Regular))
            using (Font fuenteNegrita = new Font(e.CellStyle.Font, FontStyle.Bold))
            {
                // Medimos el ancho de la parte "Apellidos," para posicionar el nombre
                SizeF tamañoApellidos = e.Graphics.MeasureString(parteApellidos, fuenteNormal);

                // Calculamos altura y ancho de inicio (con un pequeño margen a la izquierda)
                float posX = e.CellBounds.X + 2;
                float posY = e.CellBounds.Y + (e.CellBounds.Height - tamañoApellidos.Height) / 2;

                // Dibujamos "Apellidos," con fuente normal
                e.Graphics.DrawString(parteApellidos, fuenteNormal, Brushes.Black, posX, posY);

                // Dibujamos "Nombre" en negrita justo después
                if (!string.IsNullOrEmpty(parteNombre))
                {
                    e.Graphics.DrawString(
                        parteNombre,
                        fuenteNegrita,
                        Brushes.Black,
                        posX + tamañoApellidos.Width,
                        posY);
                }
            }

            // Finalmente dibujamos el borde de la celda para mantener cuadrícula y selección
            e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);
        }

        /// <summary>
        /// Habilita o deshabilita los botones Edit/Eliminar según haya filas seleccionadas.
        /// </summary>
        private void UpdateButtonsState(DataGridView dgv, Button btnEdit, Button btnDelete)
        {
            bool haySeleccion = dgv.SelectedRows.Count > 0;
            btnEdit.Enabled = haySeleccion;
            btnDelete.Enabled = haySeleccion;
        }

        #endregion

        #region Carga y refresco de datos en los DataGridView

        /// <summary>
        /// Carga las cabinas y reservas en memoria y luego construye la tabla de horario para "hoy".
        /// </summary>
        private async Task LoadDataAsync()
        {
            // 1) Cargo cabinas y reservas en memoria
            await _vm.CargarDatosAsync();

            // 2) Preparo la tabla de horario de hoy
            DataTable tablaFull = await _vm.GetScheduleTableAsync(DateTime.Today);

            // 3) Extraigo nombres de columnas dinámicamente:
            //    cols[0] = "Hora", cols[1] = "Cabina Individual", cols[2] = "Cabina Grupal"
            string[] cols = tablaFull.Columns
                                     .Cast<DataColumn>()
                                     .Select(c => c.ColumnName)
                                     .ToArray();

            // 4) Lleno dgvIndividual: copiamos la tabla y quitamos la columna 2 ("Cabina Grupal")
            var tablaInd = tablaFull.Copy();
            tablaInd.Columns.Remove(cols[2]);
            dgvIndividual.DataSource = tablaInd;
            dgvIndividual.Columns[1].HeaderText = cols[1];

            // 5) Lleno dgvGrupal: copiamos la tabla y quitamos la columna 1 ("Cabina Individual")
            var tablaGrp = tablaFull.Copy();
            tablaGrp.Columns.Remove(cols[1]);
            dgvGrupal.DataSource = tablaGrp;
            dgvGrupal.Columns[1].HeaderText = cols[2];

            // 6) Scroll automático a la fila de "ahora - 15 minutos"
            string target = DateTime.Now.AddMinutes(-15).ToString("HH:mm");
            var rows = tablaFull.Rows.Cast<DataRow>().ToList();
            int idx = rows.FindIndex(r => r.Field<string>("Hora") == target);
            if (idx >= 0)
            {
                dgvIndividual.FirstDisplayedScrollingRowIndex = idx;
                dgvGrupal.FirstDisplayedScrollingRowIndex = idx;
            }

            // 7) Actualizo el estado de los botones Edit/Delete (inicialmente desactivados si no hay selección)
            UpdateButtonsState(dgvIndividual, btnEditarReserva, btnEliminarReserva);
            UpdateButtonsState(dgvGrupal, btnEditarReserva2, btnEliminarReserva2);
        }

        #endregion

        #region Crear nueva reserva (“Nueva Reserva” sin selección previa)

        /// <summary>
        /// Abre el formulario NuevaReservaForm en modo creación, con la cabina indicada
        /// y horas por defecto (ahora → ahora+15 min).
        /// </summary>
        private async Task OpenNewReservationWithDefaults(string nombreCabina)
        {
            // 1) Buscamos el objeto Cabina en memoria a partir de su nombre
            var cabina = _vm.Cabinas.FirstOrDefault(c => c.Nombre == nombreCabina);
            if (cabina == null)
            {
                MessageBox.Show($"No se encontró la cabina “{nombreCabina}”.",
                                "Error Interno",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DateTime inicio = DateTime.Now;
            DateTime fin = inicio.AddMinutes(15);

            var form = (NuevaReservaForm)_sp.GetService(typeof(NuevaReservaForm));
            if (form == null) return;

            // Pasamos directamente el ID de la cabina
            form.SelectedCabinaId = cabina.Id;
            form.SelectedInicio = inicio;
            form.SelectedFin = fin;
            form.IsEditMode = false;

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                await LoadDataAsync();
            }
        }

        #endregion

        #region Crear nueva reserva con selección previa en un grid

        /// <summary>
        /// Si hay filas seleccionadas en el DataGridView, calcula inicio y fin
        /// según la cantidad de filas (15 min cada una) y abre NuevaReservaForm.
        /// </summary>
        private async Task OpenNewReservationFromGrid(DataGridView dgv, string nombreCabina)
        {
            // 1) Buscamos el objeto Cabina en memoria a partir de su nombre
            var cabina = _vm.Cabinas.FirstOrDefault(c => c.Nombre == nombreCabina);
            if (cabina == null)
            {
                MessageBox.Show($"No se encontró la cabina “{nombreCabina}”.",
                                "Error Interno",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            var filas = dgv.SelectedRows
                         .Cast<DataGridViewRow>()
                         .OrderBy(r => r.Index)
                         .ToList();
            if (filas.Count == 0)
            {
                MessageBox.Show("Selecciona al menos un slot para crear la reserva.",
                                "Sin selección",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            DateTime inicio = DateTime.Parse(filas.First().Cells["Hora"].Value.ToString());
            TimeSpan dur = TimeSpan.FromMinutes(15 * filas.Count);
            DateTime fin = inicio + dur;

            var form = (NuevaReservaForm)_sp.GetService(typeof(NuevaReservaForm));
            if (form == null) return;

            // Pasamos directamente el ID de la cabina
            form.SelectedCabinaId = cabina.Id;
            form.SelectedInicio = inicio;
            form.SelectedFin = fin;
            form.IsEditMode = false;

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                await LoadDataAsync();
            }
        }

        #endregion

        #region Editar reserva (doble-clic o botón “Editar”)

        /// <summary>
        /// Doble‐clic en celda: si está vacía, crea nueva; si tiene texto, abre en modo edición.
        /// </summary>
        private async void DataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (e.RowIndex < 0 || e.ColumnIndex == 0) return;

            DateTime hora = DateTime.Parse(dgv.Rows[e.RowIndex].Cells["Hora"].Value.ToString());
            string cabinaNombre = dgv.Columns[e.ColumnIndex].HeaderText;
            string contenido = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

            if (string.IsNullOrWhiteSpace(contenido))
            {
                // Si la celda está vacía, abrimos NuevaReservaForm
                await OpenNewReservationFromGrid(dgv, cabinaNombre);
                return;
            }

            // Si la celda tiene texto, abrimos EditReservaForm
            var reserva = _vm.Reservas.FirstOrDefault(r =>
                r.Inicio <= hora &&
                r.Fin > hora &&
                _vm.Cabinas.First(c => c.Id == r.CabinaId).Nombre == cabinaNombre);
            if (reserva == null) return;

            var form = (EditarReservaForm)_sp.GetService(typeof(EditarReservaForm));
            if (form == null) return;

            // 1) Pasamos ID de reserva a editar
            form.EditingReservaId = reserva.Id;

            // 2) Pasamos ID de la cabina a partir del nombre
            var cabina = _vm.Cabinas.FirstOrDefault(c => c.Nombre == cabinaNombre);
            if (cabina == null)
            {
                MessageBox.Show($"No se encontró la cabina “{cabinaNombre}”.",
                                "Error Interno",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            form.SelectedCabinaId = cabina.Id;

            form.SelectedInicio = reserva.Inicio;
            form.SelectedFin = reserva.Fin;

            // Cargamos el DNI del usuario
            var usuario = await _vm.GetUsuarioByIdAsync(reserva.UsuarioId);
            form.Dni = usuario?.Dni ?? string.Empty;

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                await LoadDataAsync();
            }
        }

        /// <summary>
        /// Botón “Editar” debajo del grid de cabina.
        /// </summary>
        private async Task EditSelectedReservation(DataGridView dgv, string nombreCabina)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un slot ocupado para editar la reserva.",
                                "Sin selección",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            var fila = dgv.SelectedRows.Cast<DataGridViewRow>().First();
            DateTime hora = DateTime.Parse(fila.Cells["Hora"].Value.ToString());
            string cabina = nombreCabina;

            var reserva = _vm.Reservas.FirstOrDefault(r =>
                r.Inicio <= hora &&
                r.Fin > hora &&
                _vm.Cabinas.First(c => c.Id == r.CabinaId).Nombre == cabina);
            if (reserva == null)
            {
                MessageBox.Show("No se encontró la reserva seleccionada.",
                                "Error Interno",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            var form = (EditarReservaForm)_sp.GetService(typeof(EditarReservaForm));
            if (form == null) return;

            // 1) Pasamos ID de reserva a editar
            form.EditingReservaId = reserva.Id;

            // 2) Pasamos ID de la cabina a partir del nombre
            var cabinaObj = _vm.Cabinas.FirstOrDefault(c => c.Nombre == cabina);
            if (cabinaObj == null)
            {
                MessageBox.Show($"No se encontró la cabina “{cabina}”.",
                                "Error Interno",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            form.SelectedCabinaId = cabinaObj.Id;

            form.SelectedInicio = reserva.Inicio;
            form.SelectedFin = reserva.Fin;

            var usuario = await _vm.GetUsuarioByIdAsync(reserva.UsuarioId);
            form.Dni = usuario?.Dni ?? string.Empty;

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                await LoadDataAsync();
            }
        }

        #endregion

        #region Eliminar reserva (botón “Eliminar”)

        /// <summary>
        /// Botón “Eliminar” debajo del grid de cabina.
        /// </summary>
        private async Task DeleteSelectedReservation(DataGridView dgv, string nombreCabina)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un slot ocupado para eliminar la reserva.",
                                "Sin selección",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            var fila = dgv.SelectedRows.Cast<DataGridViewRow>().First();
            DateTime hora = DateTime.Parse(fila.Cells["Hora"].Value.ToString());
            string cabina = nombreCabina;

            var reserva = _vm.Reservas.FirstOrDefault(r =>
                r.Inicio <= hora &&
                r.Fin > hora &&
                _vm.Cabinas.First(c => c.Id == r.CabinaId).Nombre == cabina);
            if (reserva == null)
            {
                MessageBox.Show("No se encontró la reserva seleccionada.",
                                "Error Interno",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            var resp = MessageBox.Show(
                $"¿Eliminar la reserva de {hora:HH:mm} en {cabina}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                bool borrado = await _vm.DeleteReservaAsync(reserva.Id);
                if (!borrado)
                {
                    MessageBox.Show("No se pudo eliminar la reserva.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    await LoadDataAsync();
                }
            }
        }

        #endregion

        #region Click derecho en grid para abrir NuevaReservaForm

        private async void Grid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex == 0)
                return;

            var dgv = (DataGridView)sender;
            string cabinaNombre = dgv == dgvIndividual ? "Cabina Individual" : "Cabina Grupal";

            // 1) Buscamos el objeto Cabina en memoria a partir de su nombre
            var cabina = _vm.Cabinas.FirstOrDefault(c => c.Nombre == cabinaNombre);
            if (cabina == null)
            {
                MessageBox.Show($"No se encontró la cabina “{cabinaNombre}”.",
                                "Error Interno",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // 2) Averiguamos si la fila clicada está dentro de la selección; si no, solo esa fila
            var filasSeleccionadas = dgv.SelectedRows
                                       .Cast<DataGridViewRow>()
                                       .Where(r => r.Index >= 0)
                                       .OrderBy(r => r.Index)
                                       .ToList();

            var filas = filasSeleccionadas.Any(r => r.Index == e.RowIndex)
                        ? filasSeleccionadas
                        : new System.Collections.Generic.List<DataGridViewRow> { dgv.Rows[e.RowIndex] };

            DateTime inicio = DateTime.Parse(filas.First().Cells["Hora"].Value.ToString());
            DateTime fin;
            if (filas.Count > 1)
            {
                fin = DateTime.Parse(filas.Last().Cells["Hora"].Value.ToString()).AddMinutes(15);
            }
            else
            {
                fin = inicio.AddMinutes(15);
            }

            var form = (NuevaReservaForm)_sp.GetService(typeof(NuevaReservaForm));
            if (form == null) return;

            // Pasamos directamente el ID de la cabina
            form.SelectedCabinaId = cabina.Id;
            form.SelectedInicio = inicio;
            form.SelectedFin = fin;
            form.IsEditMode = false;

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                await LoadDataAsync();
            }
        }

        #endregion

        #region Métodos “stub” que inyecta el diseñador para los menús

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Queda vacío; los sub‐items se manejan en sus propios handlers
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Queda vacío; los sub‐items se manejan en sus propios handlers
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cabinaIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = OpenNewReservationWithDefaults("Cabina Individual");
        }

        private void cabinaGrupalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = OpenNewReservationWithDefaults("Cabina Grupal");
        }

        private void editarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = (MenuReservasForm)_sp.GetService(typeof(MenuReservasForm));
            frm?.ShowDialog(this);
        }

        // --- Acá cambiamos para invocar el MenuUsuariosForm en lugar de NuevoUsuarioForm ---
        private void nuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir formulario para dar de alta un nuevo usuario (es opcional si quieres desde ahí poder crear un usuario)
            var nuevoFrm = (NuevoUsuarioForm)_sp.GetService(typeof(NuevoUsuarioForm));
            nuevoFrm?.ShowDialog(this);
        }

        private void gestionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de gestión completa de usuarios
            var gestionFrm = (MenuUsuariosForm)_sp.GetService(typeof(MenuUsuariosForm));
            gestionFrm?.ShowDialog(this);
        }

        #endregion
    }
}
