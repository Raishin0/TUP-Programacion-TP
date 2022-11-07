using FrontFarmaceutica.servicios;
using NetFrameworkFront;
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
    public partial class FrmPrincipal : Form
    {
        string urlApi = "http://localhost:5023/";
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            new FrmLogin(urlApi).ShowDialog();
        }

        private void MenuArchivo_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Salir" &&
                MessageBox.Show("Seguro que desea salir?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                Close();
            }
        }

        

        private void MenuFacturas_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Nueva Factura")
            {
                FrmNuevaVenta frmNuevaFactura = new FrmNuevaVenta(urlApi);
                frmNuevaFactura.Show();
            }
            if (e.ClickedItem.Text == "Consultar Facturas")
            {
                FrmConsultarVentas frmConsultarFacturas = new FrmConsultarVentas(urlApi);
                frmConsultarFacturas.Show();
            }
        }

        private void consultarArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultarSuministros frmConsultarArticulos = new FrmConsultarSuministros();
            frmConsultarArticulos.Show();
        }


        private void consultarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmReporteVentas frmReporteVentas = new FrmReporteVentas(urlApi);
            frmReporteVentas.Show();
        }

        private void quienesSomosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Facturacion App", "Caso de la guia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
