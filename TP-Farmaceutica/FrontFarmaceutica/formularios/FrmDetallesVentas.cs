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
        string urlApi = "http://localhost:5023/";
        int nroVenta;
        Venta venta;
        public FrmDetallesVentas(int nroVenta)
        {
            this.nroVenta = nroVenta;
            InitializeComponent();
        }

        private async void FrmDetallesFactura_LoadAsync(object sender, EventArgs e)
        {
            await CargarComboAsync();
            CargarFactura();
        }
    


        private async Task CargarComboAsync()
        {
            string url = urlApi + "formasDePago";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            Dictionary<int, string> lst = JsonConvert.DeserializeObject<Dictionary<int, string>>(data);
            CbxFormaPago.DataSource = new BindingSource(lst, null);
            CbxFormaPago.DisplayMember = "Value";
            CbxFormaPago.ValueMember = "Key";
            CbxFormaPago.SelectedIndex = -1;
        }


        private void CargarFactura()
        {
            venta = ObtenerFacturaPorNro(nroVenta);
            TbxCliente.Text = venta.Cliente;
            CbxFormaPago.SelectedValue = venta.FormaPago;
            DtpFecha.Value = venta.Fecha;

            foreach (Detalle detalle in venta.Detalles)
            {
                DgvDetalles.Rows.Add(new object[] { detalle.Suministro.Descripcion, detalle.Cantidad, detalle.Suministro.Precio });
            }
            CalcularTotal();
        }

        private Venta ObtenerFacturaPorNro(int nroVenta)
        {
            throw new NotImplementedException();
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
