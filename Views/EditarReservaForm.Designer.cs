namespace Reserva_de_Espacios_Biblioteca.Views
{
    partial class EditarReservaForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblDni;
        private TextBox txtDni;
        private Button btnBuscarUsuario;
        private Label lblInicio;
        private DateTimePicker dtpInicio;
        private Label lblFin;
        private DateTimePicker dtpFin;
        private Button btnAceptar;
        private Button btnCancelar;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblDni = new Label();
            this.txtDni = new TextBox();
            this.btnBuscarUsuario = new Button();
            this.lblInicio = new Label();
            this.dtpInicio = new DateTimePicker();
            this.lblFin = new Label();
            this.dtpFin = new DateTimePicker();
            this.btnAceptar = new Button();
            this.btnCancelar = new Button();

            // 
            // EditarReservaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 260);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarReservaForm";
            this.Text = "Editar Reserva";
            this.StartPosition = FormStartPosition.CenterParent;

            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(20, 20);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(170, 15);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "Buscar usuario (Nombre/Apellidos o DNI):";

            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(20, 45);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(250, 23);
            this.txtDni.TabIndex = 1;

            // 
            // btnBuscarUsuario
            // 
            this.btnBuscarUsuario.Location = new System.Drawing.Point(285, 44);
            this.btnBuscarUsuario.Name = "btnBuscarUsuario";
            this.btnBuscarUsuario.Size = new System.Drawing.Size(100, 25);
            this.btnBuscarUsuario.TabIndex = 2;
            this.btnBuscarUsuario.Text = "Buscar";
            this.btnBuscarUsuario.UseVisualStyleBackColor = true;

            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(20, 90);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(110, 15);
            this.lblInicio.TabIndex = 3;
            this.lblInicio.Text = "Hora inicio reserva:";

            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(20, 115);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.ShowUpDown = true;
            this.dtpInicio.Size = new System.Drawing.Size(200, 23);
            this.dtpInicio.TabIndex = 4;

            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Location = new System.Drawing.Point(20, 155);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(110, 15);
            this.lblFin.TabIndex = 5;
            this.lblFin.Text = "Hora fin de reserva:";

            // 
            // dtpFin
            // 
            this.dtpFin.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(20, 180);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.ShowUpDown = true;
            this.dtpFin.Size = new System.Drawing.Size(200, 23);
            this.dtpFin.TabIndex = 6;

            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(90, 215);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 30);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;

            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(240, 215);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;

            // 
            // Controles - Añadimos a la forma
            // 
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.btnBuscarUsuario);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.lblFin);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
        }

        #endregion
    }
}
