namespace Reserva_de_Espacios_Biblioteca.Views
{
    partial class ReservaForm
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
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dtpFecha = new DateTimePicker();
            dgvHorario = new DataGridView();
            btnNuevaReserva = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHorario).BeginInit();
            SuspendLayout();
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(570, 54);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 0;
            // 
            // dgvHorario
            // 
            dgvHorario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHorario.Dock = DockStyle.Fill;
            dgvHorario.Location = new Point(0, 0);
            dgvHorario.Name = "dgvHorario";
            dgvHorario.Size = new Size(800, 450);
            dgvHorario.TabIndex = 1;
            // 
            // btnNuevaReserva
            // 
            btnNuevaReserva.Location = new Point(570, 93);
            btnNuevaReserva.Name = "btnNuevaReserva";
            btnNuevaReserva.Size = new Size(200, 30);
            btnNuevaReserva.TabIndex = 2;
            btnNuevaReserva.Text = "Nueva Reserva";
            btnNuevaReserva.UseVisualStyleBackColor = true;
            // 
            // ReservaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNuevaReserva);
            Controls.Add(dtpFecha);
            Controls.Add(dgvHorario);
            Name = "ReservaForm";
            Text = "Nueva Reserva";
            ((System.ComponentModel.ISupportInitialize)dgvHorario).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private DateTimePicker dtpFecha;
        private DataGridView dgvHorario;
        private Button btnNuevaReserva;
    }
}