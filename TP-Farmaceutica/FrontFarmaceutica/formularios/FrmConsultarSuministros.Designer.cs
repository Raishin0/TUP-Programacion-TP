namespace FrontFarmaceutica.formularios
{
    partial class FrmConsultarSuministros
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.id_articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.venta_libre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BtnGenerar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(403, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Articulos";
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.AllowUserToAddRows = false;
            this.dgvArticulos.AllowUserToDeleteRows = false;
            this.dgvArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_articulo,
            this.descripcion,
            this.precio,
            this.venta_libre,
            this.tipo_sum,
            this.stock,
            this.eliminar,
            this.Editar});
            this.dgvArticulos.Location = new System.Drawing.Point(12, 79);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.ReadOnly = true;
            this.dgvArticulos.RowTemplate.Height = 25;
            this.dgvArticulos.Size = new System.Drawing.Size(961, 495);
            this.dgvArticulos.TabIndex = 1;
            this.dgvArticulos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulos_CellContentClick);
            // 
            // id_articulo
            // 
            this.id_articulo.HeaderText = "id_articulo";
            this.id_articulo.Name = "id_articulo";
            this.id_articulo.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion.HeaderText = "descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // precio
            // 
            this.precio.HeaderText = "precio";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            // 
            // venta_libre
            // 
            this.venta_libre.HeaderText = "Venta Libre";
            this.venta_libre.Name = "venta_libre";
            this.venta_libre.ReadOnly = true;
            // 
            // tipo_sum
            // 
            this.tipo_sum.HeaderText = "Tipo";
            this.tipo_sum.Name = "tipo_sum";
            this.tipo_sum.ReadOnly = true;
            // 
            // stock
            // 
            this.stock.HeaderText = "Stock";
            this.stock.Name = "stock";
            this.stock.ReadOnly = true;
            // 
            // eliminar
            // 
            this.eliminar.HeaderText = "Eliminar";
            this.eliminar.Name = "eliminar";
            this.eliminar.ReadOnly = true;
            this.eliminar.Text = "Eliminar";
            this.eliminar.UseColumnTextForButtonValue = true;
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.Text = "Editar";
            this.Editar.UseColumnTextForButtonValue = true;
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGenerar.ForeColor = System.Drawing.Color.White;
            this.BtnGenerar.Location = new System.Drawing.Point(589, 21);
            this.BtnGenerar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(110, 38);
            this.BtnGenerar.TabIndex = 4;
            this.BtnGenerar.Text = "Generar";
            this.BtnGenerar.UseVisualStyleBackColor = true;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_ClickAsync);
            // 
            // FrmConsultarSuministros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(177)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(985, 586);
            this.Controls.Add(this.BtnGenerar);
            this.Controls.Add(this.dgvArticulos);
            this.Controls.Add(this.label1);
            this.Name = "FrmConsultarSuministros";
            this.Text = "FrmConsultarArticulos";
            this.Load += new System.EventHandler(this.FrmConsultarSuministros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private DataGridView dgvArticulos;
        private DataGridViewTextBoxColumn id_articulo;
        private DataGridViewTextBoxColumn descripcion;
        private DataGridViewTextBoxColumn precio;
        private DataGridViewTextBoxColumn venta_libre;
        private DataGridViewTextBoxColumn tipo_sum;
        private DataGridViewTextBoxColumn stock;
        private DataGridViewButtonColumn eliminar;
        private DataGridViewButtonColumn Editar;
        private Button BtnGenerar;
    }
}