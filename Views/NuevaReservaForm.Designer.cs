namespace Reserva_de_Espacios_Biblioteca.Views
{
    partial class NuevaReservaForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        internal System.Windows.Forms.DateTimePicker dtpInicio;
        internal System.Windows.Forms.DateTimePicker dtpFin;
        internal System.Windows.Forms.TextBox txtDni;
        internal System.Windows.Forms.Button btnBuscarUsuario;
        internal System.Windows.Forms.Button btnAceptar;
        internal System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label labelBuscar;
        private System.Windows.Forms.Label labelInicio;
        private System.Windows.Forms.Label labelFin;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            dtpInicio = new System.Windows.Forms.DateTimePicker();
            dtpFin = new System.Windows.Forms.DateTimePicker();
            txtDni = new System.Windows.Forms.TextBox();
            btnBuscarUsuario = new System.Windows.Forms.Button();
            btnAceptar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            labelBuscar = new System.Windows.Forms.Label();
            labelInicio = new System.Windows.Forms.Label();
            labelFin = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // labelBuscar
            // 
            labelBuscar.AutoSize = true;
            labelBuscar.Location = new System.Drawing.Point(12, 30);
            labelBuscar.Name = "labelBuscar";
            labelBuscar.Size = new System.Drawing.Size(236, 15);
            labelBuscar.TabIndex = 0;
            labelBuscar.Text = "Buscar usuario (Nombre/Apellidos o DNI):";
            // 
            // txtDni
            // 
            txtDni.Location = new System.Drawing.Point(12, 49);
            txtDni.Name = "txtDni";
            txtDni.Size = new System.Drawing.Size(308, 23);
            txtDni.TabIndex = 1;
            // 
            // btnBuscarUsuario
            // 
            btnBuscarUsuario.Location = new System.Drawing.Point(326, 48);
            btnBuscarUsuario.Name = "btnBuscarUsuario";
            btnBuscarUsuario.Size = new System.Drawing.Size(171, 25);
            btnBuscarUsuario.TabIndex = 2;
            btnBuscarUsuario.Text = "Buscar";
            btnBuscarUsuario.UseVisualStyleBackColor = true;
            // 
            // labelInicio
            // 
            labelInicio.AutoSize = true;
            labelInicio.Location = new System.Drawing.Point(12, 91);
            labelInicio.Name = "labelInicio";
            labelInicio.Size = new System.Drawing.Size(131, 15);
            labelInicio.TabIndex = 3;
            labelInicio.Text = "Hora comienzo reserva:";
            // 
            // dtpInicio
            // 
            dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpInicio.Location = new System.Drawing.Point(12, 109);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.ShowUpDown = true;
            dtpInicio.Size = new System.Drawing.Size(485, 23);
            dtpInicio.TabIndex = 4;
            // 
            // labelFin
            // 
            labelFin.AutoSize = true;
            labelFin.Location = new System.Drawing.Point(12, 157);
            labelFin.Name = "labelFin";
            labelFin.Size = new System.Drawing.Size(109, 15);
            labelFin.TabIndex = 5;
            labelFin.Text = "Hora fin de reserva:";
            // 
            // dtpFin
            // 
            dtpFin.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpFin.Location = new System.Drawing.Point(12, 175);
            dtpFin.Name = "dtpFin";
            dtpFin.ShowUpDown = true;
            dtpFin.Size = new System.Drawing.Size(485, 23);
            dtpFin.TabIndex = 6;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new System.Drawing.Point(118, 216);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new System.Drawing.Size(300, 30);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancelar.Location = new System.Drawing.Point(118, 254);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(300, 30);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // NuevaReservaForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(522, 303);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(dtpFin);
            Controls.Add(labelFin);
            Controls.Add(dtpInicio);
            Controls.Add(labelInicio);
            Controls.Add(btnBuscarUsuario);
            Controls.Add(txtDni);
            Controls.Add(labelBuscar);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NuevaReservaForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Reserva Cabina Insonorizada";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
