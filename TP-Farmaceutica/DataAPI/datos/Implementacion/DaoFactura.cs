using DataApi.datos.Interfaz;
using DataApi.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataApi.datos.Implementacion
{
    public class DaoFactura : IDaoFactura
    {
        public bool Login(string nombre, string password) 
        {
            string sp = "comprobarUsuario";
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@nombreUsuario", nombre));
            parametros.Add(new Parametro("@contrasenia", password));
            DataTable t = HelperDB.ObtenerInstancia().ConsultaSQL(sp, parametros);
            int v = (int)t.Rows[0][0];
            return v > 0;
        }
        public Dictionary<int, string> ObtenerFormasPago()
        {
            Dictionary<int, string> lst = new Dictionary<int, string>();

            string sp = "consultarFormasPago";
            DataTable t = HelperDB.ObtenerInstancia().ConsultaSQL(sp, null);

            foreach (DataRow dr in t.Rows)
            {
                //Mapear un registro a un objeto del modelo de dominio
                int nro = int.Parse(dr["cod_forma_pago"].ToString());
                string nombre = dr["forma_pago"].ToString();

                lst.Add(nro, nombre);
            }

            return lst;
        }
        public Dictionary<int, string> ObtenerObrasSociales()
        {
            Dictionary<int, string> lst = new Dictionary<int, string>();

            string sp = "consultarObrasSociales";
            DataTable t = HelperDB.ObtenerInstancia().ConsultaSQL(sp, null);

            foreach (DataRow dr in t.Rows)
            {
                //Mapear un registro a un objeto del modelo de dominio
                int nro = int.Parse(dr["cod_obra_social"].ToString());
                string nombre = dr["nom_obra_social"].ToString();

                lst.Add(nro, nombre);
            }

            return lst;
        }
        public Dictionary<int, string> ObtenerTiposSuministro()
        {
            Dictionary<int, string> lst = new Dictionary<int, string>();

            string sp = "consultarTiposSuministros";
            DataTable t = HelperDB.ObtenerInstancia().ConsultaSQL(sp, null);

            foreach (DataRow dr in t.Rows)
            {
                //Mapear un registro a un objeto del modelo de dominio
                int nro = int.Parse(dr["cod_tipo_sum"].ToString());
                string nombre = dr["tipo_sum"].ToString();

                lst.Add(nro, nombre);
            }

            return lst;
        }
        public int ObtenerProximoNro()
        {
            string sp = "proximaVenta";
            return HelperDB.ObtenerInstancia().ConsultaEscalarSQL(sp, "@next");
        }
        public bool CrearVenta(Venta venta)
        {
            bool ok = true;
            SqlConnection cnn = HelperDB.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();
            try
            {

                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "insertarMaestro";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fecha", venta.Fecha);
                cmd.Parameters.AddWithValue("@cliente", venta.Cliente);
                cmd.Parameters.AddWithValue("@formaPago", venta.FormaPago);
                cmd.Parameters.AddWithValue("@codigoOS", venta.ObraSocial);

                //parámetro de salida:
                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@nro_venta";
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pOut);

                cmd.ExecuteNonQuery();
                int nro = (int)pOut.Value;

                SqlCommand cmdDetalle;
                foreach (Detalle item in venta.Detalles)
                {
                    cmdDetalle = new SqlCommand("insertarDetalle", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@nro_venta", nro);
                    cmdDetalle.Parameters.AddWithValue("@cod_suministro", item.Suministro.Codigo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@precio", item.PrecioVenta);
                    cmdDetalle.Parameters.AddWithValue("@cubierto", item.Cubierto);
                    cmdDetalle.ExecuteNonQuery();
                }
                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }
        public bool ActualizarVenta(Venta venta)
        {
            bool ok = true;
            SqlConnection cnn = HelperDB.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "modificarMaestro";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nro_venta", venta.Codigo);
                cmd.Parameters.AddWithValue("@fecha", venta.Fecha);
                cmd.Parameters.AddWithValue("@cliente", venta.Cliente);
                cmd.Parameters.AddWithValue("@formaPago", venta.FormaPago);
                cmd.Parameters.AddWithValue("@codigoOS", venta.ObraSocial);
                cmd.ExecuteNonQuery();

                SqlCommand cmdDetalle;
                foreach (Detalle item in venta.Detalles)
                {
                    cmdDetalle = new SqlCommand("modificarDetalle", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@nro_venta", venta.Codigo);
                    cmdDetalle.Parameters.AddWithValue("@cod_suministro", item.Suministro.Codigo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@precio", item.PrecioVenta);
                    cmdDetalle.Parameters.AddWithValue("@cubierto", item.Cubierto);
                    cmdDetalle.ExecuteNonQuery();

                }
                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }
        public bool BorrarVenta(int nro)
        {
            string sp = "eliminarMaestro";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@nro_venta", nro));
            int afectadas = HelperDB.ObtenerInstancia().EjecutarSQL(sp, lst);
            return afectadas > 0;
        }
        public bool CrearSuministro(Suministro suministro)
        {
            bool ok = true;
            SqlConnection cnn = HelperDB.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();
            try
            {

                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "insertarSuministro";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@descripcion", suministro.Descripcion);
                cmd.Parameters.AddWithValue("@precio_unitario", suministro.Precio);
                cmd.Parameters.AddWithValue("@venta_libre", suministro.VentaLibre);
                cmd.Parameters.AddWithValue("@cod_tipo_sum", suministro.Tipo);
                cmd.Parameters.AddWithValue("@stock", suministro.Stock);

                cmd.ExecuteNonQuery();
                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }
        public bool ActualizarSuministro(Suministro suministro)
        {
            bool ok = true;
            SqlConnection cnn = HelperDB.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();

            try
            {

                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "modificarSuministro";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_suministro", suministro.Codigo);
                cmd.Parameters.AddWithValue("@descripcion", suministro.Descripcion);
                cmd.Parameters.AddWithValue("@precio_unitario", suministro.Precio);
                cmd.Parameters.AddWithValue("@venta_libre", suministro.VentaLibre);
                cmd.Parameters.AddWithValue("@cod_tipo_sum", suministro.Tipo);
                cmd.Parameters.AddWithValue("@stock", suministro.Stock);

                cmd.ExecuteNonQuery();

                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }
        public bool BorrarSuministro(int codigo)
        {
            string sp = "eliminarSuministro";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@cod_suministro", codigo));
            int afectadas = HelperDB.ObtenerInstancia().EjecutarSQL(sp, lst);
            return afectadas > 0;
        }
        public List<Venta> ObtenerVentasPorFiltros(DateTime desde, DateTime hasta, string cliente)
        {
            List<Venta> facturas = new List<Venta>();
            string sp = "consultarVentas";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fecha1", desde));
            lst.Add(new Parametro("@fecha2", hasta));
            lst.Add(new Parametro("@cliente", cliente));
            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);

            foreach (DataRow row in dt.Rows)
            {
                Venta factura = new Venta();
                factura.Codigo = int.Parse(row["nro_venta"].ToString());
                factura.Fecha = DateTime.Parse(row["fecha"].ToString());
                factura.Cliente = row["cliente"].ToString();
                factura.FormaPago = int.Parse(row["cod_forma_pago"].ToString());
                factura.ObraSocial = int.Parse(row["cod_obra_social"].ToString());
                facturas.Add(factura);
            }

            return facturas;
        }
        public List<Venta> ObtenerVentasDeshabilitadasPorFiltros(DateTime desde, DateTime hasta, string cliente)
        {
            List<Venta> facturas = new List<Venta>();
            string sp = "consultarVentasDeshabilitadas";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fecha1", desde));
            lst.Add(new Parametro("@fecha2", hasta));
            lst.Add(new Parametro("@cliente", cliente));
            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);

            foreach (DataRow row in dt.Rows)
            {
                Venta factura = new Venta();
                factura.Codigo = int.Parse(row["nro_venta"].ToString());
                factura.Fecha = DateTime.Parse(row["fecha"].ToString());
                factura.Cliente = row["cliente"].ToString();
                factura.FormaPago = int.Parse(row["cod_forma_pago"].ToString());
                factura.ObraSocial = int.Parse(row["cod_obra_social"].ToString());
                facturas.Add(factura);
            }

            return facturas;
        }
        public List<Suministro> ObtenerSuministros()
        {
            List<Suministro> lst = new List<Suministro>();

            string sp = "consultarSuministros";
            DataTable t = HelperDB.ObtenerInstancia().ConsultaSQL(sp, null);

            foreach (DataRow dr in t.Rows)
            {
                //Mapear un registro a un objeto del modelo de dominio
                int nro = int.Parse(dr["cod_suministro"].ToString());
                string nombre = dr["descripcion"].ToString();
                double precio = double.Parse(dr["precio_unitario"].ToString());
                int ventaLibre = probar(dr["venta_libre"].ToString());
                int tipo = int.Parse(dr["cod_tipo_sum"].ToString());
                int stock = int.Parse(dr["stock"].ToString());

                Suministro sum = new Suministro(nro, nombre, precio, ventaLibre, tipo, stock);
                lst.Add(sum);

            }

            return lst;
        }
        public Venta ObtenerVentaPorNro(int nro)
        {
            Venta factura = new Venta();
            factura.Codigo = nro;
            string sp = "consultarVenta";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@nro_venta", nro));

            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);
            bool primero = true;

            foreach (DataRow fila in dt.Rows)
            {
                if (primero)
                {
                    factura.Fecha = DateTime.Parse(fila["fecha"].ToString());
                    factura.Cliente = fila["cliente"].ToString();
                    factura.FormaPago = int.Parse(fila["cod_forma_pago"].ToString());
                    factura.ObraSocial = int.Parse(fila["cod_obra_social"].ToString());
                    primero = false;
                }
                int nroProducto = int.Parse(fila["cod_suministro"].ToString());
                string nombre = fila["descripcion"].ToString();
                double precio = double.Parse(fila["precio_unitario"].ToString());
                int ventaLibre = probar(fila["venta_libre"].ToString());
                int tipo = int.Parse(fila["cod_tipo_sum"].ToString());
                Suministro producto = new Suministro(nroProducto, nombre, precio,ventaLibre,tipo,0);

                int cantidad = int.Parse(fila["cantidad"].ToString());
                double precioVenta = double.Parse(fila["precio_venta"].ToString());
                bool cubierto = bool.Parse(fila["cubierto"].ToString());
                Detalle detalle = new Detalle(producto, cantidad,precioVenta,cubierto);
                factura.AgregarDetalle(detalle);

            }

            return factura;
        }
        public DataTable ObtenerReporteVentas(DateTime desde, DateTime hasta)
        {
            string sp = "consultar_ventas";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fecha1", desde));
            lst.Add(new Parametro("@fecha2", hasta));
            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);
            return dt;
        }
        public DataTable ObtenerReporteSuministros()
        {
            string sp = "consultar_suministros";
            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, null);
            return dt;
        }

        public int probar(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return -1;
            }
            else
            {
                if(valor == "False")
                {
                    return 0;
                }
                return 1;
            }
        }
    }
}

