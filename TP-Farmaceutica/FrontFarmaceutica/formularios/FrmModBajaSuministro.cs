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
    public partial class FrmModBajaSuministro : Form
    {
        string urlApi;
        Suministro sumi;
        public FrmModBajaSuministro(Suministro sumi, string urlApi)
        {
            InitializeComponent();
            this.urlApi = urlApi;
            this.sumi = sumi;
        }

        private async void FmrModBajaSuministro_Load(object sender, EventArgs e)
        {
            await CargarComboAsync();
            Cargar();
        }

        private async Task CargarComboAsync()
        {
            string url = urlApi + "tipossuministros";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            Dictionary<int, string> lst = JsonConvert.DeserializeObject<Dictionary<int, string>>(data);
            cboTipo.DataSource = new BindingSource(lst, null);
            cboTipo.DisplayMember = "Value";
            cboTipo.ValueMember = "Key";
            cboTipo.SelectedIndex = -1;
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
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
            if (!rdbSi.Checked && !rdbNo.Checked && !rdbIndefinido.Checked)
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

        public void Cargar()
        {
            txtDescrip.Text = sumi.Descripcion;
            txtPrecio.Text = Convert.ToString(sumi.Precio);
            cboTipo.SelectedValue =sumi.Tipo;
            txtStock.Text = Convert.ToString(sumi.Stock);
            if (sumi.VentaLibre == 1)
                rdbSi.Checked = true;
            else if (sumi.VentaLibre == 0)
                rdbNo.Checked = true;
            else
                rdbIndefinido.Checked = true;
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
                if (Validar())
                {
                    Suministro s = new Suministro();
                    s.Codigo = sumi.Codigo;
                    s.Descripcion = txtDescrip.Text;
                    s.Precio = Convert.ToDouble(txtPrecio.Text);
                    s.Stock = Convert.ToInt32(txtStock.Text);
                    s.Tipo = Convert.ToInt32(cboTipo.SelectedValue);
                    if (rdbSi.Checked)
                        s.VentaLibre = 1;
                    else if(rdbNo.Checked)
                        s.VentaLibre = 0;
                    else
                        s.VentaLibre = -1;
                if (await ActualizarAsync(s))
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
