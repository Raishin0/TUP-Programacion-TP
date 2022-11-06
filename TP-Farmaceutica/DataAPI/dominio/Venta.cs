using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApi.dominio
{
    public class Venta
    {
        private int codigo;
        private DateTime fecha;
        private int empleado;
        private string cliente;
        private int formaPago;
        private int obraSocial;
        private List<Detalle> detalles;

        public int Codigo { get { return codigo; } set { codigo = value; } }
        public DateTime Fecha { get { return fecha; } set { fecha = value; } }
        public int FormaPago { get { return formaPago; } set { formaPago = value; } }
        public string Cliente { get { return cliente; } set { cliente = value; } }
        public List<Detalle> Detalles { get { return detalles; } set { detalles = value; } }
        public int Empleado { get => empleado; set => empleado = value; }
        public int ObraSocial { get => obraSocial; set => obraSocial = value; }

        public Venta()
        {
            codigo = -1;
            fecha = DateTime.Now;
            formaPago = -1;
            cliente = "";
            detalles = new List<Detalle>();
            empleado = -1;
            obraSocial = -1;
        }

        public Venta(int codigo, DateTime fecha, int formaPago, string cliente, int proveedor, int obraSocial)
        {
            this.codigo = codigo;
            this.fecha = fecha;
            this.formaPago = formaPago;
            this.cliente = cliente;
            detalles = new List<Detalle>();
            this.empleado = proveedor;
            this.obraSocial = obraSocial;
        }

        public void AgregarDetalle(Detalle nuevoDetalle)
        {
            detalles.Add(nuevoDetalle);
        }

        public void QuitarDetalle(int numDetalle)
        {
            detalles.RemoveAt(numDetalle);
        }

        public double CalcularTotal()
        {
            double total = 0;
            foreach (Detalle detalle in detalles)
            {
                total += detalle.CalcularSubtotal();
            }
            return total;
        }

        public override string ToString()
        {
            return codigo.ToString() + " " + fecha.ToString() + " " + formaPago.ToString() + " " + cliente.ToString();
        }
    }
}
