﻿using DataApi.datos.Implementacion;
using DataApi.datos.Interfaz;
using DataApi.dominio;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<Suministro> ObtenerArticulos()
        {
            return dao.ObtenerArticulos();
        }
        public Dictionary<int, string> ObtenerFormasPago()
        {
            return dao.ObtenerFormasPago();
        }
        public int ObtenerProximoNro()
        {
            return dao.ObtenerProximoNro();
        }
        public bool Crear(Venta oFactura)
        {
            return dao.Crear(oFactura);
        }
        public bool Actualizar(Venta oFactura)
        {
            return dao.Actualizar(oFactura);
        }
        public bool Borrar(int nro)
        {
            return dao.Borrar(nro);
        }
        public List<Venta> ObtenerFacturasPorFiltros(DateTime desde, DateTime hasta, string cliente)
        {
            return dao.ObtenerFacturasPorFiltros(desde, hasta, cliente);
        }
        public Venta ObtenerFacturaPorNro(int nro)
        {
            return dao.ObtenerFacturaPorNro(nro);
        }
        public DataTable ObtenerReporte(DateTime desde, DateTime hasta)
        {
            return dao.ObtenerReporte(desde, hasta);
        }
    }
}
