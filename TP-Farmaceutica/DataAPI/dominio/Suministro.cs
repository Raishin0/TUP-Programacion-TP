using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApi.dominio
{
    public class Suministro
    {
        private int codigo;
        private string descripcion;
        private double precio;
        private int ventaLibre;
        private int tipo;
        private int stock;

        public int Codigo { get { return codigo; } set { codigo = value; } }
        public string Descripcion { get { return descripcion; } set { descripcion = value; } }
        public double Precio { get { return precio; } set { precio = value; } }
        public int VentaLibre { get { return ventaLibre; } set { ventaLibre = value; } }
        public int Tipo { get { return tipo; } set { tipo = value; } }
        public int Stock { get { return stock; } set { stock = value; } }

        public Suministro()
        {
            codigo = -1;
            descripcion = "";
            precio = 0;
            ventaLibre = -1;
            tipo = -1;
            stock = -1;
        }
        public Suministro(int codigo, string descripcion, double precio, int ventaLibre, int tipo, int stock)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.precio = precio;
            this.ventaLibre = ventaLibre;
            this.tipo = tipo;
            this.stock = stock;
        }

        public override string ToString()
        {
            return descripcion.ToUpper() + ", $" + precio.ToString();
        }
    }
}
