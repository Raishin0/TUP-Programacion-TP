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

        public FrmConsultarVentas(string urlApi)
        {
            this.urlApi = urlApi;
            InitializeComponent();
        }

        private async Task CargarFacturasAsync()
        {
            string url = urlApi + string.Format("ventas?inicio={0}&final={1}&cliente={2}",
                DtpPrimeraFecha.Value, DtpUltimaFecha.Value, TbxCliente.Text);
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Venta> lst = JsonConvert.DeserializeObject<List<Venta>>(data);
            DgvFacturas.Rows.Clear();
            foreach(Venta fila in lst)
            {
                DgvFacturas.Rows.Add(new object[] { fila.Codigo, fila.Fecha, fila.FormaPago, fila.Cliente});
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
            }

            if (DgvFacturas.CurrentCell.ColumnIndex == 6)
            {
                ModificarVenta((int)DgvFacturas.CurrentRow.Cells[0].Value,
                    (DateTime)DgvFacturas.CurrentRow.Cells[1].Value, 
                    (int)DgvFacturas.CurrentRow.Cells[2].Value,
                    (string)DgvFacturas.CurrentRow.Cells[3].Value,
                    (int)DgvFacturas.CurrentRow.Cells[4].Value);
            }
            if (DgvFacturas.CurrentCell.ColumnIndex == 7)
            {
                VerFactura((int)DgvFacturas.CurrentRow.Cells[0].Value);
            }
        }

        private void ModificarVenta(int nro, DateTime fecha, int formaPago, string cliente, int obraSocial)
        {
            Venta venta = new Venta(nro, fecha, formaPago, cliente, obraSocial);
            FrmModificarVentas frmModificarFactura = new FrmModificarVentas(venta,urlApi);
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
            throw new NotImplementedException();
        }

        private void VerFactura(int nro)
        {
            FrmDetallesVentas frmDetallesFactura = new FrmDetallesVentas(nro);
            frmDetallesFactura.Show();
        }
        private void FrmConsultarFacturas_Load(object sender, EventArgs e)
        {
            DtpPrimeraFecha.Format = DateTimePickerFormat.Short;
            DtpUltimaFecha.Format = DateTimePickerFormat.Short;
            DtpUltimaFecha.Value = DateTime.Today;
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            CargarFacturasAsync();
        }
    }
}
