using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Venta_Producto
    {
        private int ventaid;
        private int productoid;
        private int cantidad;
        public int Ventaid { get => ventaid; set => ventaid = value; }
        public int Productoid { get => productoid; set => productoid = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }

        public Venta_Producto(int ventaid, int productoid, int cantidad)
        {
            this.Ventaid = ventaid;
            this.Productoid = productoid;
            this.Cantidad = cantidad;
        }

        public Venta_Producto() { }
    }
}
