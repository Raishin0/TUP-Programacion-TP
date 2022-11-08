using Microsoft.Reporting.WinForms;
using NetFrameworkFront.Servicios;
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

namespace NetFrameworkFront
{
    public partial class FrmReporteVentas : Form
    {
        string urlApi;
        public FrmReporteVentas(string url)
        {
            InitializeComponent();
            urlApi = url;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpFechaInicial.Value = DateTime.Now;
            dtpFechaFinal.Value = DateTime.Now;
            ActivarFechas();
        }

        private async void btnGenerar_Click(object sender, EventArgs e)
        {
            string url = urlApi;
            this.rpvVentas.LocalReport.DataSources.Clear();

            if (checkBox1.Checked)
            {
                url = urlApi + string.Format("reporteventas?desde={0}&hasta={1}",
                dtpFechaInicial.Value, dtpFechaFinal.Value);
                rpvVentas.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("FechaDesde", dtpFechaInicial.Value.ToString()),
                new ReportParameter("FechaHasta", dtpFechaFinal.Value.ToString())});
            }
            else
            {
                url = urlApi + string.Format("reporteventas?desde={0}&hasta={1}",
                "1/1/2000 00:00:00", DateTime.Now);
                rpvVentas.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("FechaDesde", "1/1/2000 00:00:00"),
                new ReportParameter("FechaHasta", DateTime.Now.ToString())});
            }

            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            DataTable tablaVentas = JsonConvert.DeserializeObject<DataTable>(data);
            rpvVentas.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", tablaVentas));
            this.rpvVentas.RefreshReport();
        }

        private void ActivarFechas()
        {
            dtpFechaInicial.Enabled = checkBox1.Checked;
            dtpFechaFinal.Enabled = checkBox1.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ActivarFechas();
        }

        private void dtpFechaInicial_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInicial.Value >= dtpFechaFinal.Value.AddDays(-3))
            {
                dtpFechaInicial.Value = dtpFechaFinal.Value.AddDays(-3);
            }
        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaFinal.Value <= dtpFechaInicial.Value.AddDays(3))
            {
                dtpFechaFinal.Value = dtpFechaInicial.Value.AddDays(3);
            }
        }
    }
}
