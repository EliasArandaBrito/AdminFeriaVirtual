using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Transportista
    {
        private int transportistaid;
        private string nombre;
        private string direccion;
        private string telefono;
        private string correo;

        public Transportista(int transportistaid, string nombre, string direccion, string telefono, string correo)
        {
            this.transportistaid = transportistaid;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.correo = correo;
        }

        public Transportista() { }

        public int Transportistaid { get => transportistaid; set => transportistaid = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}
