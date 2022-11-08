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
        string urlApi;
        Dictionary<int, string> tipos;
        List<Suministro> lst;
        public FrmConsultarSuministros(string urlApi)
        {
            InitializeComponent();
            this.urlApi = urlApi;
        }

        private async void FrmConsultarSuministros_Load(object sender, EventArgs e)
        {
            await CargarComboAsync();
            await CargarSuministros();
        }
        private async Task CargarComboAsync()
        {
            string url = urlApi + "tipossuministros";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            tipos = JsonConvert.DeserializeObject<Dictionary<int, string>>(data);
            
        }

        private string ventalibre(int valor)
        {
            switch (valor)
            {
                case 1:
                    return "Si";
                case 0:
                    return "No";
                default:
                    return "Indefinido";
            }
        }

        private async Task CargarSuministros()
        {
            dgvArticulos.Rows.Clear();
            string url = urlApi + "suministros";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            lst = JsonConvert.DeserializeObject<List<Suministro>>(data);
            foreach(Suministro sum in lst)
            {
                dgvArticulos.Rows.Add(new object[] { sum.Codigo, sum.Descripcion, sum.Precio,
                ventalibre(sum.VentaLibre), tipos[sum.Tipo], sum.Stock});
            }
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvArticulos.CurrentCell.ColumnIndex == 6)
            {
                QuitarSuministro((int)dgvArticulos.CurrentRow.Cells[0].Value);
            }

            if (dgvArticulos.CurrentCell.ColumnIndex == 7)
            {
                ModificarSuministroAsync(lst[dgvArticulos.CurrentRow.Index]);
            }
        }

        private async Task ModificarSuministroAsync(Suministro suministro)
        {
            FrmModBajaSuministro frmModBajaSuministro = new FrmModBajaSuministro(suministro,urlApi);
            frmModBajaSuministro.Show();
            await CargarSuministros();
        }


        private async Task QuitarSuministro(int value)
        {
            if (value != -1)
            {
                if (MessageBox.Show("Esta seguro que desea eliminar el suministro?.\nNo bebe formar parte ninguna venta.", "IMPORTANTE.",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (await BorrarAsync(value))
                    {
                        MessageBox.Show("Suministro eliminado", "INFORME..",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Close();
                        await CargarSuministros();
                    }
                    else
                    {
                        MessageBox.Show("ERROR. No se pudo eliminar el suministro.\nRevise que este no se haya usado en ninguna venta.",
                                         "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        await CargarSuministros();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un suministro de la lista",
                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> BorrarAsync(int value)
        {
            string url = urlApi + "suministro/" + value;
            var data = await ClienteSingleton.GetInstance().DeleteAsync(url);
            bool res = JsonConvert.DeserializeObject<bool>(data);
            return res;
        }

        private async void BtnGenerar_ClickAsync(object sender, EventArgs e)
        {
            await CargarSuministros();
        }
    }
}
