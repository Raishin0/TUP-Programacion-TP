namespace FrontFarmaceutica.formularios
{
    partial class FrmDetallesVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetallesVentas));
            this.DgvDetalles = new System.Windows.Forms.DataGridView();
            this.TbxTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.CbxFormaPago = new System.Windows.Forms.ComboBox();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TbxCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblFactura = new System.Windows.Forms.Label();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cubierto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvDetalles
            // 
            this.DgvDetalles.AllowUserToAddRows = false;
            this.DgvDetalles.AllowUserToDeleteRows = false;
            this.DgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Articulo,
            this.Cantidad,
            this.Cubierto,
            this.PrecioUnitario});
            this.DgvDetalles.Location = new System.Drawing.Point(35, 144);
            this.DgvDetalles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DgvDetalles.Name = "DgvDetalles";
            this.DgvDetalles.ReadOnly = true;
            this.DgvDetalles.RowHeadersWidth = 51;
            this.DgvDetalles.Size = new System.Drawing.Size(580, 218);
            this.DgvDetalles.TabIndex = 50;
            // 
            // TbxTotal
            // 
            this.TbxTotal.Enabled = false;
            this.TbxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxTotal.Location = new System.Drawing.Point(438, 383);
            this.TbxTotal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TbxTotal.Name = "TbxTotal";
            this.TbxTotal.Size = new System.Drawing.Size(118, 26);
            this.TbxTotal.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(374, 386);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 45;
            this.label6.Text = "Total";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Location = new System.Drawing.Point(102, 379);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(88, 27);
            this.BtnCancelar.TabIndex = 44;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // CbxFormaPago
            // 
            this.CbxFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxFormaPago.Enabled = false;
            this.CbxFormaPago.FormattingEnabled = true;
            this.CbxFormaPago.Location = new System.Drawing.Point(141, 103);
            this.CbxFormaPago.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CbxFormaPago.Name = "CbxFormaPago";
            this.CbxFormaPago.Size = new System.Drawing.Size(140, 23);
            this.CbxFormaPago.TabIndex = 43;
            // 
            // DtpFecha
            // 
            this.DtpFecha.Enabled = false;
            this.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFecha.Location = new System.Drawing.Point(383, 66);
            this.DtpFecha.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(137, 23);
            this.DtpFecha.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(35, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 41;
            this.label4.Text = "Forma de pago";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TbxCliente
            // 
            this.TbxCliente.Enabled = false;
            this.TbxCliente.Location = new System.Drawing.Point(141, 66);
            this.TbxCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TbxCliente.Name = "TbxCliente";
            this.TbxCliente.Size = new System.Drawing.Size(140, 23);
            this.TbxCliente.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(84, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 39;
            this.label3.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(333, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 38;
            this.label2.Text = "Fecha";
            // 
            // LblFactura
            // 
            this.LblFactura.AutoSize = true;
            this.LblFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblFactura.ForeColor = System.Drawing.Color.White;
            this.LblFactura.Location = new System.Drawing.Point(69, 18);
            this.LblFactura.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblFactura.Name = "LblFactura";
            this.LblFactura.Size = new System.Drawing.Size(130, 31);
            this.LblFactura.TabIndex = 37;
            this.LblFactura.Text = "Venta Nº";
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
            // Cantidad
            // 
            this.Cantidad.Frozen = true;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 125;
            // 
            // Cubierto
            // 
            this.Cubierto.Frozen = true;
            this.Cubierto.HeaderText = "Cubierto";
            this.Cubierto.Name = "Cubierto";
            this.Cubierto.ReadOnly = true;
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
            // FrmDetallesVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(177)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(648, 418);
            this.Controls.Add(this.DgvDetalles);
            this.Controls.Add(this.TbxTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.CbxFormaPago);
            this.Controls.Add(this.DtpFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TbxCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblFactura);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDetallesVentas";
            this.Text = "Detalles Factura";
            this.Load += new System.EventHandler(this.FrmDetallesFactura_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView DgvDetalles;
        private TextBox TbxTotal;
        private Label label6;
        private Button BtnCancelar;
        private ComboBox CbxFormaPago;
        private DateTimePicker DtpFecha;
        private Label label4;
        private TextBox TbxCliente;
        private Label label3;
        private Label label2;
        private Label LblFactura;
        private DataGridViewTextBoxColumn Articulo;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Cubierto;
        private DataGridViewTextBoxColumn PrecioUnitario;
    }
}