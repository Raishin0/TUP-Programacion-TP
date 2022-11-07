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
    public partial class frmPrincipalFacha : Form
    {
        string urlApi = "http://localhost:5191/";
        bool sideBarExpandida;
        bool reportesMenuExpandido, ventasMenuExpandido, suministrosMenuExpandido;
        public frmPrincipalFacha()
        {
            InitializeComponent();
        }

        private void SelectorBotones(bool selector)
        {
            this.btnSalir.Enabled =
                this.btnReportes.Enabled =
                this.btnVentas.Enabled =
                this.btnSuministros.Enabled = selector;
        }

        private void Login()
        {
            new FrmLogin(urlApi).ShowDialog();
        }

        private void frmPrincinpal_Load(object sender, EventArgs e)
        {
            Login();
            sideBarExpandida = false;
            SelectorBotones(false);
        }

        private void SideBarTimer_Tick(object sender, EventArgs e)
        {
            if (sideBarExpandida)
            {
                flpSideBar.Width -= 10;

                if (flpSideBar.MinimumSize.Width == flpSideBar.Width)
                {
                    sideBarExpandida = false;
                    sideBarTimer.Stop();
                }
            }
            else
            {
                flpSideBar.Width += 10;
                if (flpSideBar.MaximumSize.Width == flpSideBar.Width)
                {
                    sideBarExpandida = true;
                    sideBarTimer.Stop();
                }
            }
        }

        private void pbRetraerBarra_Click(object sender, EventArgs e)
        {
            pbRetraerBarra.Visible = false;
            pbExpandirBarra.Visible = true;
            SelectorBotones(false);
            if (reportesMenuExpandido)
            {
                ContenedorDeReportes.Height = ContenedorDeReportes.MinimumSize.Height;
                reportesMenuExpandido = false;

            }
            sideBarTimer.Start();
        }

        private void pbExpandirBarra_Click(object sender, EventArgs e)
        {
            pbRetraerBarra.Visible = true;
            pbExpandirBarra.Visible = false;
            SelectorBotones(true);
            sideBarTimer.Start();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            if (reportesMenuExpandido)
            {
                reportesTimer.Start();
                reportesMenuExpandido = ExpandirORetraerMenu(ContenedorDeReportes, reportesTimer, reportesMenuExpandido);
            }
            if (suministrosMenuExpandido)
            {
                suministrosTimer.Start();
                suministrosMenuExpandido = ExpandirORetraerMenu(ContenedorSuministros, suministrosTimer, suministrosMenuExpandido);
            }

            VentasTimer.Start();
        }

        private void btnSuministros_Click(object sender, EventArgs e)
        {
            if (reportesMenuExpandido)
            {
                reportesTimer.Start();
                reportesMenuExpandido = ExpandirORetraerMenu(ContenedorDeReportes, reportesTimer, reportesMenuExpandido);
            }
            if (ventasMenuExpandido)
            {
                VentasTimer.Start();
                ventasMenuExpandido = ExpandirORetraerMenu(contenedorVentas, VentasTimer, ventasMenuExpandido);
            }

            suministrosTimer.Start();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (ventasMenuExpandido)
            {
                VentasTimer.Start();
                ventasMenuExpandido = ExpandirORetraerMenu(contenedorVentas, VentasTimer, ventasMenuExpandido);
            }
            if (suministrosMenuExpandido)
            {
                suministrosTimer.Start();
                suministrosMenuExpandido = ExpandirORetraerMenu(ContenedorSuministros, suministrosTimer, suministrosMenuExpandido);
            }

            reportesTimer.Start();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere salir de la aplicación?", "Salir", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private bool ExpandirORetraerMenu(Panel contenedor, System.Windows.Forms.Timer timer, bool estaExpandido)
        {
            bool Estadofinal = estaExpandido;
            if (estaExpandido)
            {
                contenedor.Height -= 10;

                if (contenedor.MinimumSize.Height == contenedor.Height)
                {
                    Estadofinal = false;
                    timer.Stop();
                }
            }
            else
            {
                contenedor.Height += 10;
                if (contenedor.MaximumSize.Height == contenedor.Height)
                {
                    timer.Stop();
                    Estadofinal = true;
                }
            }

            return Estadofinal;
        }

        private void ReportesTimer_Tick(object sender, EventArgs e)
        {
            reportesMenuExpandido = ExpandirORetraerMenu(ContenedorDeReportes, reportesTimer, reportesMenuExpandido);
        }

        private void VentasTimer_Tick(object sender, EventArgs e)
        {
            ventasMenuExpandido = ExpandirORetraerMenu(contenedorVentas, VentasTimer, ventasMenuExpandido);
        }

        private void suministrosTimer_Tick_1(object sender, EventArgs e)
        {
            suministrosMenuExpandido = ExpandirORetraerMenu(ContenedorSuministros, suministrosTimer, suministrosMenuExpandido);
        }

        // Ventas
        private void btnModificarVenta_Click(object sender, EventArgs e)
        {
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            new FrmNuevaVenta(urlApi).ShowDialog();
        }

        private void btnConsultarVentas_Click(object sender, EventArgs e)
        {
            new FrmConsultarVentas(urlApi).ShowDialog();
        }

        // Suminitros
        private void btnNuevoSuministro_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultarSuministro_Click(object sender, EventArgs e)
        {

        }

        private void btnModificarSuministro_Click(object sender, EventArgs e)
        {

        }

        // Reportes
        private void btnReporte1_Click(object sender, EventArgs e)
        {

        }

        private void btnReporte2_Click(object sender, EventArgs e)
        {

        }
    }
}