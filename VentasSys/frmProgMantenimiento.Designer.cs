namespace VentasSys
{
    partial class frmProgMantenimiento
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
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.btnBuscarRuc = new System.Windows.Forms.Button();
            this.txtDesRuc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtDesCliente = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFechaEmision = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMantenimiento = new System.Windows.Forms.ComboBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvMantenimiento = new System.Windows.Forms.DataGridView();
            this.btnPagar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbEmpresa = new System.Windows.Forms.RadioButton();
            this.rdbPersona = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DELETE = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMantenimiento)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.BackColor = System.Drawing.Color.Green;
            this.btnNuevoCliente.FlatAppearance.BorderSize = 0;
            this.btnNuevoCliente.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNuevoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoCliente.ForeColor = System.Drawing.Color.White;
            this.btnNuevoCliente.Location = new System.Drawing.Point(391, 187);
            this.btnNuevoCliente.Margin = new System.Windows.Forms.Padding(0);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(23, 21);
            this.btnNuevoCliente.TabIndex = 113;
            this.btnNuevoCliente.Text = "+";
            this.btnNuevoCliente.UseVisualStyleBackColor = false;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // btnBuscarRuc
            // 
            this.btnBuscarRuc.FlatAppearance.BorderSize = 0;
            this.btnBuscarRuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarRuc.Image = global::VentasSys.Properties.Resources.search;
            this.btnBuscarRuc.Location = new System.Drawing.Point(391, 127);
            this.btnBuscarRuc.Name = "btnBuscarRuc";
            this.btnBuscarRuc.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarRuc.TabIndex = 112;
            this.btnBuscarRuc.UseVisualStyleBackColor = true;
            this.btnBuscarRuc.Click += new System.EventHandler(this.btnBuscarRuc_Click);
            // 
            // txtDesRuc
            // 
            this.txtDesRuc.Location = new System.Drawing.Point(138, 129);
            this.txtDesRuc.Name = "txtDesRuc";
            this.txtDesRuc.Size = new System.Drawing.Size(248, 20);
            this.txtDesRuc.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 110;
            this.label11.Text = "DNI/RUC";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.FlatAppearance.BorderSize = 0;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Image = global::VentasSys.Properties.Resources.search;
            this.btnBuscarCliente.Location = new System.Drawing.Point(391, 156);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarCliente.TabIndex = 109;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtDesCliente
            // 
            this.txtDesCliente.Location = new System.Drawing.Point(138, 158);
            this.txtDesCliente.Name = "txtDesCliente";
            this.txtDesCliente.Size = new System.Drawing.Size(250, 20);
            this.txtDesCliente.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 107;
            this.label10.Text = "Cliente / Razón Social";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Red;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(402, 31);
            this.label2.TabIndex = 114;
            this.label2.Text = "Formulario de Mantenimiento";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFechaEmision
            // 
            this.txtFechaEmision.BackColor = System.Drawing.Color.DarkTurquoise;
            this.txtFechaEmision.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaEmision.ForeColor = System.Drawing.Color.White;
            this.txtFechaEmision.Location = new System.Drawing.Point(293, 47);
            this.txtFechaEmision.Name = "txtFechaEmision";
            this.txtFechaEmision.Size = new System.Drawing.Size(121, 29);
            this.txtFechaEmision.TabIndex = 115;
            this.txtFechaEmision.Text = "30/06/2017";
            this.txtFechaEmision.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 116;
            this.label1.Text = "Tipo Mantenimiento";
            // 
            // cboMantenimiento
            // 
            this.cboMantenimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMantenimiento.FormattingEnabled = true;
            this.cboMantenimiento.Location = new System.Drawing.Point(138, 187);
            this.cboMantenimiento.Name = "cboMantenimiento";
            this.cboMantenimiento.Size = new System.Drawing.Size(250, 21);
            this.cboMantenimiento.TabIndex = 4;
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(138, 368);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(276, 21);
            this.cboEstado.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 118;
            this.label3.Text = "Estado";
            // 
            // dgvMantenimiento
            // 
            this.dgvMantenimiento.AllowUserToAddRows = false;
            this.dgvMantenimiento.AllowUserToDeleteRows = false;
            this.dgvMantenimiento.AllowUserToResizeColumns = false;
            this.dgvMantenimiento.AllowUserToResizeRows = false;
            this.dgvMantenimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMantenimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DESCRIPCION,
            this.DELETE});
            this.dgvMantenimiento.Location = new System.Drawing.Point(12, 214);
            this.dgvMantenimiento.Name = "dgvMantenimiento";
            this.dgvMantenimiento.ReadOnly = true;
            this.dgvMantenimiento.RowHeadersVisible = false;
            this.dgvMantenimiento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMantenimiento.ShowEditingIcon = false;
            this.dgvMantenimiento.Size = new System.Drawing.Size(402, 119);
            this.dgvMantenimiento.TabIndex = 120;
            this.dgvMantenimiento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMantenimiento_CellContentClick);
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPagar.FlatAppearance.BorderSize = 0;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.Image = global::VentasSys.Properties.Resources.save_white_24x24;
            this.btnPagar.Location = new System.Drawing.Point(138, 395);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(127, 48);
            this.btnPagar.TabIndex = 7;
            this.btnPagar.Text = "   &Guardar";
            this.btnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbEmpresa);
            this.groupBox1.Controls.Add(this.rdbPersona);
            this.groupBox1.Location = new System.Drawing.Point(12, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 44);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            // 
            // rdbEmpresa
            // 
            this.rdbEmpresa.AutoSize = true;
            this.rdbEmpresa.Location = new System.Drawing.Point(196, 16);
            this.rdbEmpresa.Name = "rdbEmpresa";
            this.rdbEmpresa.Size = new System.Drawing.Size(66, 17);
            this.rdbEmpresa.TabIndex = 1;
            this.rdbEmpresa.TabStop = true;
            this.rdbEmpresa.Text = "Empresa";
            this.rdbEmpresa.UseVisualStyleBackColor = true;
            // 
            // rdbPersona
            // 
            this.rdbPersona.AutoSize = true;
            this.rdbPersona.Location = new System.Drawing.Point(126, 16);
            this.rdbPersona.Name = "rdbPersona";
            this.rdbPersona.Size = new System.Drawing.Size(64, 17);
            this.rdbPersona.TabIndex = 0;
            this.rdbPersona.TabStop = true;
            this.rdbPersona.Text = "Persona";
            this.rdbPersona.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 124;
            this.label4.Text = "Nro. Documento";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSerie
            // 
            this.lblSerie.BackColor = System.Drawing.Color.Red;
            this.lblSerie.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.ForeColor = System.Drawing.Color.White;
            this.lblSerie.Location = new System.Drawing.Point(104, 47);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(158, 29);
            this.lblSerie.TabIndex = 123;
            this.lblSerie.Text = "N° 001-000000";
            this.lblSerie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 125;
            this.label5.Text = "Fecha de Salida";
            // 
            // dtpFechaSalida
            // 
            this.dtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaSalida.Location = new System.Drawing.Point(138, 339);
            this.dtpFechaSalida.Name = "dtpFechaSalida";
            this.dtpFechaSalida.Size = new System.Drawing.Size(127, 20);
            this.dtpFechaSalida.TabIndex = 5;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.HeaderText = "Descripción";
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.ReadOnly = true;
            this.DESCRIPCION.Width = 382;
            // 
            // DELETE
            // 
            this.DELETE.HeaderText = "";
            this.DELETE.Image = global::VentasSys.Properties.Resources.sign_delete_icon;
            this.DELETE.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.DELETE.Name = "DELETE";
            this.DELETE.ReadOnly = true;
            this.DELETE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DELETE.Width = 20;
            // 
            // frmProgMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(426, 454);
            this.Controls.Add(this.dtpFechaSalida);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSerie);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.dgvMantenimiento);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboMantenimiento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFechaEmision);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNuevoCliente);
            this.Controls.Add(this.btnBuscarRuc);
            this.Controls.Add(this.txtDesRuc);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.txtDesCliente);
            this.Controls.Add(this.label10);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProgMantenimiento";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Programar Manteminiento";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMantenimiento)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.Button btnBuscarRuc;
        private System.Windows.Forms.TextBox txtDesRuc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtDesCliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtFechaEmision;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMantenimiento;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvMantenimiento;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbEmpresa;
        private System.Windows.Forms.RadioButton rdbPersona;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION;
        private System.Windows.Forms.DataGridViewImageColumn DELETE;
    }
}