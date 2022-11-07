using FrontFarmaceutica.servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontFarmaceutica.formularios
{
    public partial class FrmLogin : Form
    {
        string urlApi;
        public FrmLogin(string urlApi)
        {
            this.urlApi = urlApi;
            InitializeComponent();
        }

        private async void BtnEntrar_ClickAsync(object sender, EventArgs e)
        {
            if(await LoginAsync(TbxUsuario.Text, TbxContrasenia.Text))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        private async Task<bool> LoginAsync(string usuario, string password)
        {
            string url = urlApi + string.Format("login?nombre={0}&password={1}", usuario, password);
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            bool value = JsonConvert.DeserializeObject<bool>(data);
            return value;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Seguro que desea salir?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pbContraNoVisible_Click(object sender, EventArgs e)
        {
            pbContraNoVisible.Visible = false;
            pbContraVisible.Visible = true;
            TbxContrasenia.UseSystemPasswordChar = false;
        }

        private void pbContraVisible_Click(object sender, EventArgs e)
        {
            pbContraVisible.Visible = false;
            pbContraNoVisible.Visible = true;
            TbxContrasenia.UseSystemPasswordChar = true;
        }
    }
}
