namespace VentasSys
{
    partial class frmAlquiler
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
            this.dtHoraDev = new System.Windows.Forms.DateTimePicker();
            this.dtFechaDev = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAlquilar = new System.Windows.Forms.Button();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtHoraEnt = new System.Windows.Forms.DateTimePicker();
            this.dtFechaEnt = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtHoraDev);
            this.groupBox1.Controls.Add(this.dtFechaDev);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnAlquilar);
            this.groupBox1.Controls.Add(this.txtDetalle);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtHoraEnt);
            this.groupBox1.Controls.Add(this.dtFechaEnt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 310);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información";
            // 
            // dtHoraDev
            // 
            this.dtHoraDev.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtHoraDev.Location = new System.Drawing.Point(276, 42);
            this.dtHoraDev.Name = "dtHoraDev";
            this.dtHoraDev.Size = new System.Drawing.Size(73, 20);
            this.dtHoraDev.TabIndex = 12;
            // 
            // dtFechaDev
            // 
            this.dtFechaDev.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaDev.Location = new System.Drawing.Point(191, 42);
            this.dtFechaDev.Name = "dtFechaDev";
            this.dtFechaDev.Size = new System.Drawing.Size(79, 20);
            this.dtFechaDev.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha y Hora de Devolución";
            // 
            // btnAlquilar
            // 
            this.btnAlquilar.BackColor = System.Drawing.Color.Green;
            this.btnAlquilar.FlatAppearance.BorderSize = 0;
            this.btnAlquilar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlquilar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlquilar.ForeColor = System.Drawing.Color.White;
            this.btnAlquilar.Image = global::VentasSys.Properties.Resources.save_white_24x24;
            this.btnAlquilar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlquilar.Location = new System.Drawing.Point(117, 250);
            this.btnAlquilar.Name = "btnAlquilar";
            this.btnAlquilar.Size = new System.Drawing.Size(111, 45);
            this.btnAlquilar.TabIndex = 9;
            this.btnAlquilar.Text = "&Alquilar";
            this.btnAlquilar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlquilar.UseVisualStyleBackColor = false;
            this.btnAlquilar.Click += new System.EventHandler(this.btnAlquilar_Click);
            // 
            // txtDetalle
            // 
            this.txtDetalle.Location = new System.Drawing.Point(6, 141);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(343, 89);
            this.txtDetalle.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Detalle del Alquiler";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(6, 92);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(343, 20);
            this.txtCliente.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cliente";
            // 
            // dtHoraEnt
            // 
            this.dtHoraEnt.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtHoraEnt.Location = new System.Drawing.Point(91, 42);
            this.dtHoraEnt.Name = "dtHoraEnt";
            this.dtHoraEnt.Size = new System.Drawing.Size(73, 20);
            this.dtHoraEnt.TabIndex = 2;
            // 
            // dtFechaEnt
            // 
            this.dtFechaEnt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaEnt.Location = new System.Drawing.Point(6, 42);
            this.dtFechaEnt.Name = "dtFechaEnt";
            this.dtFechaEnt.Size = new System.Drawing.Size(79, 20);
            this.dtFechaEnt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha y Hora de Entrega";
            // 
            // frmAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(379, 334);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frmAlquiler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alquiler";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtHoraEnt;
        private System.Windows.Forms.DateTimePicker dtFechaEnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAlquilar;
        private System.Windows.Forms.DateTimePicker dtHoraDev;
        private System.Windows.Forms.DateTimePicker dtFechaDev;
        private System.Windows.Forms.Label label5;
    }
}