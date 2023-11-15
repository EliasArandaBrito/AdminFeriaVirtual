using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Productor
    {
        private int productorid;
        private string nombre;
        private string direccion;
        private string telefono;
        private string correo;

        public Productor(int productorid, string nombre, string direccion, string telefono, string correo)
        {
            this.productorid = productorid;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.correo = correo;
        }

        public Productor() { }

        public int Productorid { get => productorid; set => productorid = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}
