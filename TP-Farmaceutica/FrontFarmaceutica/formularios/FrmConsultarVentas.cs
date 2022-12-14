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
    public partial class FrmConsultarVentas : Form
    {
        string urlApi;
        List<Venta> ventas;
        Dictionary<int, string> formas;
        Dictionary<int, string> obras;
        public FrmConsultarVentas(string urlApi)
        {
            this.urlApi = urlApi;
            InitializeComponent();
            ventas = new List<Venta>();
        }
        private async Task CargarComboAsync()
        {
            string url = urlApi + "formaspago";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            formas = JsonConvert.DeserializeObject<Dictionary<int, string>>(data);

            url = urlApi + "obrassociales";
            var data2 = await ClienteSingleton.GetInstance().GetAsync(url);
            obras = JsonConvert.DeserializeObject<Dictionary<int, string>>(data2);

        }

        private async Task CargarFacturasAsync()
        {
            string url;
            if (!ckbVentasEnPapelera.Checked)
            {
                url = urlApi + string.Format("ventas?desde={0}&hasta={1}&cliente={2}",
                    DtpPrimeraFecha.Value, DtpUltimaFecha.Value, TbxCliente.Text);
                DgvFacturas.Columns[5].Visible = true;
                DgvFacturas.Columns[6].Visible = true;
            }
            else
            {
                url = urlApi + string.Format("ventasDeshabilitadas?desde={0}&hasta={1}&cliente={2}",
                    DtpPrimeraFecha.Value, DtpUltimaFecha.Value, TbxCliente.Text);
                DgvFacturas.Columns[5].Visible = false;
                DgvFacturas.Columns[6].Visible = false;
            }
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Venta> lst = JsonConvert.DeserializeObject<List<Venta>>(data);
            ventas.Clear();
            if(lst != null)
            {
                foreach (Venta v in lst)
                {
                    ventas.Add(v);
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvFacturas.CurrentCell.ColumnIndex == 5)
            {
                QuitarVentaAsync((int)DgvFacturas.CurrentRow.Cells[0].Value);
            }
            else
            {
                if (DgvFacturas.CurrentCell.ColumnIndex == 6)
                {
                    ModificarVenta(ventas[DgvFacturas.CurrentRow.Index]);
                }
                else
                {
                    if (DgvFacturas.CurrentCell.ColumnIndex == 7)
                    {
                        VerFactura((int)DgvFacturas.CurrentRow.Cells[0].Value, this.urlApi);
                    }
                }
            }
        }

        private void ModificarVenta(Venta v)
        {
            FrmModificarVentas frmModificarFactura = new FrmModificarVentas(v,urlApi);
            frmModificarFactura.Show();
        }

        private async Task QuitarVentaAsync(int nro)
        {
            if (MessageBox.Show($"Seguro que quiere quitar la factura Nº{nro}?",
                "Borrar",MessageBoxButtons.YesNo,MessageBoxIcon.Information) 
                == DialogResult.Yes)
            {
                if(await BorrarVentaAsync(nro))
                {
                    MessageBox.Show("Factura eliminada", "Informe",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DgvFacturas.Rows.Remove(DgvFacturas.CurrentRow);
                }
                else
                {
                    MessageBox.Show("ERROR. No se pudo eliminar la factura",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task<bool> BorrarVentaAsync(int nro)
        {
            string url = urlApi + "venta/" + nro;
            var data = await ClienteSingleton.GetInstance().DeleteAsync(url);
            bool res = JsonConvert.DeserializeObject<bool>(data);
            return res;
        }

        private void VerFactura(int nro, string urlApi)
        {
            FrmDetallesVentas frmDetallesFactura = new FrmDetallesVentas(nro, urlApi);
            frmDetallesFactura.Show();
        }
        
            private async void FrmConsultarFacturas_Load(object sender, EventArgs e)
        {
            DtpPrimeraFecha.Format = DateTimePickerFormat.Short;
            DtpUltimaFecha.Format = DateTimePickerFormat.Short;
            DtpUltimaFecha.Value = DateTime.Today;
            await CargarComboAsync();
        }

        private void ckbVentasEnPapelera_CheckedChanged(object sender, EventArgs e)
        {
        }

        private async void BtnGenerar_Click(object sender, EventArgs e)
        {
            await CargarFacturasAsync();
            DgvFacturas.Rows.Clear();
            foreach (Venta v in ventas)
            {
                DgvFacturas.Rows.Add(new object[] { v.Codigo, v.Fecha, v.Cliente, formas[v.FormaPago],obras[v.ObraSocial],null, null, null, v.FormaPago, v.ObraSocial });
            }
        }
    }
}
