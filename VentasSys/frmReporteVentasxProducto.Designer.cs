namespace VentasSys
{
    partial class frmReporteVentasxProducto
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFecha = new System.Windows.Forms.DateTimePicker();
            this.rbFecha = new System.Windows.Forms.RadioButton();
            this.rbMesYear = new System.Windows.Forms.RadioButton();
            this.cboTiendas = new System.Windows.Forms.ComboBox();
            this.txtMes = new System.Windows.Forms.DateTimePicker();
            this.txtYear = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rvVentasProductos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cboCategoria);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtYear);
            this.groupBox1.Controls.Add(this.txtMes);
            this.groupBox1.Controls.Add(this.cboTiendas);
            this.groupBox1.Controls.Add(this.rbMesYear);
            this.groupBox1.Controls.Add(this.rbFecha);
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(950, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar";
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha.Location = new System.Drawing.Point(90, 21);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(121, 22);
            this.txtFecha.TabIndex = 0;
            // 
            // rbFecha
            // 
            this.rbFecha.AutoSize = true;
            this.rbFecha.Checked = true;
            this.rbFecha.Location = new System.Drawing.Point(6, 26);
            this.rbFecha.Name = "rbFecha";
            this.rbFecha.Size = new System.Drawing.Size(55, 17);
            this.rbFecha.TabIndex = 1;
            this.rbFecha.TabStop = true;
            this.rbFecha.Text = "Fecha";
            this.rbFecha.UseVisualStyleBackColor = true;
            this.rbFecha.CheckedChanged += new System.EventHandler(this.rbFecha_CheckedChanged);
            // 
            // rbMesYear
            // 
            this.rbMesYear.AutoSize = true;
            this.rbMesYear.Location = new System.Drawing.Point(6, 51);
            this.rbMesYear.Name = "rbMesYear";
            this.rbMesYear.Size = new System.Drawing.Size(78, 17);
            this.rbMesYear.TabIndex = 2;
            this.rbMesYear.Text = "Mes y Año";
            this.rbMesYear.UseVisualStyleBackColor = true;
            this.rbMesYear.CheckedChanged += new System.EventHandler(this.rbMesYear_CheckedChanged);
            // 
            // cboTiendas
            // 
            this.cboTiendas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTiendas.FormattingEnabled = true;
            this.cboTiendas.Location = new System.Drawing.Point(362, 25);
            this.cboTiendas.Name = "cboTiendas";
            this.cboTiendas.Size = new System.Drawing.Size(121, 21);
            this.cboTiendas.TabIndex = 3;
            // 
            // txtMes
            // 
            this.txtMes.Enabled = false;
            this.txtMes.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtMes.Location = new System.Drawing.Point(90, 49);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(84, 22);
            this.txtMes.TabIndex = 5;
            // 
            // txtYear
            // 
            this.txtYear.Enabled = false;
            this.txtYear.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtYear.Location = new System.Drawing.Point(180, 49);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(68, 22);
            this.txtYear.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tienda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Categorías";
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(362, 50);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(121, 21);
            this.cboCategoria.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(509, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 38);
            this.button1.TabIndex = 10;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // rvVentasProductos
            // 
            this.rvVentasProductos.Location = new System.Drawing.Point(12, 102);
            this.rvVentasProductos.Name = "rvVentasProductos";
            this.rvVentasProductos.Size = new System.Drawing.Size(950, 559);
            this.rvVentasProductos.TabIndex = 1;
            // 
            // frmReporteVentasxProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(974, 673);
            this.Controls.Add(this.rvVentasProductos);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReporteVentasxProducto";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "REPORTE - Ventas por Producto";
            this.Load += new System.EventHandler(this.frmReporteVentasxProducto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTiendas;
        private System.Windows.Forms.RadioButton rbMesYear;
        private System.Windows.Forms.RadioButton rbFecha;
        private System.Windows.Forms.DateTimePicker txtFecha;
        private System.Windows.Forms.DateTimePicker txtMes;
        private System.Windows.Forms.DateTimePicker txtYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer rvVentasProductos;
    }
}