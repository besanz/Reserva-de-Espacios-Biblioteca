using Reserva_de_Espacios_Biblioteca.Data.Entities;

namespace Reserva_de_Espacios_Biblioteca.Views
{
    partial class NuevaReservaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cbCabinas = new ComboBox();
            dtpInicio = new DateTimePicker();
            dtpFin = new DateTimePicker();
            contextMenuStrip1 = new ContextMenuStrip(components);
            txtDni = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // cbCabinas
            // 
            cbCabinas.Dock = DockStyle.Top;
            cbCabinas.FormattingEnabled = true;
            cbCabinas.Location = new Point(0, 0);
            cbCabinas.Name = "cbCabinas";
            cbCabinas.Size = new Size(800, 23);
            cbCabinas.TabIndex = 0;
            // 
            // dtpInicio
            // 
            dtpInicio.CustomFormat = "dd/MM/yyyy - HH:mm";
            dtpInicio.Dock = DockStyle.Top;
            dtpInicio.Format = DateTimePickerFormat.Custom;
            dtpInicio.Location = new Point(0, 23);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(800, 23);
            dtpInicio.TabIndex = 1;
            // 
            // dtpFin
            // 
            dtpFin.CustomFormat = "dd/MM/yyyy - HH:mm";
            dtpFin.Dock = DockStyle.Top;
            dtpFin.Format = DateTimePickerFormat.Custom;
            dtpFin.Location = new Point(0, 46);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(800, 23);
            dtpFin.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // txtDni
            // 
            txtDni.Dock = DockStyle.Top;
            txtDni.Location = new Point(0, 69);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(800, 23);
            txtDni.TabIndex = 4;
            txtDni.Text = "Introduce un DNI";
            // 
            // btnAceptar
            // 
            btnAceptar.Dock = DockStyle.Top;
            btnAceptar.Location = new Point(0, 92);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(800, 23);
            btnAceptar.TabIndex = 5;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += async (_, __) =>
            {
                var r = new Reserva { /* … */ };
                await _vm.CreateReservaAsync(r);
                DialogResult = DialogResult.OK;
                Close();
            };

            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Dock = DockStyle.Top;
            btnCancelar.Location = new Point(0, 115);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(800, 23);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // NuevaReservaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtDni);
            Controls.Add(dtpFin);
            Controls.Add(dtpInicio);
            Controls.Add(cbCabinas);
            Name = "NuevaReservaForm";
            Text = "Nueva Reserva";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbCabinas;
        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFin;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtDni;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}