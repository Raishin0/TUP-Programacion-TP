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
        List<Venta> ventas, ventasEnPapelera;
        public FrmConsultarVentas(string urlApi)
        {
            this.urlApi = urlApi;
            InitializeComponent();
            ventas = new List<Venta>();
            ventasEnPapelera = new List<Venta>();
        }

        private async Task CargarFacturasAsync()
        {
            string url = urlApi + string.Format("ventas?desde={0}&hasta={1}&cliente={2}",
                DtpPrimeraFecha.Value, DtpUltimaFecha.Value, TbxCliente.Text);
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Venta> lst = JsonConvert.DeserializeObject<List<Venta>>(data);
            ventas.Clear();
            ventasEnPapelera.Clear();
            foreach(Venta v in lst)
            {
                if (v.Habilitada)
                    ventas.Add(v);
                else
                    ventasEnPapelera.Add(v);
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
                QuitarVenta((int)DgvFacturas.CurrentRow.Cells[0].Value);
                DgvFacturas.Rows.Remove(DgvFacturas.CurrentRow);
            }
            else
            {
                if (DgvFacturas.CurrentCell.ColumnIndex == 6)
                {
                    ModificarVenta(ventas[DgvFacturas.CurrentRow.Index]);
                    DgvFacturas.Rows.Clear();
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

        private void QuitarVenta(int nro)
        {
            if (MessageBox.Show($"Seguro que quiere quitar la factura Nº{nro}?",
                "Borrar",MessageBoxButtons.YesNo,MessageBoxIcon.Information) 
                == DialogResult.Yes)
            {
                if(BorrarVenta(nro))
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

        private bool BorrarVenta(int nro)
        {
            string url = urlApi + "venta/" + nro;
            var result = ClienteSingleton.GetInstance().DeleteAsync(url);
            return result.Equals("true");
        }

        private void VerFactura(int nro, string urlApi)
        {
            FrmDetallesVentas frmDetallesFactura = new FrmDetallesVentas(nro, urlApi);
            frmDetallesFactura.Show();
        }
        
            private void FrmConsultarFacturas_Load(object sender, EventArgs e)
        {
            DtpPrimeraFecha.Format = DateTimePickerFormat.Short;
            DtpUltimaFecha.Format = DateTimePickerFormat.Short;
            DtpUltimaFecha.Value = DateTime.Today;
        }

        private void ckbVentasEnPapelera_CheckedChanged(object sender, EventArgs e)
        {
            DgvFacturas.Rows.Clear();
            if (ckbVentasEnPapelera.Checked)
                DgvFacturas.Columns["Borrar"].Visible =
                    DgvFacturas.Columns["Modificar"].Visible = false;
            else
                DgvFacturas.Columns["Borrar"].Visible =
                    DgvFacturas.Columns["Modificar"].Visible = true;
        }

        private async void BtnGenerar_Click(object sender, EventArgs e)
        {
            await CargarFacturasAsync();
            DgvFacturas.Rows.Clear();
            if (ckbVentasEnPapelera.Checked)
            {
                foreach (Venta v in ventasEnPapelera)
                {
                    DgvFacturas.Rows.Add(new object[] { v.Codigo, v.Fecha, v.FormaPago, v.Cliente });
                }
            }
            else
            {
                foreach (Venta v in ventas)
                {
                    DgvFacturas.Rows.Add(new object[] { v.Codigo, v.Fecha, v.FormaPago, v.Cliente });
                }
            }
        }
    }
}
