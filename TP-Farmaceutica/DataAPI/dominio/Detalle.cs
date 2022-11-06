using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApi.dominio
{
    public class Detalle
    {
        private Suministro suministro;
        private int cantidad;
        private double precioVenta;
        private bool cubierto;

        public Suministro Suministro { get { return suministro; } set { suministro = value; } }
        public int Cantidad { get { return cantidad; } set { cantidad = value; } }
        public double PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public bool Cubierto { get => cubierto; set => cubierto = value; }

        public Detalle(Suministro articulo, int cantidad, double precioVenta, bool cubierto)
        {
            this.suministro = articulo;
            this.cantidad = cantidad;
            this.precioVenta = precioVenta;
            this.cubierto = cubierto;
        }

        public double CalcularSubtotal()
        {
            return suministro.Precio * cantidad;
        }

        public override string ToString()
        {
            return suministro.Codigo.ToString() + " " + cantidad.ToString();
        }
    }
}
