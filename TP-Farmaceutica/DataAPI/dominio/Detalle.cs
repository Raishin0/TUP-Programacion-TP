using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApi.dominio
{
    public class Detalle
    {
        private Suministro articulo;
        private int cantidad;
        private double precioVenta;

        public Suministro Articulo { get { return articulo; } set { articulo = value; } }
        public int Cantidad { get { return cantidad; } set { cantidad = value; } }
        public double PrecioVenta { get => precioVenta; set => precioVenta = value; }

        public Detalle(Suministro articulo, int cantidad, double precioVenta)
        {
            this.articulo = articulo;
            this.cantidad = cantidad;
            this.precioVenta = precioVenta;
        }

        public double CalcularSubtotal()
        {
            return articulo.Precio * cantidad;
        }

        public override string ToString()
        {
            return articulo.Codigo.ToString() + " " + cantidad.ToString();
        }
    }
}
