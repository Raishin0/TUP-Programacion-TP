namespace FrontFarmaceutica.formularios
{
    partial class FrmConsultarVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarVentas));
            this.label1 = new System.Windows.Forms.Label();
            this.DgvFacturas = new System.Windows.Forms.DataGridView();
            this.NroFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObraSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Borrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Ver = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IDFormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDObraSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnGenerar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TbxCliente = new System.Windows.Forms.TextBox();
            this.DtpPrimeraFecha = new System.Windows.Forms.DateTimePicker();
            this.DtpUltimaFecha = new System.Windows.Forms.DateTimePicker();
            this.ckbVentasEnPapelera = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(480, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ventas";
            // 
            // DgvFacturas
            // 
            this.DgvFacturas.AllowUserToAddRows = false;
            this.DgvFacturas.AllowUserToDeleteRows = false;
            this.DgvFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroFactura,
            this.Fecha,
            this.Cliente,
            this.FormaPago,
            this.ObraSocial,
            this.Borrar,
            this.Modificar,
            this.Ver,
            this.IDFormaPago,
            this.IDObraSocial});
            this.DgvFacturas.Location = new System.Drawing.Point(33, 149);
            this.DgvFacturas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DgvFacturas.Name = "DgvFacturas";
            this.DgvFacturas.ReadOnly = true;
            this.DgvFacturas.RowHeadersWidth = 51;
            this.DgvFacturas.Size = new System.Drawing.Size(991, 404);
            this.DgvFacturas.TabIndex = 1;
            this.DgvFacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFacturas_CellContentClick);
            // 
            // NroFactura
            // 
            this.NroFactura.HeaderText = "NroFactura";
            this.NroFactura.MinimumWidth = 6;
            this.NroFactura.Name = "NroFactura";
            this.NroFactura.ReadOnly = true;
            this.NroFactura.Width = 75;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MinimumWidth = 6;
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 150;
            // 
            // Cliente
            // 
            this.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.MinimumWidth = 6;
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // FormaPago
            // 
            this.FormaPago.HeaderText = "Forma pago";
            this.FormaPago.MinimumWidth = 6;
            this.FormaPago.Name = "FormaPago";
            this.FormaPago.ReadOnly = true;
            this.FormaPago.Width = 75;
            // 
            // ObraSocial
            // 
            this.ObraSocial.HeaderText = "ObraSocial";
            this.ObraSocial.Name = "ObraSocial";
            this.ObraSocial.ReadOnly = true;
            // 
            // Borrar
            // 
            this.Borrar.HeaderText = "Borrar";
            this.Borrar.MinimumWidth = 6;
            this.Borrar.Name = "Borrar";
            this.Borrar.ReadOnly = true;
            this.Borrar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Borrar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Borrar.Text = "Borrar";
            this.Borrar.UseColumnTextForButtonValue = true;
            this.Borrar.Width = 75;
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.MinimumWidth = 6;
            this.Modificar.Name = "Modificar";
            this.Modificar.ReadOnly = true;
            this.Modificar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Modificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Modificar.Text = "Modificar";
            this.Modificar.UseColumnTextForButtonValue = true;
            this.Modificar.Width = 75;
            // 
            // Ver
            // 
            this.Ver.HeaderText = "Ver";
            this.Ver.MinimumWidth = 6;
            this.Ver.Name = "Ver";
            this.Ver.ReadOnly = true;
            this.Ver.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Ver.Text = "Ver";
            this.Ver.UseColumnTextForButtonValue = true;
            this.Ver.Width = 75;
            // 
            // IDFormaPago
            // 
            this.IDFormaPago.HeaderText = "IDFormaPago";
            this.IDFormaPago.MinimumWidth = 6;
            this.IDFormaPago.Name = "IDFormaPago";
            this.IDFormaPago.ReadOnly = true;
            this.IDFormaPago.Visible = false;
            this.IDFormaPago.Width = 125;
            // 
            // IDObraSocial
            // 
            this.IDObraSocial.HeaderText = "IDObraSocial";
            this.IDObraSocial.Name = "IDObraSocial";
            this.IDObraSocial.ReadOnly = true;
            this.IDObraSocial.Visible = false;
            // 
            // BtnSalir
            // 
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSalir.ForeColor = System.Drawing.Color.White;
            this.BtnSalir.Location = new System.Drawing.Point(914, 570);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(110, 39);
            this.BtnSalir.TabIndex = 2;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGenerar.ForeColor = System.Drawing.Color.White;
            this.BtnGenerar.Location = new System.Drawing.Point(914, 56);
            this.BtnGenerar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(110, 60);
            this.BtnGenerar.TabIndex = 3;
            this.BtnGenerar.Text = "Generar";
            this.BtnGenerar.UseVisualStyleBackColor = true;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(55, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Primera Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(60, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ultima Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(509, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cliente";
            // 
            // TbxCliente
            // 
            this.TbxCliente.Location = new System.Drawing.Point(566, 58);
            this.TbxCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TbxCliente.Name = "TbxCliente";
            this.TbxCliente.Size = new System.Drawing.Size(310, 23);
            this.TbxCliente.TabIndex = 7;
            // 
            // DtpPrimeraFecha
            // 
            this.DtpPrimeraFecha.Location = new System.Drawing.Point(151, 56);
            this.DtpPrimeraFecha.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DtpPrimeraFecha.Name = "DtpPrimeraFecha";
            this.DtpPrimeraFecha.Size = new System.Drawing.Size(335, 23);
            this.DtpPrimeraFecha.TabIndex = 8;
            this.DtpPrimeraFecha.Value = new System.DateTime(2000, 9, 13, 21, 25, 0, 0);
            // 
            // DtpUltimaFecha
            // 
            this.DtpUltimaFecha.Location = new System.Drawing.Point(151, 93);
            this.DtpUltimaFecha.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DtpUltimaFecha.Name = "DtpUltimaFecha";
            this.DtpUltimaFecha.Size = new System.Drawing.Size(335, 23);
            this.DtpUltimaFecha.TabIndex = 9;
            // 
            // ckbVentasEnPapelera
            // 
            this.ckbVentasEnPapelera.AutoSize = true;
            this.ckbVentasEnPapelera.ForeColor = System.Drawing.Color.White;
            this.ckbVentasEnPapelera.Location = new System.Drawing.Point(566, 98);
            this.ckbVentasEnPapelera.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ckbVentasEnPapelera.Name = "ckbVentasEnPapelera";
            this.ckbVentasEnPapelera.Size = new System.Drawing.Size(199, 19);
            this.ckbVentasEnPapelera.TabIndex = 10;
            this.ckbVentasEnPapelera.Text = "Ver solo las ventas deshabilitadas";
            this.ckbVentasEnPapelera.UseVisualStyleBackColor = true;
            this.ckbVentasEnPapelera.CheckedChanged += new System.EventHandler(this.ckbVentasEnPapelera_CheckedChanged);
            // 
            // FrmConsultarVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(177)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1062, 621);
            this.Controls.Add(this.ckbVentasEnPapelera);
            this.Controls.Add(this.DtpUltimaFecha);
            this.Controls.Add(this.DtpPrimeraFecha);
            this.Controls.Add(this.TbxCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnGenerar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.DgvFacturas);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmConsultarVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Ventas";
            this.Load += new System.EventHandler(this.FrmConsultarFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvFacturas;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnGenerar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbxCliente;
        private System.Windows.Forms.DateTimePicker DtpPrimeraFecha;
        private System.Windows.Forms.DateTimePicker DtpUltimaFecha;
        private CheckBox ckbVentasEnPapelera;
        private DataGridViewTextBoxColumn NroFactura;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Cliente;
        private DataGridViewTextBoxColumn FormaPago;
        private DataGridViewTextBoxColumn ObraSocial;
        private DataGridViewButtonColumn Borrar;
        private DataGridViewButtonColumn Modificar;
        private DataGridViewButtonColumn Ver;
        private DataGridViewTextBoxColumn IDFormaPago;
        private DataGridViewTextBoxColumn IDObraSocial;
    }
}