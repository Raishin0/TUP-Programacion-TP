using DataApi.datos;
using DataApi.datos.Implementacion;
using DataApi.datos.Interfaz;
using DataApi.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.fachada
{
    public class DataApiImp : IDataApi
    {
        private IDaoFactura dao;

        public DataApiImp()
        {
            dao = new DaoFactura();
        }

        public bool Login(string nombre, string password)
        {
            return dao.Login(nombre, password);
        }
        public Dictionary<int, string> ObtenerFormasPago()
        {
            return dao.ObtenerFormasPago();
        }
        public Dictionary<int, string> ObtenerObrasSociales()
        {
            return dao.ObtenerObrasSociales();
        }
        public Dictionary<int, string> ObtenerTiposSuministro()
        {
            return dao.ObtenerTiposSuministro();
        }
        public int ObtenerProximoNro()
        {
            return dao.ObtenerProximoNro();
        }
        public bool CrearVenta(Venta venta)
        {
            return dao.CrearVenta(venta);
        }
        public bool ActualizarVenta(Venta venta)
        {
            return dao.ActualizarVenta(venta);
        }
        public bool BorrarVenta(int nro)
        {
            return dao.BorrarVenta(nro);
        }
        public bool CrearSuministro(Suministro suministro)
        {
            return dao.CrearSuministro(suministro);
        }
        public bool ActualizarSuministro(Suministro suministro)
        {
            return dao.ActualizarSuministro(suministro);
        }
        public bool BorrarSuministro(int codigo)
        {
            return dao.BorrarSuministro(codigo);
        }
        public List<Venta> ObtenerVentasPorFiltros(DateTime desde, DateTime hasta, string cliente)
        {
            return dao.ObtenerVentasPorFiltros(desde,hasta,cliente);
        }
        public List<Venta> ObtenerVentasDeshabilitadasPorFiltros(DateTime desde, DateTime hasta, string cliente)
        {
            return dao.ObtenerVentasDeshabilitadasPorFiltros(desde,hasta, cliente);
        }
        public List<Suministro> ObtenerSuministros()
        {
            return dao.ObtenerSuministros();
        }
        public Venta ObtenerVentaPorNro(int nro)
        {
            return dao.ObtenerVentaPorNro(nro);
        }
        public DataTable ObtenerReporteVentas(DateTime desde, DateTime hasta)
        {
            return dao.ObtenerReporteVentas(desde,hasta);
        }
        public DataTable ObtenerReporteSuministros()
        {
            return dao.ObtenerReporteSuministros();
        }
    }
}
