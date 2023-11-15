using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Producto
    {
        private int productoid;
        private string nombre;
        private float precio;
        private int stock;
        private int productorid;

        public int Productoid { get => productoid; set => productoid = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public float Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }
        public int Productorid { get => productorid; set => productorid = value; }
        public Producto(int productoid, string nombre, float precio, int stock, int productorid)
        {
            this.Productoid = productoid;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Stock = stock;
            this.Productorid = productorid;
        }

        public Producto() { }
    }
}
