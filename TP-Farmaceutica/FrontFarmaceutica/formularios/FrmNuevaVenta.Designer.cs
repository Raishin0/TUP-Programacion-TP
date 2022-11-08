namespace FrontFarmaceutica.formularios
{
    partial class FrmNuevaVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevaVenta));
            this.LblFactura = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TbxCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.CbxArticulos = new System.Windows.Forms.ComboBox();
            this.TbxCantidad = new System.Windows.Forms.TextBox();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.DgvDetalles = new System.Windows.Forms.DataGridView();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.TbxTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CbxFormaPago = new System.Windows.Forms.ComboBox();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.CbxObrasSociales = new System.Windows.Forms.ComboBox();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkCubierto = new System.Windows.Forms.CheckBox();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cubierto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // LblFactura
            // 
            this.LblFactura.AutoSize = true;
            this.LblFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblFactura.ForeColor = System.Drawing.Color.White;
            this.LblFactura.Location = new System.Drawing.Point(42, 20);
            this.LblFactura.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblFactura.Name = "LblFactura";
            this.LblFactura.Size = new System.Drawing.Size(130, 31);
            this.LblFactura.TabIndex = 0;
            this.LblFactura.Text = "Venta Nº";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(56, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha";
            // 
            // TbxCliente
            // 
            this.TbxCliente.Location = new System.Drawing.Point(104, 128);
            this.TbxCliente.Margin = new System.Windows.Forms.Padding(4);
            this.TbxCliente.Name = "TbxCliente";
            this.TbxCliente.Size = new System.Drawing.Size(140, 23);
            this.TbxCliente.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(49, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cliente";
            // 
            // DtpFecha
            // 
            this.DtpFecha.CalendarForeColor = System.Drawing.Color.White;
            this.DtpFecha.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(167)))), ((int)(((byte)(41)))));
            this.DtpFecha.Enabled = false;
            this.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFecha.Location = new System.Drawing.Point(104, 80);
            this.DtpFecha.Margin = new System.Windows.Forms.Padding(4);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(137, 23);
            this.DtpFecha.TabIndex = 0;
            // 
            // CbxArticulos
            // 
            this.CbxArticulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxArticulos.FormattingEnabled = true;
            this.CbxArticulos.Location = new System.Drawing.Point(104, 188);
            this.CbxArticulos.Margin = new System.Windows.Forms.Padding(4);
            this.CbxArticulos.Name = "CbxArticulos";
            this.CbxArticulos.Size = new System.Drawing.Size(168, 23);
            this.CbxArticulos.TabIndex = 4;
            this.CbxArticulos.SelectedIndexChanged += new System.EventHandler(this.CbxArticulos_SelectedIndexChanged);
            // 
            // TbxCantidad
            // 
            this.TbxCantidad.Location = new System.Drawing.Point(380, 188);
            this.TbxCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.TbxCantidad.Name = "TbxCantidad";
            this.TbxCantidad.Size = new System.Drawing.Size(64, 23);
            this.TbxCantidad.TabIndex = 5;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.ForeColor = System.Drawing.Color.White;
            this.BtnAgregar.Location = new System.Drawing.Point(548, 184);
            this.BtnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(88, 26);
            this.BtnAgregar.TabIndex = 6;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // DgvDetalles
            // 
            this.DgvDetalles.AllowUserToAddRows = false;
            this.DgvDetalles.AllowUserToDeleteRows = false;
            this.DgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Articulo,
            this.Cubierto,
            this.Cantidad,
            this.PrecioUnitario,
            this.Accion});
            this.DgvDetalles.Location = new System.Drawing.Point(13, 232);
            this.DgvDetalles.Margin = new System.Windows.Forms.Padding(4);
            this.DgvDetalles.Name = "DgvDetalles";
            this.DgvDetalles.ReadOnly = true;
            this.DgvDetalles.RowHeadersWidth = 51;
            this.DgvDetalles.Size = new System.Drawing.Size(652, 218);
            this.DgvDetalles.TabIndex = 11;
            this.DgvDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalles_CellContentClick);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAceptar.ForeColor = System.Drawing.Color.White;
            this.BtnAceptar.Location = new System.Drawing.Point(89, 457);
            this.BtnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(88, 26);
            this.BtnAceptar.TabIndex = 7;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Location = new System.Drawing.Point(184, 457);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(88, 26);
            this.BtnCancelar.TabIndex = 8;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // TbxTotal
            // 
            this.TbxTotal.Enabled = false;
            this.TbxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxTotal.Location = new System.Drawing.Point(494, 457);
            this.TbxTotal.Margin = new System.Windows.Forms.Padding(4);
            this.TbxTotal.Name = "TbxTotal";
            this.TbxTotal.Size = new System.Drawing.Size(119, 26);
            this.TbxTotal.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(430, 461);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Total";
            // 
            // CbxFormaPago
            // 
            this.CbxFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxFormaPago.FormattingEnabled = true;
            this.CbxFormaPago.Location = new System.Drawing.Point(430, 80);
            this.CbxFormaPago.Margin = new System.Windows.Forms.Padding(4);
            this.CbxFormaPago.Name = "CbxFormaPago";
            this.CbxFormaPago.Size = new System.Drawing.Size(207, 23);
            this.CbxFormaPago.TabIndex = 2;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.ForeColor = System.Drawing.Color.White;
            this.lblFormaPago.Location = new System.Drawing.Point(324, 82);
            this.lblFormaPago.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(87, 15);
            this.lblFormaPago.TabIndex = 19;
            this.lblFormaPago.Text = "Forma de pago";
            // 
            // CbxObrasSociales
            // 
            this.CbxObrasSociales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxObrasSociales.FormattingEnabled = true;
            this.CbxObrasSociales.Location = new System.Drawing.Point(430, 124);
            this.CbxObrasSociales.Margin = new System.Windows.Forms.Padding(4);
            this.CbxObrasSociales.Name = "CbxObrasSociales";
            this.CbxObrasSociales.Size = new System.Drawing.Size(207, 23);
            this.CbxObrasSociales.TabIndex = 3;
            // 
            // lblArticulo
            // 
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.ForeColor = System.Drawing.Color.White;
            this.lblArticulo.Location = new System.Drawing.Point(42, 190);
            this.lblArticulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(49, 15);
            this.lblArticulo.TabIndex = 21;
            this.lblArticulo.Text = "Articulo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(317, 191);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Cantidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(349, 126);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Obra social";
            // 
            // checkCubierto
            // 
            this.checkCubierto.AutoSize = true;
            this.checkCubierto.ForeColor = System.Drawing.Color.White;
            this.checkCubierto.Location = new System.Drawing.Point(460, 190);
            this.checkCubierto.Name = "checkCubierto";
            this.checkCubierto.Size = new System.Drawing.Size(72, 19);
            this.checkCubierto.TabIndex = 24;
            this.checkCubierto.Text = "Cubierto";
            this.checkCubierto.UseVisualStyleBackColor = true;
            // 
            // Articulo
            // 
            this.Articulo.Frozen = true;
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.MinimumWidth = 6;
            this.Articulo.Name = "Articulo";
            this.Articulo.ReadOnly = true;
            this.Articulo.Width = 200;
            // 
            // Cubierto
            // 
            this.Cubierto.Frozen = true;
            this.Cubierto.HeaderText = "Cubierto";
            this.Cubierto.Name = "Cubierto";
            this.Cubierto.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.Frozen = true;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 75;
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.Frozen = true;
            this.PrecioUnitario.HeaderText = "Precio Unitario";
            this.PrecioUnitario.MinimumWidth = 6;
            this.PrecioUnitario.Name = "PrecioUnitario";
            this.PrecioUnitario.ReadOnly = true;
            this.PrecioUnitario.Width = 125;
            // 
            // Accion
            // 
            this.Accion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Accion.HeaderText = "Accion";
            this.Accion.MinimumWidth = 6;
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            this.Accion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Accion.Text = "Quitar";
            this.Accion.UseColumnTextForButtonValue = true;
            // 
            // FrmNuevaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(177)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(678, 495);
            this.Controls.Add(this.checkCubierto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblArticulo);
            this.Controls.Add(this.CbxObrasSociales);
            this.Controls.Add(this.lblFormaPago);
            this.Controls.Add(this.CbxFormaPago);
            this.Controls.Add(this.TbxTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.DgvDetalles);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.TbxCantidad);
            this.Controls.Add(this.CbxArticulos);
            this.Controls.Add(this.DtpFecha);
            this.Controls.Add(this.TbxCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblFactura);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmNuevaVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NuevaFactura";
            this.Load += new System.EventHandler(this.FrmNuevaFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbxCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.ComboBox CbxArticulos;
        private System.Windows.Forms.TextBox TbxCantidad;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox TbxTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView DgvDetalles;
        private ComboBox CbxFormaPago;
        private Label lblFormaPago;
        private ComboBox CbxObrasSociales;
        private Label lblArticulo;
        private Label label1;
        private Label label4;
        private CheckBox checkCubierto;
        private DataGridViewTextBoxColumn Articulo;
        private DataGridViewTextBoxColumn Cubierto;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn PrecioUnitario;
        private DataGridViewButtonColumn Accion;
    }
}