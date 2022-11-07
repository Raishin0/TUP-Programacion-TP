namespace FrontFarmaceutica.formularios
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.TbxUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TbxContrasenia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnEntrar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.pbContraVisible = new System.Windows.Forms.PictureBox();
            this.pbContraNoVisible = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbContraVisible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbContraNoVisible)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(98, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // TbxUsuario
            // 
            this.TbxUsuario.Location = new System.Drawing.Point(159, 127);
            this.TbxUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbxUsuario.Name = "TbxUsuario";
            this.TbxUsuario.Size = new System.Drawing.Size(188, 27);
            this.TbxUsuario.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(203, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 41);
            this.label2.TabIndex = 2;
            this.label2.Text = "Login";
            // 
            // TbxContrasenia
            // 
            this.TbxContrasenia.Location = new System.Drawing.Point(159, 184);
            this.TbxContrasenia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbxContrasenia.Name = "TbxContrasenia";
            this.TbxContrasenia.Size = new System.Drawing.Size(188, 27);
            this.TbxContrasenia.TabIndex = 4;
            this.TbxContrasenia.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(75, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Contraseña";
            // 
            // BtnEntrar
            // 
            this.BtnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEntrar.ForeColor = System.Drawing.Color.White;
            this.BtnEntrar.Location = new System.Drawing.Point(159, 260);
            this.BtnEntrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnEntrar.Name = "BtnEntrar";
            this.BtnEntrar.Size = new System.Drawing.Size(86, 31);
            this.BtnEntrar.TabIndex = 5;
            this.BtnEntrar.Text = "Entrar";
            this.BtnEntrar.UseVisualStyleBackColor = true;
            this.BtnEntrar.Click += new System.EventHandler(this.BtnEntrar_ClickAsync);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Location = new System.Drawing.Point(261, 260);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(86, 31);
            this.BtnCancelar.TabIndex = 6;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // pbContraVisible
            // 
            this.pbContraVisible.Image = ((System.Drawing.Image)(resources.GetObject("pbContraVisible.Image")));
            this.pbContraVisible.Location = new System.Drawing.Point(353, 182);
            this.pbContraVisible.Name = "pbContraVisible";
            this.pbContraVisible.Size = new System.Drawing.Size(32, 32);
            this.pbContraVisible.TabIndex = 7;
            this.pbContraVisible.TabStop = false;
            this.pbContraVisible.Visible = false;
            this.pbContraVisible.Click += new System.EventHandler(this.pbContraVisible_Click);
            // 
            // pbContraNoVisible
            // 
            this.pbContraNoVisible.Image = ((System.Drawing.Image)(resources.GetObject("pbContraNoVisible.Image")));
            this.pbContraNoVisible.Location = new System.Drawing.Point(353, 182);
            this.pbContraNoVisible.Name = "pbContraNoVisible";
            this.pbContraNoVisible.Size = new System.Drawing.Size(32, 32);
            this.pbContraNoVisible.TabIndex = 8;
            this.pbContraNoVisible.TabStop = false;
            this.pbContraNoVisible.Click += new System.EventHandler(this.pbContraNoVisible_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(177)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(480, 328);
            this.Controls.Add(this.pbContraNoVisible);
            this.Controls.Add(this.pbContraVisible);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnEntrar);
            this.Controls.Add(this.TbxContrasenia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TbxUsuario);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            ((System.ComponentModel.ISupportInitialize)(this.pbContraVisible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbContraNoVisible)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox TbxUsuario;
        private Label label2;
        private TextBox TbxContrasenia;
        private Label label3;
        private Button BtnEntrar;
        private Button BtnCancelar;
        private PictureBox pbNoVisible;
        private PictureBox pbVisible;
        private PictureBox pbContraVisible;
        private PictureBox pbContraNoVisible;
    }
}