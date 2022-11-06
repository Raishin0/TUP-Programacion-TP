using DataApi.dominio;
using System.Data;

namespace DataApi.datos.Interfaz
{
    public interface IDaoFactura
    {
        bool Login(string nombre, string password);
        Dictionary<int, string> ObtenerFormasPago();
        Dictionary<int, string> ObtenerObrasSociales();
        Dictionary<int, string> ObtenerTiposSuministro();
        int ObtenerProximoNro();
        bool CrearVenta(Venta venta);
        bool ActualizarVenta(Venta venta);
        bool BorrarVenta(int nro);
        bool CrearSuministro(Suministro suministro);
        bool ActualizarSuministro(Suministro suministro);
        bool BorrarSuministro(int nro);
        List<Venta> ObtenerVentasPorFiltros(DateTime desde, DateTime hasta, string cliente);
        List<Suministro> ObtenerSuministros();
        Venta ObtenerVentaPorNro(int nro);
        DataTable ObtenerReporteVentas(DateTime desde, DateTime hasta);
        DataTable ObtenerReporteSuministros();
    }
}
