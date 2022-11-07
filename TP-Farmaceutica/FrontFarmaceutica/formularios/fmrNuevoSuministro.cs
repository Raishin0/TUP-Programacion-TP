using FrontFarmaceutica.servicios;
using DataApi.dominio;
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
    public partial class fmrNuevoSuministro : Form
    {
        string urlApi;
        Suministro sumi;
        public fmrNuevoSuministro(Suministro sumi, string urlApi)
        {
            InitializeComponent();
            this.sumi = sumi;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void fmrNuevoSuministro_Load(object sender, EventArgs e)
        {
            await CargarComboAsync();
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
            if(!rdbSi.Checked && !rdbNo.Checked)
            {
                MessageBox.Show("Debe seleccionar el estado de venta ", "MENSAJE..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rdbSi.Focus();
                return false;
            }
            if(cboTipo.SelectedIndex==-1)
            {
                MessageBox.Show("Debe seleccionar un tipo de suministro ", "MENSAJE..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTipo.Focus();
                return false;
            }
            if(!int.TryParse(txtStock.Text, out int result2))
            {
                MessageBox.Show("Debe ingresar un stock valido ", "MENSAJE..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStock.Focus();
                return false;
            }
            return true;
        }

        private async Task<bool> GuardarSuministroAsync(Suministro oSumi)
        {
            string url = urlApi + "suministro";
            string sumiJson = JsonConvert.SerializeObject(oSumi);
            var result = await ClienteSingleton.GetInstance().PostAsync(url, sumiJson);
            return result.Equals("true");
        }

        private async void GuardarSuministro()
        {
            if (Validar())
            {
                sumi = new Suministro();
                sumi.Descripcion = Convert.ToString(txtDescrip.Text);
                sumi.Precio = Convert.ToDouble(txtPrecio.Text);
                if (rdbSi.Checked)
                    sumi.VentaLibre = 1;
                else
                    sumi.VentaLibre = 0;
                sumi.Tipo = Convert.ToInt32(cboTipo.SelectedValue);
                sumi.Stock = Convert.ToInt32(txtStock.Text);

                if (await GuardarSuministroAsync(sumi))
                {
                    MessageBox.Show("Suministro registrado", "INFORME",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ERROR. No se pudo registrar el suministro",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDescrip.Focus();
                }
            }

        }
        private void lblDescrip_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?.", "IMPORTANTE.",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarSuministro();
        }
    }
}
