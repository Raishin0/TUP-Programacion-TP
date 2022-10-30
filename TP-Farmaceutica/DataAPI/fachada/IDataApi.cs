using DataApi.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.fachada
{
    public interface IDataApi
    {
        List<Suministro> ObtenerArticulos();
        Dictionary<int, string> ObtenerFormasPago();
        int ObtenerProximoNro();
        bool Crear(Venta oFactura);
        bool Actualizar(Venta oFactura);
        bool Borrar(int nro);
        List<Venta> ObtenerFacturasPorFiltros(DateTime desde, DateTime hasta, string cliente);
        Venta ObtenerFacturaPorNro(int nro);
        DataTable ObtenerReporte(DateTime desde, DateTime hasta);
    }
}
