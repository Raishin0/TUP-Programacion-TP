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
using FrontFarmaceutica.servicios;

namespace FrontFarmaceutica.formularios
{
    public partial class FrmDetallesVentas : Form
    {
        string urlApi;
        int nroVenta;
        Venta venta;
        public FrmDetallesVentas(int nroVenta, string urlApi)
        {
            this.urlApi = urlApi;
            this.nroVenta = nroVenta;
            venta = new Venta();
            InitializeComponent();
        }

        private async void FrmDetallesFactura_LoadAsync(object sender, EventArgs e)
        {
            await CargarComboAsync();
            CargarFactura();
            LblFactura.Text = "Venta Nº" + nroVenta;
        }
    
        private async Task CargarComboAsync()
        {
            string url = urlApi + "formaspago";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            Dictionary<int, string> lst = JsonConvert.DeserializeObject<Dictionary<int, string>>(data);
            CbxFormaPago.DataSource = new BindingSource(lst, null);
            CbxFormaPago.DisplayMember = "Value";
            CbxFormaPago.ValueMember = "Key";
            CbxFormaPago.SelectedIndex = -1;
        }


        private async void CargarFactura()
        {
            await ObtenerFacturaPorNroAsync(nroVenta);
            TbxCliente.Text = venta.Cliente;
            CbxFormaPago.SelectedValue = venta.FormaPago;
            DtpFecha.Value = venta.Fecha;

            foreach (Detalle detalle in venta.Detalles)
            {
                DgvDetalles.Rows.Add(new object[] { detalle.Suministro.Descripcion, detalle.Cantidad, detalle.Cubierto, detalle.Suministro.Precio });
            }
            CalcularTotal();
        }

        private async Task ObtenerFacturaPorNroAsync(int nroVenta)
        {
            string url = urlApi + "venta/" + nroVenta;
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            venta = JsonConvert.DeserializeObject<Venta>(data);
        }

        private void CalcularTotal()
        {
            double total = venta.CalcularTotal();
            TbxTotal.Text = total.ToString();
        }
       

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
