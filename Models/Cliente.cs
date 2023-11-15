using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cliente
    {
        private int clienteid;
        private string nombre;
        private string tipocliente;
        private string direccion;
        private string telefono;
        private string correo;

        public int Clienteid { get => clienteid; set => clienteid = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Tipocliente { get => tipocliente; set => tipocliente = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }

        public Cliente(){}
        public Cliente(int clienteid, string nombre, string tipocliente, string direccion, string telefono, string correo)
        {
            this.Clienteid = clienteid;
            this.Nombre = nombre;
            this.Tipocliente = tipocliente;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Correo = correo;
        }
    }
}
