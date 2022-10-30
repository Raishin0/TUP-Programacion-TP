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
        private bool ventaLibre;
        private int tipo;

        public int Codigo { get { return codigo; } set { codigo = value; } }
        public string Descripcion { get { return descripcion; } set { descripcion = value; } }
        public double Precio { get { return precio; } set { precio = value; } }
        public bool VentaLibre { get => ventaLibre; set => ventaLibre = value; }
        public int Tipo { get => tipo; set => tipo = value; }

        public Suministro()
        {
            codigo = -1;
            descripcion = "";
            precio = 0;
            ventaLibre = false;
            tipo = -1;
        }
        public Suministro(int codigo, string descripcion, double precio, bool ventaLibre, int tipo)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.precio = precio;
            this.ventaLibre = ventaLibre;
            this.tipo = tipo;
        }

        public override string ToString()
        {
            return descripcion.ToUpper() + ", $" + precio.ToString();
        }
    }
}
