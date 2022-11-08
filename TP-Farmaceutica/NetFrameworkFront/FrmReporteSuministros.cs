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
using static System.Net.WebRequestMethods;

namespace NetFrameworkFront
{
    public partial class FrmReporteSuministros : Form
    {
        string urlApi;
        public FrmReporteSuministros(string urlApi)
        {
            InitializeComponent();
            this.urlApi = urlApi;
        }

        private async void FrmReporteSuministros_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            string url = urlApi+"reportesuministros";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            DataTable tablaSums = JsonConvert.DeserializeObject<DataTable>(data);
            reportViewer1.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", tablaSums));

            this.reportViewer1.RefreshReport();
        }
    }
}
