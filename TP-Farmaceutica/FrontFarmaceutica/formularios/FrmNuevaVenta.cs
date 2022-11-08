using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataApi.datos;
using DataApi.dominio;
using Newtonsoft.Json;
using System.Security.Policy;
using FrontFarmaceutica.servicios;

namespace FrontFarmaceutica.formularios
{
    public partial class FrmNuevaVenta : Form
    {
        string urlApi;
        Venta nueva;

        public FrmNuevaVenta(string urlApi)
        {
            this.urlApi = urlApi;
            nueva = new Venta();
            InitializeComponent();
        }

        private async void FrmNuevaFactura_Load(object sender, EventArgs e)
        {
            nueva = new Venta();
            await CargarComboObrasSocialesAsync();
            await CargarArticulosAsync();
            await CargarComboFormasPagoAsync();
            await ProximaFacturaAsync();
            DtpFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            TbxCliente.Text = "CONSUMIDOR FINAL";
        }

        private async Task CargarArticulosAsync()
        {
            string url = urlApi+"suministros";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Suministro> lst = JsonConvert.DeserializeObject<List<Suministro>>(data);
            CbxArticulos.DataSource = lst;
            CbxArticulos.DisplayMember = "descripcion";
            CbxArticulos.ValueMember = "codigo";
            CbxArticulos.SelectedIndex = -1;
        }


        private async Task CargarComboFormasPagoAsync()
        {
            string url = urlApi + "formaspago";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            Dictionary<int,string> lst = JsonConvert.DeserializeObject<Dictionary<int, string> > (data);
            CbxFormaPago.DataSource = new BindingSource(lst, null);
            CbxFormaPago.DisplayMember = "Value";
            CbxFormaPago.ValueMember = "Key";
            CbxFormaPago.SelectedIndex = -1;
        }

        private async Task CargarComboObrasSocialesAsync()
        {
            string url = urlApi + "obrassociales";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            Dictionary<int, string> lst = JsonConvert.DeserializeObject<Dictionary<int, string>>(data);
            CbxObrasSociales.DataSource = new BindingSource(lst, null);
            CbxObrasSociales.DisplayMember = "Value";
            CbxObrasSociales.ValueMember = "Key";
            CbxObrasSociales.SelectedIndex = -1;
        }

        private async Task ProximaFacturaAsync()
        {
            string url = urlApi + "NroProximaVenta";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            int next = JsonConvert.DeserializeObject<int>(data);
            if (next > 0)
                LblFactura.Text = "Venta Nº: " + next.ToString();
            else
                MessageBox.Show("Error de datos. No se puede obtener Nº de presupuesto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void CalcularTotal()
        {
            double total = nueva.CalcularTotal();
            TbxTotal.Text = total.ToString();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (CbxArticulos.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar un Articulo!",
                "Control", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }
            if (TbxCantidad.Text == "" || !int.TryParse(TbxCantidad.Text,
            out _))
            {
                MessageBox.Show("Debe ingresar una cantidad válida!",
                "Control", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }
            if (DgvDetalles.Rows.Count > 0) {
                foreach (DataGridViewRow row in DgvDetalles.Rows)
                {
                    if (row.Cells["Articulo"].Value.ToString().Equals(CbxArticulos.Text))
                    {
                        if (MessageBox.Show("Ya se agrego este producto\n¿Quiere sumar esta cantidad?", "Control",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            int valor = int.Parse(row.Cells["Cantidad"].Value.ToString()) + int.Parse(TbxCantidad.Text);
                            row.Cells["Cantidad"].Value = valor.ToString();
                            nueva.Detalles[row.Index].Cantidad = valor;
                            CalcularTotal();
                        }
                        return;
                    }
                }
            }

            Suministro item = (Suministro)CbxArticulos.SelectedItem;

            int art = item.Codigo;
            string nom = item.Descripcion;
            double pre = item.Precio;
            int tipo = item.Tipo;
            int stk = item.Stock;
            int libre = item.VentaLibre;
            Suministro a = new Suministro(art, nom, pre,libre,tipo,stk);
            int cantidad = Convert.ToInt32(TbxCantidad.Text);
            double precioVenta = pre;
            bool cubierto= checkCubierto.Checked;

            Detalle detalle = new Detalle(a, cantidad, precioVenta, cubierto);
            nueva.AgregarDetalle(detalle);
            DgvDetalles.Rows.Add(new object[] { a.Descripcion,
            cubierto,cantidad, precioVenta});
            CalcularTotal();
        }

        private void DgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvDetalles.CurrentCell.ColumnIndex == 4 && DgvDetalles.Rows.Count > 0)
            {
                nueva.QuitarDetalle(DgvDetalles.CurrentRow.Index);
                //click button:
                DgvDetalles.Rows.Remove(DgvDetalles.CurrentRow);
                //presupuesto.quitarDetalle();
                CalcularTotal();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (TbxCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar un cliente!", "Control",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (CbxFormaPago.SelectedIndex == -1)
            {
                MessageBox.Show("Debe ingresar una forma de pago!", "Control",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (CbxObrasSociales.SelectedIndex == -1)
            {
                MessageBox.Show("Debe ingresar una obra social o elegir 'sin obra'!", "Control",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (DgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos detalle!",
                "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            GuardarVenta();
        }
        private async Task<bool> GuardarVentaAsync(Venta oVenta)
        {
            string url = urlApi+"venta";
            string facturaJson = JsonConvert.SerializeObject(oVenta);
            var result = await ClienteSingleton.GetInstance().PostAsync(url, facturaJson);
            return result.Equals("true");
        }

        private async void GuardarVenta()
        {
            nueva.Cliente = TbxCliente.Text;
            nueva.FormaPago = Convert.ToInt32(CbxFormaPago.SelectedValue);
            nueva.ObraSocial = Convert.ToInt32(CbxObrasSociales.SelectedValue);
            nueva.Fecha = DtpFecha.Value;
            if (await GuardarVentaAsync(nueva))
            {
                MessageBox.Show("Venta registrada", "Informe",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar la venta\nRevise que aun quede stock de los productos",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbxArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Suministro item = (Suministro)CbxArticulos.SelectedItem;
            if (item == null) return;
            if (item.VentaLibre == 1)
            {
                checkCubierto.Enabled = true;
            }
            else if (item.VentaLibre == 0)
            {
                checkCubierto.Enabled = false;
                checkCubierto.Checked = true;
            }
            else
            {
                checkCubierto.Enabled = false;
                checkCubierto.Checked = false;
            }
        }
    }
}
