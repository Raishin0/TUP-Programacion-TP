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
    public partial class FmrModBajaSuministro : Form
    {
        string urlApi;
        //Suministro sumi;
        List<Suministro> lSuministro;
        public FmrModBajaSuministro(/*Suministro sumi, */string urlApi)
        {
            InitializeComponent();
            lSuministro = new List<Suministro>();
            //this.sumi = sumi;
        }

        private async void FmrModBajaSuministro_Load(object sender, EventArgs e)
        {
            await CargarComboAsync();
            await CargarSuministrosAsync();
            lstSum.AllowDrop = false;
        }

        private async Task CargarComboAsync()
        {
            string url = urlApi + "tipossuministros";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            Dictionary<int, string> lst = JsonConvert.DeserializeObject<Dictionary<int, string>>(data);
            cboTipo.DataSource = lst;
            cboTipo.DisplayMember = "nombre";
            cboTipo.ValueMember = "nro";
            cboTipo.SelectedIndex = -1;
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async Task CargarSuministrosAsync()
        {
            lstSum.Items.Clear();
            lSuministro.Clear();
            string url = urlApi + "suministros";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            lSuministro = JsonConvert.DeserializeObject<List<Suministro>>(data);
            foreach (Suministro sum in lSuministro)
            {
                lstSum.Items.Add(sum);
            }
            lstSum.SelectedIndex = 0;
        }


        public bool Validar()
        {
            if (string.IsNullOrEmpty(txtDescrip.Text))
            {
                MessageBox.Show("Debe ingrasar una descripción ", "MENSAJE..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescrip.Focus();
                return false;
            }
            if (!double.TryParse(txtPrecio.Text, out double result))
            {
                MessageBox.Show("Debe ingrasar un precio valido ", "MENSAJE..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrecio.Focus();
                return false;
            }
            if (!rdbSi.Checked && !rdbNo.Checked)
            {
                MessageBox.Show("Debe seleccionar el estado de venta ", "MENSAJE..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rdbSi.Focus();
                return false;
            }
            if (cboTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de suministro ", "MENSAJE..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTipo.Focus();
                return false;
            }
            if (!int.TryParse(txtStock.Text, out int result2))
            {
                MessageBox.Show("Debe ingresar un stock valido ", "MENSAJE..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStock.Focus();
                return false;
            }
            return true;
        }

        public void Cargar(int i)
        {
            txtDescrip.Text = lSuministro[i].Descripcion;
            txtPrecio.Text = Convert.ToString(lSuministro[i].Precio);
            txtStock.Text = Convert.ToString(lSuministro[i].Stock);
            if (lSuministro[i].VentaLibre == 1)
                rdbSi.Checked = true;
            else
                rdbNo.Checked = true;
            cboTipo.SelectedValue = lSuministro[i].Tipo;
        }
        private async Task<bool> ActualizarAsync(Suministro actSumi)
        {
            string url = urlApi + "suministro/" + actSumi.Codigo;
            string suministroJson = JsonConvert.SerializeObject(actSumi);
            var result = await ClienteSingleton.GetInstance().PutAsync(url, suministroJson);
            return result.Equals("true");
        }

        private async Task<bool> BorrarAsync(Suministro actSumi)
        {
            string url = urlApi + "suministro/" + actSumi.Codigo;
            string suministroJson = JsonConvert.SerializeObject(actSumi);
            var result = await ClienteSingleton.GetInstance().DeleteAsync(url);
            return result.Equals("true");
        }
       

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (lstSum.SelectedIndex!=-1)
            {
                if (Validar())
                {
                    Suministro s = new Suministro();
                    s.Codigo = lSuministro[lstSum.SelectedIndex].Codigo;
                    s.Descripcion = txtDescrip.Text;
                    s.Precio = Convert.ToDouble(txtPrecio.Text);
                    s.Stock = Convert.ToInt32(txtStock.Text);
                    s.Tipo = Convert.ToInt32(cboTipo.SelectedValue);
                    if (rdbSi.Checked)
                        s.VentaLibre = 1;
                    else
                        s.VentaLibre = 0;
                    if(await ActualizarAsync(s))
                    {
                        MessageBox.Show("Suministro modificado", "INFORME..",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ERROR. No se pudo modificar el suministro",
                                         "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un suministro de la lista",
                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lstSum.Focus();
            }
        }


        private void lstSum_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar(lstSum.SelectedIndex);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstSum.SelectedIndex != -1)
            {
                if (MessageBox.Show("Esta seguro que desea eliminar el suministro?.", "IMPORTANTE.",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Suministro s1 = new Suministro();
                    s1.Codigo = lSuministro[lstSum.SelectedIndex].Codigo;
                    if (await BorrarAsync(s1))
                    {
                        MessageBox.Show("Suministro eliminado", "INFORME..",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ERROR. No se pudo eliminar el suministro",
                                         "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un suministro de la lista",
                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lstSum.Focus();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?.", "IMPORTANTE.",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //METODOS QUE NO HACEN NADA ...
        private void cboTipo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void FmrModBajaSuministro_Load_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
