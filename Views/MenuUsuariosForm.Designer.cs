namespace Reserva_de_Espacios_Biblioteca.Views
{
    partial class MenuUsuariosForm
    {
        private System.ComponentModel.IContainer components = null;

        // Left panel controls
        private SplitContainer splitContainer1;
        private GroupBox gbListadoUsuarios;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvUsuarios;

        // Right panel controls
        private GroupBox gbDetalleUsuario;
        private Label lblDni;
        private TextBox txtDni;
        private Label lblApellidos;
        private TextBox txtApellidos;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private CheckBox chkEstaActivo;
        private Button btnNuevo;
        private Button btnEditar;
        private Button btnGuardar;
        private Button btnCancelar;
        private Button btnToggleActivo;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            gbListadoUsuarios = new GroupBox();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvUsuarios = new DataGridView();
            gbDetalleUsuario = new GroupBox();
            lblDni = new Label();
            txtDni = new TextBox();
            lblApellidos = new Label();
            txtApellidos = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            chkEstaActivo = new CheckBox();
            btnNuevo = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();
            btnToggleActivo = new Button();

            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // Left panel: listado
            splitContainer1.Panel1.Controls.Add(gbListadoUsuarios);
            // Right panel: detalle
            splitContainer1.Panel2.Controls.Add(gbDetalleUsuario);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 350;
            splitContainer1.TabIndex = 0;

            // 
            // gbListadoUsuarios
            // 
            gbListadoUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbListadoUsuarios.Controls.Add(txtBuscar);
            gbListadoUsuarios.Controls.Add(btnBuscar);
            gbListadoUsuarios.Controls.Add(dgvUsuarios);
            gbListadoUsuarios.Location = new Point(3, 3);
            gbListadoUsuarios.Name = "gbListadoUsuarios";
            gbListadoUsuarios.Size = new Size(344, 444);
            gbListadoUsuarios.TabIndex = 0;
            gbListadoUsuarios.TabStop = false;
            gbListadoUsuarios.Text = "Usuarios";

            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(6, 22);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(232, 23);
            txtBuscar.TabIndex = 0;

            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.Location = new Point(244, 21);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 25);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;

            // 
            // dgvUsuarios
            // 
            dgvUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(6, 55);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(332, 383);
            dgvUsuarios.TabIndex = 2;
            dgvUsuarios.MultiSelect = false;

            // 
            // gbDetalleUsuario
            // 
            gbDetalleUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbDetalleUsuario.Controls.Add(lblDni);
            gbDetalleUsuario.Controls.Add(txtDni);
            gbDetalleUsuario.Controls.Add(lblApellidos);
            gbDetalleUsuario.Controls.Add(txtApellidos);
            gbDetalleUsuario.Controls.Add(lblNombre);
            gbDetalleUsuario.Controls.Add(txtNombre);
            gbDetalleUsuario.Controls.Add(lblEmail);
            gbDetalleUsuario.Controls.Add(txtEmail);
            gbDetalleUsuario.Controls.Add(lblTelefono);
            gbDetalleUsuario.Controls.Add(txtTelefono);
            gbDetalleUsuario.Controls.Add(chkEstaActivo);
            gbDetalleUsuario.Controls.Add(btnNuevo);
            gbDetalleUsuario.Controls.Add(btnEditar);
            gbDetalleUsuario.Controls.Add(btnGuardar);
            gbDetalleUsuario.Controls.Add(btnCancelar);
            gbDetalleUsuario.Controls.Add(btnToggleActivo);
            gbDetalleUsuario.Location = new Point(3, 3);
            gbDetalleUsuario.Name = "gbDetalleUsuario";
            gbDetalleUsuario.Size = new Size(440, 444);
            gbDetalleUsuario.TabIndex = 0;
            gbDetalleUsuario.TabStop = false;
            gbDetalleUsuario.Text = "Detalles del Usuario";

            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(16, 30);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(28, 15);
            lblDni.TabIndex = 0;
            lblDni.Text = "DNI";

            // 
            // txtDni
            // 
            txtDni.Location = new Point(100, 27);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(200, 23);
            txtDni.TabIndex = 1;
            txtDni.ReadOnly = true;

            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Location = new Point(16, 70);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(60, 15);
            lblApellidos.TabIndex = 2;
            lblApellidos.Text = "Apellidos";

            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(100, 67);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(320, 23);
            txtApellidos.TabIndex = 3;
            txtApellidos.ReadOnly = true;

            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(16, 110);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre";

            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(100, 107);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(320, 23);
            txtNombre.TabIndex = 5;
            txtNombre.ReadOnly = true;

            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(16, 150);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email";

            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(100, 147);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(320, 23);
            txtEmail.TabIndex = 7;
            txtEmail.ReadOnly = true;

            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(16, 190);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(57, 15);
            lblTelefono.TabIndex = 8;
            lblTelefono.Text = "Teléfono";

            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(100, 187);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(320, 23);
            txtTelefono.TabIndex = 9;
            txtTelefono.ReadOnly = true;

            // 
            // chkEstaActivo
            // 
            chkEstaActivo.AutoSize = true;
            chkEstaActivo.Enabled = false;
            chkEstaActivo.Location = new Point(100, 227);
            chkEstaActivo.Name = "chkEstaActivo";
            chkEstaActivo.Size = new Size(75, 19);
            chkEstaActivo.TabIndex = 10;
            chkEstaActivo.Text = "Activo";
            chkEstaActivo.UseVisualStyleBackColor = true;

            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(16, 270);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 30);
            btnNuevo.TabIndex = 11;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;

            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(97, 270);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 30);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Enabled = false;

            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(178, 270);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 30);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Enabled = false;

            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(259, 270);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 30);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Enabled = false;

            // 
            // btnToggleActivo
            // 
            btnToggleActivo.Location = new Point(340, 270);
            btnToggleActivo.Name = "btnToggleActivo";
            btnToggleActivo.Size = new Size(80, 30);
            btnToggleActivo.TabIndex = 15;
            btnToggleActivo.Text = "Desactivar";
            btnToggleActivo.UseVisualStyleBackColor = true;
            btnToggleActivo.Enabled = false;

            // 
            // MenuUsuariosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "MenuUsuariosForm";
            Text = "Gestión de Usuarios";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).EndInit();
            splitContainer1.ResumeLayout(false);
            gbListadoUsuarios.ResumeLayout(false);
            gbListadoUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvUsuarios)).EndInit();
            gbDetalleUsuario.ResumeLayout(false);
            gbDetalleUsuario.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
