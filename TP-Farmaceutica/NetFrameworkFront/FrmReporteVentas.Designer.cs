namespace NetFrameworkFront
{
    partial class FrmReporteVentas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteVentas));
            this.rpvVentas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.panelFechas = new System.Windows.Forms.Panel();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.labelFechaFinal = new System.Windows.Forms.Label();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.labelFechaInicial = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelFechas.SuspendLayout();
            this.SuspendLayout();
            // 
            // rpvVentas
            // 
            this.rpvVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rpvVentas.LocalReport.ReportEmbeddedResource = "NetFrameworkFront.reportes.ReporteVentas.rdlc";
            this.rpvVentas.Location = new System.Drawing.Point(18, 88);
            this.rpvVentas.Margin = new System.Windows.Forms.Padding(4);
            this.rpvVentas.Name = "rpvVentas";
            this.rpvVentas.ServerReport.BearerToken = null;
            this.rpvVentas.Size = new System.Drawing.Size(1292, 569);
            this.rpvVentas.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(167)))), ((int)(((byte)(41)))));
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.btnGenerar);
            this.panel1.Controls.Add(this.panelFechas);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1325, 81);
            this.panel1.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.checkBox1.FlatAppearance.BorderSize = 0;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(173, 28);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(249, 24);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Limitar por intervalo de fecha:";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(167)))), ((int)(((byte)(41)))));
            this.btnGenerar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(16, 18);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(133, 44);
            this.btnGenerar.TabIndex = 0;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // panelFechas
            // 
            this.panelFechas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFechas.Controls.Add(this.dtpFechaFinal);
            this.panelFechas.Controls.Add(this.labelFechaFinal);
            this.panelFechas.Controls.Add(this.dtpFechaInicial);
            this.panelFechas.Controls.Add(this.labelFechaInicial);
            this.panelFechas.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelFechas.Location = new System.Drawing.Point(455, 18);
            this.panelFechas.Margin = new System.Windows.Forms.Padding(4);
            this.panelFechas.Name = "panelFechas";
            this.panelFechas.Size = new System.Drawing.Size(823, 44);
            this.panelFechas.TabIndex = 2;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Location = new System.Drawing.Point(541, 10);
            this.dtpFechaFinal.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(265, 22);
            this.dtpFechaFinal.TabIndex = 2;
            this.dtpFechaFinal.ValueChanged += new System.EventHandler(this.dtpFechaFinal_ValueChanged);
            // 
            // labelFechaFinal
            // 
            this.labelFechaFinal.AutoSize = true;
            this.labelFechaFinal.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.labelFechaFinal.ForeColor = System.Drawing.Color.White;
            this.labelFechaFinal.Location = new System.Drawing.Point(428, 12);
            this.labelFechaFinal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFechaFinal.Name = "labelFechaFinal";
            this.labelFechaFinal.Size = new System.Drawing.Size(96, 19);
            this.labelFechaFinal.TabIndex = 4;
            this.labelFechaFinal.Text = "Fecha Final:";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Location = new System.Drawing.Point(140, 10);
            this.dtpFechaInicial.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(265, 22);
            this.dtpFechaInicial.TabIndex = 1;
            this.dtpFechaInicial.ValueChanged += new System.EventHandler(this.dtpFechaInicial_ValueChanged);
            // 
            // labelFechaInicial
            // 
            this.labelFechaInicial.AutoSize = true;
            this.labelFechaInicial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(167)))), ((int)(((byte)(41)))));
            this.labelFechaInicial.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.labelFechaInicial.ForeColor = System.Drawing.Color.White;
            this.labelFechaInicial.Location = new System.Drawing.Point(17, 12);
            this.labelFechaInicial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFechaInicial.Name = "labelFechaInicial";
            this.labelFechaInicial.Size = new System.Drawing.Size(105, 19);
            this.labelFechaInicial.TabIndex = 3;
            this.labelFechaInicial.Text = "Fecha Inicial:";
            // 
            // FrmReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 670);
            this.Controls.Add(this.rpvVentas);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmReporteVentas";
            this.Text = "Reporte Ventas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFechas.ResumeLayout(false);
            this.panelFechas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvVentas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Panel panelFechas;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label labelFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Label labelFechaInicial;
    }
}

