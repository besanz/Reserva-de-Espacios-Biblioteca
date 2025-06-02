namespace Reserva_de_Espacios_Biblioteca.Views
{
    partial class ReservaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTipoCabina;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.Label lblHoraFin;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;
        private System.Windows.Forms.Button btnConfirmar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTipoCabina = new Label();
            lblFecha = new Label();
            lblHoraInicio = new Label();
            lblHoraFin = new Label();
            dtpFecha = new DateTimePicker();
            dtpHoraInicio = new DateTimePicker();
            dtpHoraFin = new DateTimePicker();
            btnConfirmar = new Button();
            txtDni = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblTipoCabina
            // 
            lblTipoCabina.AutoSize = true;
            lblTipoCabina.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTipoCabina.Location = new Point(12, 9);
            lblTipoCabina.Name = "lblTipoCabina";
            lblTipoCabina.Size = new Size(161, 21);
            lblTipoCabina.TabIndex = 0;
            lblTipoCabina.Text = "Cabina: [pendiente]";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(12, 50);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "Fecha:";
            // 
            // lblHoraInicio
            // 
            lblHoraInicio.AutoSize = true;
            lblHoraInicio.Location = new Point(12, 85);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(68, 15);
            lblHoraInicio.TabIndex = 3;
            lblHoraInicio.Text = "Hora inicio:";
            // 
            // lblHoraFin
            // 
            lblHoraFin.AutoSize = true;
            lblHoraFin.Location = new Point(12, 120);
            lblHoraFin.Name = "lblHoraFin";
            lblHoraFin.Size = new Size(53, 15);
            lblHoraFin.TabIndex = 5;
            lblHoraFin.Text = "Hora fin:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(70, 45);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(100, 23);
            dtpFecha.TabIndex = 2;
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(90, 80);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Size = new Size(80, 23);
            dtpHoraInicio.TabIndex = 4;
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Enabled = false;
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(90, 115);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Size = new Size(80, 23);
            dtpHoraFin.TabIndex = 6;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(200, 80);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(100, 60);
            btnConfirmar.TabIndex = 7;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(90, 159);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(110, 23);
            txtDni.TabIndex = 8;
            txtDni.TextChanged += txtDni_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 162);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 9;
            label1.Text = "Hora fin:";
            label1.Click += label1_Click;
            // 
            // ReservaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 361);
            Controls.Add(label1);
            Controls.Add(txtDni);
            Controls.Add(lblTipoCabina);
            Controls.Add(lblFecha);
            Controls.Add(dtpFecha);
            Controls.Add(lblHoraInicio);
            Controls.Add(dtpHoraInicio);
            Controls.Add(lblHoraFin);
            Controls.Add(dtpHoraFin);
            Controls.Add(btnConfirmar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReservaForm";
            Text = "Nueva Reserva";
            ResumeLayout(false);
            PerformLayout();
        }
        internal TextBox txtDni;
        private Label label1;
    }
}
