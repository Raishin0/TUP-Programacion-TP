using DataApi.dominio;
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
    public partial class FrmConsultarSuministros : Form
    {
        string urlApi = "http://localhost:5023/";
        public FrmConsultarSuministros()
        {
            InitializeComponent();
        }

        private async void FrmConsultarArticulos_Load(object sender, EventArgs e)
        {
            await CargarArticulosAsync();
        }

        private async Task CargarArticulosAsync()
        {
            string url = urlApi + "articulos";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Suministro> lst = JsonConvert.DeserializeObject<List<Suministro>>(data);
            foreach(Suministro sum in lst)
            {
                dgvArticulos.Rows.Add(new object[] { sum.Codigo, sum.Descripcion, sum.Precio });
            }
        }
    }
}
