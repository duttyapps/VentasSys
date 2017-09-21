namespace VentasSys
{
    partial class frmAnularVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDocumentos = new System.Windows.Forms.DataGridView();
            this.NUMERO_DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_CAB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_VENTA_DES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FORMA_PAGO_DES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTO_RECIBIDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTO_VUELTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTO_TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroDocumento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipoVenta = new System.Windows.Forms.ComboBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.PRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.gbDetalle = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblRecibido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.lblTipoVenta = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.gbDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDocumentos
            // 
            this.dgvDocumentos.AllowUserToAddRows = false;
            this.dgvDocumentos.AllowUserToDeleteRows = false;
            this.dgvDocumentos.AllowUserToResizeColumns = false;
            this.dgvDocumentos.AllowUserToResizeRows = false;
            this.dgvDocumentos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocumentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocumentos.ColumnHeadersHeight = 30;
            this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NUMERO_DOC,
            this.ID_CAB,
            this.TIPO_VENTA_DES,
            this.FORMA_PAGO_DES,
            this.FECHA,
            this.USUARIO,
            this.DNI,
            this.NOMBRE,
            this.MONTO_RECIBIDO,
            this.MONTO_VUELTO,
            this.MONTO_TOTAL});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocumentos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDocumentos.GridColor = System.Drawing.Color.White;
            this.dgvDocumentos.Location = new System.Drawing.Point(12, 47);
            this.dgvDocumentos.MultiSelect = false;
            this.dgvDocumentos.Name = "dgvDocumentos";
            this.dgvDocumentos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocumentos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDocumentos.RowHeadersVisible = false;
            this.dgvDocumentos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDocumentos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocumentos.Size = new System.Drawing.Size(150, 230);
            this.dgvDocumentos.TabIndex = 0;
            this.dgvDocumentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentos_CellClick);
            // 
            // NUMERO_DOC
            // 
            this.NUMERO_DOC.DataPropertyName = "nro_doc_str";
            this.NUMERO_DOC.HeaderText = "Nro. Documento";
            this.NUMERO_DOC.Name = "NUMERO_DOC";
            this.NUMERO_DOC.ReadOnly = true;
            this.NUMERO_DOC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NUMERO_DOC.Width = 147;
            // 
            // ID_CAB
            // 
            this.ID_CAB.DataPropertyName = "id_cab";
            this.ID_CAB.HeaderText = "ID_CAB";
            this.ID_CAB.Name = "ID_CAB";
            this.ID_CAB.ReadOnly = true;
            this.ID_CAB.Visible = false;
            // 
            // TIPO_VENTA_DES
            // 
            this.TIPO_VENTA_DES.DataPropertyName = "tipo_venta_des";
            this.TIPO_VENTA_DES.HeaderText = "TIPO_VENTA_DES";
            this.TIPO_VENTA_DES.Name = "TIPO_VENTA_DES";
            this.TIPO_VENTA_DES.ReadOnly = true;
            this.TIPO_VENTA_DES.Visible = false;
            // 
            // FORMA_PAGO_DES
            // 
            this.FORMA_PAGO_DES.DataPropertyName = "forma_pago_des";
            this.FORMA_PAGO_DES.HeaderText = "FORMA_PAGO_DES";
            this.FORMA_PAGO_DES.Name = "FORMA_PAGO_DES";
            this.FORMA_PAGO_DES.ReadOnly = true;
            this.FORMA_PAGO_DES.Visible = false;
            // 
            // FECHA
            // 
            this.FECHA.DataPropertyName = "emision";
            this.FECHA.HeaderText = "FECHA";
            this.FECHA.Name = "FECHA";
            this.FECHA.ReadOnly = true;
            this.FECHA.Visible = false;
            // 
            // USUARIO
            // 
            this.USUARIO.DataPropertyName = "usuario";
            this.USUARIO.HeaderText = "USUARIO";
            this.USUARIO.Name = "USUARIO";
            this.USUARIO.ReadOnly = true;
            this.USUARIO.Visible = false;
            // 
            // DNI
            // 
            this.DNI.DataPropertyName = "cliente_doc";
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            this.DNI.Visible = false;
            // 
            // NOMBRE
            // 
            this.NOMBRE.DataPropertyName = "cliente";
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            this.NOMBRE.Visible = false;
            // 
            // MONTO_RECIBIDO
            // 
            this.MONTO_RECIBIDO.DataPropertyName = "monto_recibido";
            this.MONTO_RECIBIDO.HeaderText = "MONTO_RECIBIDO";
            this.MONTO_RECIBIDO.Name = "MONTO_RECIBIDO";
            this.MONTO_RECIBIDO.ReadOnly = true;
            this.MONTO_RECIBIDO.Visible = false;
            // 
            // MONTO_VUELTO
            // 
            this.MONTO_VUELTO.DataPropertyName = "monto_vuelto";
            this.MONTO_VUELTO.HeaderText = "MONTO_VUELTO";
            this.MONTO_VUELTO.Name = "MONTO_VUELTO";
            this.MONTO_VUELTO.ReadOnly = true;
            this.MONTO_VUELTO.Visible = false;
            // 
            // MONTO_TOTAL
            // 
            this.MONTO_TOTAL.DataPropertyName = "monto_total";
            this.MONTO_TOTAL.HeaderText = "MONTO_TOTAL";
            this.MONTO_TOTAL.Name = "MONTO_TOTAL";
            this.MONTO_TOTAL.ReadOnly = true;
            this.MONTO_TOTAL.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nro. Documento:";
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Location = new System.Drawing.Point(348, 13);
            this.txtNroDocumento.MaxLength = 14;
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new System.Drawing.Size(131, 21);
            this.txtNroDocumento.TabIndex = 2;
            this.txtNroDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroDocumento_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo Venta:";
            // 
            // cboTipoVenta
            // 
            this.cboTipoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoVenta.FormattingEnabled = true;
            this.cboTipoVenta.Location = new System.Drawing.Point(86, 13);
            this.cboTipoVenta.Name = "cboTipoVenta";
            this.cboTipoVenta.Size = new System.Drawing.Size(130, 23);
            this.cboTipoVenta.TabIndex = 4;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeColumns = false;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetalle.ColumnHeadersHeight = 30;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRODUCTO,
            this.CANTIDAD,
            this.PU,
            this.TOTAL});
            this.dgvDetalle.GridColor = System.Drawing.Color.White;
            this.dgvDetalle.Location = new System.Drawing.Point(168, 47);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(400, 230);
            this.dgvDetalle.TabIndex = 5;
            // 
            // PRODUCTO
            // 
            this.PRODUCTO.DataPropertyName = "nombre";
            this.PRODUCTO.Frozen = true;
            this.PRODUCTO.HeaderText = "Producto";
            this.PRODUCTO.Name = "PRODUCTO";
            this.PRODUCTO.ReadOnly = true;
            this.PRODUCTO.Width = 220;
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.DataPropertyName = "cantidad";
            this.CANTIDAD.Frozen = true;
            this.CANTIDAD.HeaderText = "Cant.";
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.ReadOnly = true;
            this.CANTIDAD.Width = 60;
            // 
            // PU
            // 
            this.PU.DataPropertyName = "precio";
            this.PU.Frozen = true;
            this.PU.HeaderText = "P.U.";
            this.PU.Name = "PU";
            this.PU.ReadOnly = true;
            this.PU.Width = 60;
            // 
            // TOTAL
            // 
            this.TOTAL.DataPropertyName = "monto_total";
            this.TOTAL.Frozen = true;
            this.TOTAL.HeaderText = "Total";
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.ReadOnly = true;
            this.TOTAL.Width = 60;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(493, 11);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 24);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.BackColor = System.Drawing.Color.Red;
            this.btnAnular.Enabled = false;
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.ForeColor = System.Drawing.Color.White;
            this.btnAnular.Location = new System.Drawing.Point(643, 283);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(164, 40);
            this.btnAnular.TabIndex = 39;
            this.btnAnular.Text = "Anular Documento";
            this.btnAnular.UseVisualStyleBackColor = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.TabIndex = 40;
            this.label3.Text = "Motivo Anulación:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(12, 302);
            this.txtMotivo.MaxLength = 100;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(556, 21);
            this.txtMotivo.TabIndex = 41;
            // 
            // gbDetalle
            // 
            this.gbDetalle.Controls.Add(this.lblTotal);
            this.gbDetalle.Controls.Add(this.label);
            this.gbDetalle.Controls.Add(this.lblVuelto);
            this.gbDetalle.Controls.Add(this.label9);
            this.gbDetalle.Controls.Add(this.lblRecibido);
            this.gbDetalle.Controls.Add(this.lblNombre);
            this.gbDetalle.Controls.Add(this.lblDNI);
            this.gbDetalle.Controls.Add(this.label13);
            this.gbDetalle.Controls.Add(this.label14);
            this.gbDetalle.Controls.Add(this.label15);
            this.gbDetalle.Controls.Add(this.lblUsuario);
            this.gbDetalle.Controls.Add(this.label7);
            this.gbDetalle.Controls.Add(this.lblFecha);
            this.gbDetalle.Controls.Add(this.lblFormaPago);
            this.gbDetalle.Controls.Add(this.lblTipoVenta);
            this.gbDetalle.Controls.Add(this.label6);
            this.gbDetalle.Controls.Add(this.label5);
            this.gbDetalle.Controls.Add(this.label4);
            this.gbDetalle.Location = new System.Drawing.Point(574, 8);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(295, 269);
            this.gbDetalle.TabIndex = 42;
            this.gbDetalle.TabStop = false;
            this.gbDetalle.Text = "Detalle de la Venta";
            this.gbDetalle.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(119, 236);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(12, 15);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "-";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label.Location = new System.Drawing.Point(6, 234);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(87, 15);
            this.label.TabIndex = 16;
            this.label.Text = "Monto Total:";
            // 
            // lblVuelto
            // 
            this.lblVuelto.AutoSize = true;
            this.lblVuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVuelto.Location = new System.Drawing.Point(119, 209);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(12, 15);
            this.lblVuelto.TabIndex = 15;
            this.lblVuelto.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "Vuelto/Restante:";
            // 
            // lblRecibido
            // 
            this.lblRecibido.AutoSize = true;
            this.lblRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecibido.Location = new System.Drawing.Point(119, 185);
            this.lblRecibido.Name = "lblRecibido";
            this.lblRecibido.Size = new System.Drawing.Size(12, 15);
            this.lblRecibido.TabIndex = 13;
            this.lblRecibido.Text = "-";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(119, 161);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(12, 15);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "-";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNI.Location = new System.Drawing.Point(119, 136);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(12, 15);
            this.lblDNI.TabIndex = 11;
            this.lblDNI.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 185);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 15);
            this.label13.TabIndex = 10;
            this.label13.Text = "Monto Recibido:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 161);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 15);
            this.label14.TabIndex = 9;
            this.label14.Text = "Nombre/R. Social:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 15);
            this.label15.TabIndex = 8;
            this.label15.Text = "DNI/RUC:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(119, 112);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(12, 15);
            this.lblUsuario.TabIndex = 7;
            this.lblUsuario.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Cajero:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(119, 88);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(12, 15);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "-";
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaPago.Location = new System.Drawing.Point(119, 64);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(12, 15);
            this.lblFormaPago.TabIndex = 4;
            this.lblFormaPago.Text = "-";
            // 
            // lblTipoVenta
            // 
            this.lblTipoVenta.AutoSize = true;
            this.lblTipoVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoVenta.Location = new System.Drawing.Point(119, 39);
            this.lblTipoVenta.Name = "lblTipoVenta";
            this.lblTipoVenta.Size = new System.Drawing.Size(12, 15);
            this.lblTipoVenta.TabIndex = 3;
            this.lblTipoVenta.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Fecha Emisión:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Forma de Pago:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tipo Venta:";
            // 
            // frmAnularVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 337);
            this.Controls.Add(this.gbDetalle);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.cboTipoVenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNroDocumento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDocumentos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAnularVenta";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Anular Venta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.gbDetalle.ResumeLayout(false);
            this.gbDetalle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocumentos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipoVenta;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PU;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.GroupBox gbDetalle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTipoVenta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblVuelto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblRecibido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO_DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_CAB;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_VENTA_DES;
        private System.Windows.Forms.DataGridViewTextBoxColumn FORMA_PAGO_DES;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTO_RECIBIDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTO_VUELTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTO_TOTAL;
    }
}