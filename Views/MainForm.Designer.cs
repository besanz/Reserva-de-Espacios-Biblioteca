namespace Reserva_de_Espacios_Biblioteca.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem reservasToolStripMenuItem;
        private ToolStripMenuItem nuevaReservaToolStripMenuItem;
        private ToolStripMenuItem cabinaIndividualToolStripMenuItem;
        private ToolStripMenuItem cabinaGrupalToolStripMenuItem;
        private ToolStripMenuItem editarReservaToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem nuevoUsuarioToolStripMenuItem;
        private ToolStripMenuItem gestionDeUsuariosToolStripMenuItem;
        private ToolStripMenuItem documentaciónToolStripMenuItem;
        private ToolStripMenuItem manualDeUsuarioToolStripMenuItem;
        private ToolStripMenuItem desarrolladoresToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolTip toolTip1;
        private TableLayoutPanel tlpCabinas;
        private GroupBox gbGrupal;
        private Button btnEliminarReserva2;
        private Button btnEditarReserva2;
        private DataGridView dgvGrupal;
        private Button btnNuevaReserva2;
        private GroupBox gbIndividual;
        private Button btnEliminarReserva;
        private Button btnEditarReserva;
        private Button btnNuevaReserva;
        private DataGridView dgvIndividual;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            reservasToolStripMenuItem = new ToolStripMenuItem();
            nuevaReservaToolStripMenuItem = new ToolStripMenuItem();
            cabinaIndividualToolStripMenuItem = new ToolStripMenuItem();
            cabinaGrupalToolStripMenuItem = new ToolStripMenuItem();
            editarReservaToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            nuevoUsuarioToolStripMenuItem = new ToolStripMenuItem();
            gestionDeUsuariosToolStripMenuItem = new ToolStripMenuItem();
            documentaciónToolStripMenuItem = new ToolStripMenuItem();
            manualDeUsuarioToolStripMenuItem = new ToolStripMenuItem();
            desarrolladoresToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            toolTip1 = new ToolTip(components);
            tlpCabinas = new TableLayoutPanel();
            gbGrupal = new GroupBox();
            btnEliminarReserva2 = new Button();
            btnEditarReserva2 = new Button();
            dgvGrupal = new DataGridView();
            btnNuevaReserva2 = new Button();
            gbIndividual = new GroupBox();
            btnEliminarReserva = new Button();
            btnEditarReserva = new Button();
            btnNuevaReserva = new Button();
            dgvIndividual = new DataGridView();
            menuStrip1.SuspendLayout();
            tlpCabinas.SuspendLayout();
            gbGrupal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrupal).BeginInit();
            gbIndividual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIndividual).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { reservasToolStripMenuItem, usuariosToolStripMenuItem, documentaciónToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            // 
            // reservasToolStripMenuItem
            // 
            reservasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevaReservaToolStripMenuItem, editarReservaToolStripMenuItem });
            reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            reservasToolStripMenuItem.Size = new Size(64, 20);
            reservasToolStripMenuItem.Text = "Reservas";
            reservasToolStripMenuItem.Click += reservasToolStripMenuItem_Click;
            // 
            // nuevaReservaToolStripMenuItem
            // 
            nuevaReservaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cabinaIndividualToolStripMenuItem, cabinaGrupalToolStripMenuItem });
            nuevaReservaToolStripMenuItem.Name = "nuevaReservaToolStripMenuItem";
            nuevaReservaToolStripMenuItem.Size = new Size(178, 22);
            nuevaReservaToolStripMenuItem.Text = "Nueva Reserva";
            // 
            // cabinaIndividualToolStripMenuItem
            // 
            cabinaIndividualToolStripMenuItem.Name = "cabinaIndividualToolStripMenuItem";
            cabinaIndividualToolStripMenuItem.Size = new Size(166, 22);
            cabinaIndividualToolStripMenuItem.Text = "Cabina Individual";
            cabinaIndividualToolStripMenuItem.Click += cabinaIndividualToolStripMenuItem_Click;
            // 
            // cabinaGrupalToolStripMenuItem
            // 
            cabinaGrupalToolStripMenuItem.Name = "cabinaGrupalToolStripMenuItem";
            cabinaGrupalToolStripMenuItem.Size = new Size(166, 22);
            cabinaGrupalToolStripMenuItem.Text = "Cabina Grupal";
            cabinaGrupalToolStripMenuItem.Click += cabinaGrupalToolStripMenuItem_Click;
            // 
            // editarReservaToolStripMenuItem
            // 
            editarReservaToolStripMenuItem.Name = "editarReservaToolStripMenuItem";
            editarReservaToolStripMenuItem.Size = new Size(178, 22);
            editarReservaToolStripMenuItem.Text = "Gestión de Reservas";
            editarReservaToolStripMenuItem.Click += editarReservaToolStripMenuItem_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevoUsuarioToolStripMenuItem, gestionDeUsuariosToolStripMenuItem });
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(64, 20);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // nuevoUsuarioToolStripMenuItem
            // 
            nuevoUsuarioToolStripMenuItem.Name = "nuevoUsuarioToolStripMenuItem";
            nuevoUsuarioToolStripMenuItem.Size = new Size(180, 22);
            nuevoUsuarioToolStripMenuItem.Text = "Nuevo Usuario";
            nuevoUsuarioToolStripMenuItem.Click += nuevoUsuarioToolStripMenuItem_Click;
            // 
            // gestionDeUsuariosToolStripMenuItem
            // 
            gestionDeUsuariosToolStripMenuItem.Name = "gestionDeUsuariosToolStripMenuItem";
            gestionDeUsuariosToolStripMenuItem.Size = new Size(180, 22);
            gestionDeUsuariosToolStripMenuItem.Text = "Gestión de Usuarios";
            gestionDeUsuariosToolStripMenuItem.Click += gestionDeUsuariosToolStripMenuItem_Click;
            // 
            // documentaciónToolStripMenuItem
            // 
            documentaciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manualDeUsuarioToolStripMenuItem, desarrolladoresToolStripMenuItem });
            documentaciónToolStripMenuItem.Name = "documentaciónToolStripMenuItem";
            documentaciónToolStripMenuItem.Size = new Size(104, 20);
            documentaciónToolStripMenuItem.Text = "Documentación";
            // 
            // manualDeUsuarioToolStripMenuItem
            // 
            manualDeUsuarioToolStripMenuItem.Name = "manualDeUsuarioToolStripMenuItem";
            manualDeUsuarioToolStripMenuItem.Size = new Size(173, 22);
            manualDeUsuarioToolStripMenuItem.Text = "Manual de Usuario";
            // 
            // desarrolladoresToolStripMenuItem
            // 
            desarrolladoresToolStripMenuItem.Name = "desarrolladoresToolStripMenuItem";
            desarrolladoresToolStripMenuItem.Size = new Size(173, 22);
            desarrolladoresToolStripMenuItem.Text = "Desarrolladores";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(41, 20);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // tlpCabinas
            // 
            tlpCabinas.ColumnCount = 2;
            tlpCabinas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCabinas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCabinas.Controls.Add(gbGrupal, 1, 0);
            tlpCabinas.Controls.Add(gbIndividual, 0, 0);
            tlpCabinas.Dock = DockStyle.Fill;
            tlpCabinas.Location = new Point(0, 24);
            tlpCabinas.Name = "tlpCabinas";
            tlpCabinas.RowCount = 1;
            tlpCabinas.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCabinas.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCabinas.Size = new Size(800, 471);
            tlpCabinas.TabIndex = 3;
            // 
            // gbGrupal
            // 
            gbGrupal.Controls.Add(btnEliminarReserva2);
            gbGrupal.Controls.Add(btnEditarReserva2);
            gbGrupal.Controls.Add(dgvGrupal);
            gbGrupal.Controls.Add(btnNuevaReserva2);
            gbGrupal.Dock = DockStyle.Fill;
            gbGrupal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbGrupal.Location = new Point(403, 3);
            gbGrupal.Name = "gbGrupal";
            gbGrupal.Size = new Size(394, 465);
            gbGrupal.TabIndex = 0;
            gbGrupal.TabStop = false;
            gbGrupal.Text = "Cabina Grupal";
            // 
            // btnEliminarReserva2
            // 
            btnEliminarReserva2.BackColor = Color.FromArgb(255, 192, 192);
            btnEliminarReserva2.Location = new Point(260, 423);
            btnEliminarReserva2.Name = "btnEliminarReserva2";
            btnEliminarReserva2.Size = new Size(116, 35);
            btnEliminarReserva2.TabIndex = 6;
            btnEliminarReserva2.Text = "Eliminar";
            btnEliminarReserva2.UseVisualStyleBackColor = false;
            // 
            // btnEditarReserva2
            // 
            btnEditarReserva2.BackColor = Color.FromArgb(255, 255, 192);
            btnEditarReserva2.Location = new Point(138, 423);
            btnEditarReserva2.Name = "btnEditarReserva2";
            btnEditarReserva2.Size = new Size(116, 35);
            btnEditarReserva2.TabIndex = 5;
            btnEditarReserva2.Text = "Editar";
            btnEditarReserva2.UseVisualStyleBackColor = false;
            // 
            // dgvGrupal
            // 
            dgvGrupal.AllowUserToAddRows = false;
            dgvGrupal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGrupal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrupal.Location = new Point(0, 21);
            dgvGrupal.Name = "dgvGrupal";
            dgvGrupal.ReadOnly = true;
            dgvGrupal.RowHeadersVisible = false;
            dgvGrupal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGrupal.Size = new Size(388, 396);
            dgvGrupal.TabIndex = 0;
            // 
            // btnNuevaReserva2
            // 
            btnNuevaReserva2.BackColor = Color.FromArgb(192, 255, 192);
            btnNuevaReserva2.Location = new Point(16, 423);
            btnNuevaReserva2.Name = "btnNuevaReserva2";
            btnNuevaReserva2.Size = new Size(116, 35);
            btnNuevaReserva2.TabIndex = 4;
            btnNuevaReserva2.Text = "Nueva";
            btnNuevaReserva2.UseVisualStyleBackColor = false;
            // 
            // gbIndividual
            // 
            gbIndividual.Controls.Add(btnEliminarReserva);
            gbIndividual.Controls.Add(btnEditarReserva);
            gbIndividual.Controls.Add(btnNuevaReserva);
            gbIndividual.Controls.Add(dgvIndividual);
            gbIndividual.Dock = DockStyle.Fill;
            gbIndividual.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbIndividual.Location = new Point(3, 3);
            gbIndividual.Name = "gbIndividual";
            gbIndividual.Size = new Size(394, 465);
            gbIndividual.TabIndex = 1;
            gbIndividual.TabStop = false;
            gbIndividual.Text = "Cabina Individual";
            // 
            // btnEliminarReserva
            // 
            btnEliminarReserva.BackColor = Color.FromArgb(255, 192, 192);
            btnEliminarReserva.Location = new Point(263, 423);
            btnEliminarReserva.Name = "btnEliminarReserva";
            btnEliminarReserva.Size = new Size(116, 35);
            btnEliminarReserva.TabIndex = 3;
            btnEliminarReserva.Text = "Eliminar";
            btnEliminarReserva.UseVisualStyleBackColor = false;
            // 
            // btnEditarReserva
            // 
            btnEditarReserva.BackColor = Color.FromArgb(255, 255, 192);
            btnEditarReserva.Location = new Point(141, 423);
            btnEditarReserva.Name = "btnEditarReserva";
            btnEditarReserva.Size = new Size(116, 35);
            btnEditarReserva.TabIndex = 2;
            btnEditarReserva.Text = "Editar";
            btnEditarReserva.UseVisualStyleBackColor = false;
            // 
            // btnNuevaReserva
            // 
            btnNuevaReserva.BackColor = Color.FromArgb(192, 255, 192);
            btnNuevaReserva.Location = new Point(19, 423);
            btnNuevaReserva.Name = "btnNuevaReserva";
            btnNuevaReserva.Size = new Size(116, 35);
            btnNuevaReserva.TabIndex = 1;
            btnNuevaReserva.Text = "Nueva";
            btnNuevaReserva.UseVisualStyleBackColor = false;
            // 
            // dgvIndividual
            // 
            dgvIndividual.AllowUserToAddRows = false;
            dgvIndividual.AllowUserToDeleteRows = false;
            dgvIndividual.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIndividual.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIndividual.Location = new Point(3, 21);
            dgvIndividual.Name = "dgvIndividual";
            dgvIndividual.ReadOnly = true;
            dgvIndividual.RowHeadersVisible = false;
            dgvIndividual.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIndividual.Size = new Size(388, 396);
            dgvIndividual.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 495);
            Controls.Add(tlpCabinas);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Reserva de Espacios - Biblioteca Municipal";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tlpCabinas.ResumeLayout(false);
            gbGrupal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGrupal).EndInit();
            gbIndividual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvIndividual).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
