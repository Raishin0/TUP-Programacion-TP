﻿using FrontFarmaceutica.servicios;
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

        private FabricaServicio fabrica;
        public FrmPrincipal(FabricaServicio fabrica)
        {
            this.fabrica = fabrica;
            InitializeComponent();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            new FrmLogin(fabrica).ShowDialog();
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
                FrmNuevaFactura frmNuevaFactura = new FrmNuevaFactura();
                frmNuevaFactura.Show();
            }
            if (e.ClickedItem.Text == "Consultar Facturas")
            {
                FrmConsultarFacturas frmConsultarFacturas = new FrmConsultarFacturas(fabrica);
                frmConsultarFacturas.Show();
            }
        }

        private void consultarArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultarArticulos frmConsultarArticulos = new FrmConsultarArticulos();
            frmConsultarArticulos.Show();
        }


        private void consultarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmReporteVentas frmReporteVentas = new FrmReporteVentas(fabrica);
            frmReporteVentas.Show();
        }

        private void quienesSomosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Facturacion App", "Caso de la guia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
