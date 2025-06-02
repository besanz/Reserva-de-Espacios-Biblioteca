namespace Reserva_de_Espacios_Biblioteca.Views
{
    partial class MenuReservasForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controles del formulario
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnNuevaReserva;
        private System.Windows.Forms.DataGridView dgvReservas;

        private System.Windows.Forms.GroupBox gbDetalles;
        private System.Windows.Forms.Label lblCabinaDetalle;
        private System.Windows.Forms.TextBox txtCabinaDetalle;
        private System.Windows.Forms.Label lblUsuarioDetalle;
        private System.Windows.Forms.TextBox txtUsuarioDetalle;
        private System.Windows.Forms.Label lblDniDetalle;
        private System.Windows.Forms.TextBox txtDniDetalle;
        private System.Windows.Forms.Label lblInicioDetalle;
        private System.Windows.Forms.DateTimePicker dtpInicioDetalle;
        private System.Windows.Forms.Label lblFinDetalle;
        private System.Windows.Forms.DateTimePicker dtpFinDetalle;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Button btnEliminarReserva;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Método requerido para Designer support – no modificar
        /// con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            btnNuevaReserva = new Button();
            dgvReservas = new DataGridView();
            gbDetalles = new GroupBox();
            lblCabinaDetalle = new Label();
            txtCabinaDetalle = new TextBox();
            lblUsuarioDetalle = new Label();
            txtUsuarioDetalle = new TextBox();
            lblDniDetalle = new Label();
            txtDniDetalle = new TextBox();
            lblInicioDetalle = new Label();
            dtpInicioDetalle = new DateTimePicker();
            lblFinDetalle = new Label();
            dtpFinDetalle = new DateTimePicker();
            btnGuardarCambios = new Button();
            btnEliminarReserva = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            gbDetalles.SuspendLayout();
            SuspendLayout();
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 9.75F);
            lblFecha.Location = new Point(12, 15);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(99, 17);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Seleccionar día:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(129, 12);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(110, 25);
            dtpFecha.TabIndex = 1;
            // 
            // btnNuevaReserva
            // 
            btnNuevaReserva.BackColor = Color.FromArgb(192, 255, 192);
            btnNuevaReserva.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnNuevaReserva.Location = new Point(256, 10);
            btnNuevaReserva.Name = "btnNuevaReserva";
            btnNuevaReserva.Size = new Size(120, 28);
            btnNuevaReserva.TabIndex = 2;
            btnNuevaReserva.Text = "Nueva Reserva";
            btnNuevaReserva.UseVisualStyleBackColor = false;
            // 
            // dgvReservas
            // 
            dgvReservas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Location = new Point(12, 50);
            dgvReservas.MultiSelect = false;
            dgvReservas.Name = "dgvReservas";
            dgvReservas.ReadOnly = true;
            dgvReservas.RowHeadersVisible = false;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.Size = new Size(650, 400);
            dgvReservas.TabIndex = 3;
            // 
            // gbDetalles
            // 
            gbDetalles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            gbDetalles.Controls.Add(lblCabinaDetalle);
            gbDetalles.Controls.Add(txtCabinaDetalle);
            gbDetalles.Controls.Add(lblUsuarioDetalle);
            gbDetalles.Controls.Add(txtUsuarioDetalle);
            gbDetalles.Controls.Add(lblDniDetalle);
            gbDetalles.Controls.Add(txtDniDetalle);
            gbDetalles.Controls.Add(lblInicioDetalle);
            gbDetalles.Controls.Add(dtpInicioDetalle);
            gbDetalles.Controls.Add(lblFinDetalle);
            gbDetalles.Controls.Add(dtpFinDetalle);
            gbDetalles.Controls.Add(btnGuardarCambios);
            gbDetalles.Controls.Add(btnEliminarReserva);
            gbDetalles.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            gbDetalles.Location = new Point(680, 10);
            gbDetalles.Name = "gbDetalles";
            gbDetalles.Size = new Size(350, 442);
            gbDetalles.TabIndex = 4;
            gbDetalles.TabStop = false;
            gbDetalles.Text = "Detalles de la Reserva";
            // 
            // lblCabinaDetalle
            // 
            lblCabinaDetalle.AutoSize = true;
            lblCabinaDetalle.Location = new Point(15, 30);
            lblCabinaDetalle.Name = "lblCabinaDetalle";
            lblCabinaDetalle.Size = new Size(54, 17);
            lblCabinaDetalle.TabIndex = 0;
            lblCabinaDetalle.Text = "Cabina:";
            // 
            // txtCabinaDetalle
            // 
            txtCabinaDetalle.Location = new Point(110, 27);
            txtCabinaDetalle.Name = "txtCabinaDetalle";
            txtCabinaDetalle.ReadOnly = true;
            txtCabinaDetalle.Size = new Size(220, 25);
            txtCabinaDetalle.TabIndex = 1;
            // 
            // lblUsuarioDetalle
            // 
            lblUsuarioDetalle.AutoSize = true;
            lblUsuarioDetalle.Location = new Point(15, 65);
            lblUsuarioDetalle.Name = "lblUsuarioDetalle";
            lblUsuarioDetalle.Size = new Size(59, 17);
            lblUsuarioDetalle.TabIndex = 2;
            lblUsuarioDetalle.Text = "Usuario:";
            // 
            // txtUsuarioDetalle
            // 
            txtUsuarioDetalle.Location = new Point(110, 62);
            txtUsuarioDetalle.Name = "txtUsuarioDetalle";
            txtUsuarioDetalle.ReadOnly = true;
            txtUsuarioDetalle.Size = new Size(220, 25);
            txtUsuarioDetalle.TabIndex = 3;
            // 
            // lblDniDetalle
            // 
            lblDniDetalle.AutoSize = true;
            lblDniDetalle.Location = new Point(15, 100);
            lblDniDetalle.Name = "lblDniDetalle";
            lblDniDetalle.Size = new Size(36, 17);
            lblDniDetalle.TabIndex = 4;
            lblDniDetalle.Text = "DNI:";
            // 
            // txtDniDetalle
            // 
            txtDniDetalle.Location = new Point(110, 97);
            txtDniDetalle.Name = "txtDniDetalle";
            txtDniDetalle.ReadOnly = true;
            txtDniDetalle.Size = new Size(220, 25);
            txtDniDetalle.TabIndex = 5;
            // 
            // lblInicioDetalle
            // 
            lblInicioDetalle.AutoSize = true;
            lblInicioDetalle.Location = new Point(15, 130);
            lblInicioDetalle.Name = "lblInicioDetalle";
            lblInicioDetalle.Size = new Size(80, 17);
            lblInicioDetalle.TabIndex = 6;
            lblInicioDetalle.Text = "Hora Inicio:";
            // 
            // dtpInicioDetalle
            // 
            dtpInicioDetalle.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpInicioDetalle.Format = DateTimePickerFormat.Custom;
            dtpInicioDetalle.Location = new Point(110, 127);
            dtpInicioDetalle.Name = "dtpInicioDetalle";
            dtpInicioDetalle.ShowUpDown = true;
            dtpInicioDetalle.Size = new Size(220, 25);
            dtpInicioDetalle.TabIndex = 7;
            // 
            // lblFinDetalle
            // 
            lblFinDetalle.AutoSize = true;
            lblFinDetalle.Location = new Point(15, 160);
            lblFinDetalle.Name = "lblFinDetalle";
            lblFinDetalle.Size = new Size(65, 17);
            lblFinDetalle.TabIndex = 8;
            lblFinDetalle.Text = "Hora Fin:";
            // 
            // dtpFinDetalle
            // 
            dtpFinDetalle.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFinDetalle.Format = DateTimePickerFormat.Custom;
            dtpFinDetalle.Location = new Point(110, 157);
            dtpFinDetalle.Name = "dtpFinDetalle";
            dtpFinDetalle.ShowUpDown = true;
            dtpFinDetalle.Size = new Size(220, 25);
            dtpFinDetalle.TabIndex = 9;
            // 
            // btnGuardarCambios
            // 
            btnGuardarCambios.BackColor = Color.FromArgb(255, 255, 192);
            btnGuardarCambios.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnGuardarCambios.Location = new Point(110, 200);
            btnGuardarCambios.Name = "btnGuardarCambios";
            btnGuardarCambios.Size = new Size(100, 30);
            btnGuardarCambios.TabIndex = 10;
            btnGuardarCambios.Text = "Guardar";
            btnGuardarCambios.UseVisualStyleBackColor = false;
            // 
            // btnEliminarReserva
            // 
            btnEliminarReserva.BackColor = Color.FromArgb(255, 192, 192);
            btnEliminarReserva.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnEliminarReserva.Location = new Point(225, 200);
            btnEliminarReserva.Name = "btnEliminarReserva";
            btnEliminarReserva.Size = new Size(100, 30);
            btnEliminarReserva.TabIndex = 11;
            btnEliminarReserva.Text = "Eliminar";
            btnEliminarReserva.UseVisualStyleBackColor = false;
            // 
            // MenuReservasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 472);
            Controls.Add(lblFecha);
            Controls.Add(dtpFecha);
            Controls.Add(btnNuevaReserva);
            Controls.Add(dgvReservas);
            Controls.Add(gbDetalles);
            Font = new Font("Segoe UI", 9.75F);
            Name = "MenuReservasForm";
            Text = "Gestión de Reservas";
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            gbDetalles.ResumeLayout(false);
            gbDetalles.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
