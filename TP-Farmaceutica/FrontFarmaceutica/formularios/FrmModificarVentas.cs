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
    public partial class FrmModificarVentas : Form
    {
        string urlApi;
        Venta venta;

        public FrmModificarVentas(Venta venta, string urlApi)
        {
            this.venta = venta;
            this.urlApi = urlApi;
            InitializeComponent();
        }

        private async void FrmModificarFactura_LoadAsync(object sender, EventArgs e)
        {
            await CargarComboObrasSocialesAsync();
            await CargarArticulosAsync();
            await CargarComboFormasPagoAsync();
            CargarFactura();
            LblFactura.Text = "Modificar Venta Nº" + venta.Codigo;
        }
        private async Task CargarArticulosAsync()
        {
            string url = urlApi+"suministros";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Suministro> lst = JsonConvert.DeserializeObject<List<Suministro>>(data);
            CbxArticulos.DataSource = lst;
            CbxArticulos.DisplayMember = "descripcion";
            CbxArticulos.ValueMember = "codigo";
        }



        private async Task CargarComboFormasPagoAsync()
        {
            string url = urlApi + "formaspago";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            Dictionary<int, string> lst = JsonConvert.DeserializeObject<Dictionary<int, string>>(data);
            CbxFormaPago.DataSource = new BindingSource(lst, null);
            CbxFormaPago.DisplayMember = "Value";
            CbxFormaPago.ValueMember = "Key";
        }

        private async Task CargarComboObrasSocialesAsync()
        {
            string url = urlApi + "obrassociales";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            Dictionary<int, string> lst = JsonConvert.DeserializeObject<Dictionary<int, string>>(data);
            CbxObrasSociales.DataSource = new BindingSource(lst, null);
            CbxObrasSociales.DisplayMember = "Value";
            CbxObrasSociales.ValueMember = "Key";
        }

        private async Task ObtenerFacturaPorNroAsync(int nroVenta)
        {
            string url = urlApi + "venta/" + nroVenta;
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            venta = JsonConvert.DeserializeObject<Venta>(data);
        }

        private async void CargarFactura()
        {
            TbxCliente.Text = venta.Cliente;
            CbxFormaPago.SelectedValue = venta.FormaPago;
            CbxObrasSociales.SelectedValue = venta.ObraSocial;
            DtpFecha.Value = venta.Fecha;

            await ObtenerFacturaPorNroAsync(venta.Codigo);
            foreach (Detalle d in venta.Detalles)
            {
                DgvDetalles.Rows.Add(new object[] { d.Suministro.Descripcion, d.Cantidad, d.Cubierto, d.Suministro.Precio });
            }
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            double total = venta.CalcularTotal();
            TbxTotal.Text = total.ToString();
        }

        private async void GuardarFactura()
        {
            venta.Cliente = TbxCliente.Text;
            venta.FormaPago = Convert.ToInt32(CbxFormaPago.SelectedValue);
            venta.Fecha = DtpFecha.Value;
            venta.ObraSocial = Convert.ToInt32(CbxObrasSociales.SelectedValue);

            if (await ActualizarAsync(venta))
            {
                MessageBox.Show("Factura modificada", "Informe",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo modificar la factura",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> ActualizarAsync(Venta venta)
        {
            string url = urlApi+"venta/" + venta.Codigo;
            string facturaJson = JsonConvert.SerializeObject(venta);
            var result = await ClienteSingleton.GetInstance().PutAsync(url, facturaJson);
            return result.Equals("true");
        }

        private void DgvDetalles_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvDetalles.CurrentCell.ColumnIndex == 4)
            {
                venta.QuitarDetalle(DgvDetalles.CurrentRow.Index);
                DgvDetalles.Rows.Remove(DgvDetalles.CurrentRow);
                CalcularTotal();
            }
        }

        private void BtnAgregar_Click_1(object sender, EventArgs e)
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
            if (DgvDetalles.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in DgvDetalles.Rows)
                {
                    if (row.Cells["Articulo"].Value.ToString().Equals(CbxArticulos.Text))
                    {
                        if (MessageBox.Show("Ya se agrego este producto\n¿Quiere sumar esta cantidad?", "Control",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            int valor = int.Parse(row.Cells["Cantidad"].Value.ToString()) + int.Parse(TbxCantidad.Text);
                            row.Cells["Cantidad"].Value = valor.ToString();
                            venta.Detalles[row.Index].Cantidad = valor;
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
            Suministro a = new Suministro(art, nom, pre, libre, tipo, stk);
            int cantidad = Convert.ToInt32(TbxCantidad.Text);
            double precioVenta = pre;
            bool cubierto = false;

            Detalle detalle = new Detalle(a, cantidad, precioVenta, cubierto);
            venta.AgregarDetalle(detalle);
            DgvDetalles.Rows.Add(new object[] { a.Descripcion,
             cantidad,cubierto, precioVenta});
            CalcularTotal();
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
            GuardarFactura();
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
