namespace VentasSys
{
    partial class frmGuiaRemision
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblRUC = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNroDoc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFechaTraslado = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDireccionPartida = new System.Windows.Forms.TextBox();
            this.txtFechaEmision = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTransRuc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTransCliente = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDireccionLlegada = new System.Windows.Forms.TextBox();
            this.btnBuscarRuc = new System.Windows.Forms.Button();
            this.txtDesRuc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtDesCliente = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboNroDocumento = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETALLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEDIDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lstMotivos = new System.Windows.Forms.CheckedListBox();
            this.btnEmitir = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRUC
            // 
            this.lblRUC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRUC.Location = new System.Drawing.Point(730, 196);
            this.lblRUC.Name = "lblRUC";
            this.lblRUC.Size = new System.Drawing.Size(257, 21);
            this.lblRUC.TabIndex = 28;
            this.lblRUC.Text = "R.U.C. 20132354124";
            this.lblRUC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLogo
            // 
            this.pbLogo.Location = new System.Drawing.Point(730, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(257, 116);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 30;
            this.pbLogo.TabStop = false;
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazonSocial.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblRazonSocial.Location = new System.Drawing.Point(730, 131);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(257, 47);
            this.lblRazonSocial.TabIndex = 29;
            this.lblRazonSocial.Text = "DuttyApps.com";
            this.lblRazonSocial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNroDoc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 62);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.BackColor = System.Drawing.Color.Red;
            this.lblNroDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNroDoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroDoc.ForeColor = System.Drawing.Color.White;
            this.lblNroDoc.Location = new System.Drawing.Point(554, 18);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Padding = new System.Windows.Forms.Padding(5);
            this.lblNroDoc.Size = new System.Drawing.Size(107, 31);
            this.lblNroDoc.TabIndex = 35;
            this.lblNroDoc.Text = "001-000000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(437, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 34;
            this.label4.Text = "Nro. Documento";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Red;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(145, 18);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(223, 31);
            this.label2.TabIndex = 33;
            this.label2.Text = "Guía Remisión - Remitente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "Tipo Documento";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFechaTraslado);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDireccionPartida);
            this.groupBox2.Controls.Add(this.txtFechaEmision);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(712, 83);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // txtFechaTraslado
            // 
            this.txtFechaTraslado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaTraslado.Location = new System.Drawing.Point(564, 21);
            this.txtFechaTraslado.Name = "txtFechaTraslado";
            this.txtFechaTraslado.Size = new System.Drawing.Size(105, 22);
            this.txtFechaTraslado.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(460, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Fecha de Traslado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Dirección de Partida";
            // 
            // txtDireccionPartida
            // 
            this.txtDireccionPartida.Location = new System.Drawing.Point(131, 49);
            this.txtDireccionPartida.Name = "txtDireccionPartida";
            this.txtDireccionPartida.ReadOnly = true;
            this.txtDireccionPartida.Size = new System.Drawing.Size(538, 22);
            this.txtDireccionPartida.TabIndex = 2;
            // 
            // txtFechaEmision
            // 
            this.txtFechaEmision.Location = new System.Drawing.Point(131, 21);
            this.txtFechaEmision.Name = "txtFechaEmision";
            this.txtFechaEmision.ReadOnly = true;
            this.txtFechaEmision.Size = new System.Drawing.Size(108, 22);
            this.txtFechaEmision.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Fecha Emisión";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTransRuc);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtTransCliente);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(12, 169);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(712, 58);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transportista";
            // 
            // txtTransRuc
            // 
            this.txtTransRuc.Location = new System.Drawing.Point(493, 21);
            this.txtTransRuc.Name = "txtTransRuc";
            this.txtTransRuc.ReadOnly = true;
            this.txtTransRuc.Size = new System.Drawing.Size(176, 22);
            this.txtTransRuc.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(458, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "RUC";
            // 
            // txtTransCliente
            // 
            this.txtTransCliente.Location = new System.Drawing.Point(131, 21);
            this.txtTransCliente.Name = "txtTransCliente";
            this.txtTransCliente.ReadOnly = true;
            this.txtTransCliente.Size = new System.Drawing.Size(269, 22);
            this.txtTransCliente.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cliente / Razón Social";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtDireccionLlegada);
            this.groupBox4.Controls.Add(this.btnBuscarRuc);
            this.groupBox4.Controls.Add(this.txtDesRuc);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.btnBuscarCliente);
            this.groupBox4.Controls.Add(this.txtDesCliente);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(12, 233);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(975, 85);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Destinatario";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 13);
            this.label12.TabIndex = 105;
            this.label12.Text = "Dirección de Llegada";
            // 
            // txtDireccionLlegada
            // 
            this.txtDireccionLlegada.Location = new System.Drawing.Point(131, 49);
            this.txtDireccionLlegada.Name = "txtDireccionLlegada";
            this.txtDireccionLlegada.Size = new System.Drawing.Size(797, 22);
            this.txtDireccionLlegada.TabIndex = 104;
            // 
            // btnBuscarRuc
            // 
            this.btnBuscarRuc.FlatAppearance.BorderSize = 0;
            this.btnBuscarRuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarRuc.Image = global::VentasSys.Properties.Resources.search;
            this.btnBuscarRuc.Location = new System.Drawing.Point(934, 19);
            this.btnBuscarRuc.Name = "btnBuscarRuc";
            this.btnBuscarRuc.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarRuc.TabIndex = 103;
            this.btnBuscarRuc.UseVisualStyleBackColor = true;
            this.btnBuscarRuc.Click += new System.EventHandler(this.btnBuscarRuc_Click);
            // 
            // txtDesRuc
            // 
            this.txtDesRuc.Location = new System.Drawing.Point(752, 20);
            this.txtDesRuc.Name = "txtDesRuc";
            this.txtDesRuc.Size = new System.Drawing.Size(176, 22);
            this.txtDesRuc.TabIndex = 102;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(717, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 101;
            this.label11.Text = "RUC";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.FlatAppearance.BorderSize = 0;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Image = global::VentasSys.Properties.Resources.search;
            this.btnBuscarCliente.Location = new System.Drawing.Point(595, 21);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarCliente.TabIndex = 100;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtDesCliente
            // 
            this.txtDesCliente.Location = new System.Drawing.Point(131, 21);
            this.txtDesCliente.Name = "txtDesCliente";
            this.txtDesCliente.Size = new System.Drawing.Size(458, 22);
            this.txtDesCliente.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Cliente / Razón Social";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboNroDocumento);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.cboTipoDocumento);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.dgvProductos);
            this.groupBox5.Location = new System.Drawing.Point(12, 324);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(618, 285);
            this.groupBox5.TabIndex = 35;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Comprobante de Pago";
            // 
            // cboNroDocumento
            // 
            this.cboNroDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNroDocumento.FormattingEnabled = true;
            this.cboNroDocumento.Location = new System.Drawing.Point(360, 21);
            this.cboNroDocumento.Name = "cboNroDocumento";
            this.cboNroDocumento.Size = new System.Drawing.Size(149, 21);
            this.cboNroDocumento.TabIndex = 7;
            this.cboNroDocumento.SelectedIndexChanged += new System.EventHandler(this.cboNroDocumento_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(262, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Nro. Documento";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(104, 21);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(121, 21);
            this.cboTipoDocumento.TabIndex = 5;
            this.cboTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.cboTipoDocumento_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Tipo Documento";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToResizeColumns = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODIGO,
            this.DETALLE,
            this.CANTIDAD,
            this.MEDIDA,
            this.PESO});
            this.dgvProductos.Location = new System.Drawing.Point(10, 48);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.Size = new System.Drawing.Size(600, 231);
            this.dgvProductos.TabIndex = 0;
            // 
            // CODIGO
            // 
            this.CODIGO.DataPropertyName = "cod_producto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CODIGO.DefaultCellStyle = dataGridViewCellStyle1;
            this.CODIGO.Frozen = true;
            this.CODIGO.HeaderText = "Código";
            this.CODIGO.Name = "CODIGO";
            this.CODIGO.ReadOnly = true;
            // 
            // DETALLE
            // 
            this.DETALLE.DataPropertyName = "nombre";
            this.DETALLE.Frozen = true;
            this.DETALLE.HeaderText = "Detalle";
            this.DETALLE.Name = "DETALLE";
            this.DETALLE.ReadOnly = true;
            this.DETALLE.Width = 200;
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.DataPropertyName = "cantidad";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CANTIDAD.DefaultCellStyle = dataGridViewCellStyle2;
            this.CANTIDAD.Frozen = true;
            this.CANTIDAD.HeaderText = "Cantidad";
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.ReadOnly = true;
            // 
            // MEDIDA
            // 
            this.MEDIDA.DataPropertyName = "medida";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.MEDIDA.DefaultCellStyle = dataGridViewCellStyle3;
            this.MEDIDA.Frozen = true;
            this.MEDIDA.HeaderText = "Unid. Medida";
            this.MEDIDA.Name = "MEDIDA";
            this.MEDIDA.ReadOnly = true;
            // 
            // PESO
            // 
            this.PESO.DataPropertyName = "peso";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PESO.DefaultCellStyle = dataGridViewCellStyle4;
            this.PESO.Frozen = true;
            this.PESO.HeaderText = "Peso";
            this.PESO.Name = "PESO";
            this.PESO.ReadOnly = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lstMotivos);
            this.groupBox6.Location = new System.Drawing.Point(636, 324);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(351, 285);
            this.groupBox6.TabIndex = 36;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Motivo Traslado";
            // 
            // lstMotivos
            // 
            this.lstMotivos.CheckOnClick = true;
            this.lstMotivos.FormattingEnabled = true;
            this.lstMotivos.Location = new System.Drawing.Point(6, 21);
            this.lstMotivos.Name = "lstMotivos";
            this.lstMotivos.Size = new System.Drawing.Size(339, 259);
            this.lstMotivos.TabIndex = 0;
            this.lstMotivos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstMotivos_ItemCheck);
            // 
            // btnEmitir
            // 
            this.btnEmitir.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEmitir.FlatAppearance.BorderSize = 0;
            this.btnEmitir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmitir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmitir.ForeColor = System.Drawing.Color.White;
            this.btnEmitir.Image = global::VentasSys.Properties.Resources.save_white_24x24;
            this.btnEmitir.Location = new System.Drawing.Point(737, 615);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(179, 55);
            this.btnEmitir.TabIndex = 37;
            this.btnEmitir.Text = "   &Emitir Guía";
            this.btnEmitir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmitir.UseVisualStyleBackColor = false;
            this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnReiniciar.FlatAppearance.BorderSize = 0;
            this.btnReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.ForeColor = System.Drawing.Color.White;
            this.btnReiniciar.Image = global::VentasSys.Properties.Resources.Reset_24;
            this.btnReiniciar.Location = new System.Drawing.Point(185, 615);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(163, 55);
            this.btnReiniciar.TabIndex = 38;
            this.btnReiniciar.Text = "   &Reiniciar Guía";
            this.btnReiniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReiniciar.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.DimGray;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = global::VentasSys.Properties.Resources.Exit_24;
            this.btnSalir.Location = new System.Drawing.Point(12, 615);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(167, 55);
            this.btnSalir.TabIndex = 39;
            this.btnSalir.Text = "   &Cerrar Ventana";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmGuiaRemision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(999, 680);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnEmitir);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblRUC);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lblRazonSocial);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGuiaRemision";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Guía de Remisión";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRUC;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNroDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtFechaTraslado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDireccionPartida;
        private System.Windows.Forms.TextBox txtFechaEmision;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTransRuc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTransCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtDesCliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDireccionLlegada;
        private System.Windows.Forms.Button btnBuscarRuc;
        private System.Windows.Forms.TextBox txtDesRuc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cboNroDocumento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckedListBox lstMotivos;
        private System.Windows.Forms.Button btnEmitir;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETALLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDIDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PESO;
    }
}