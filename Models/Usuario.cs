using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Usuario
    {
        private int usuarioid;
        private string nombre;
        private string apellido;
        private string correoelectronico;
        private string contrasena;
        private int tipousuarioid;
        private string direccion;
        private string telefono;

        public int Usuarioid { get => usuarioid; set => usuarioid = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correoelectronico { get => correoelectronico; set => correoelectronico = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public int Tipousuarioid { get => tipousuarioid; set => tipousuarioid = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public Usuario(int usuarioid, string nombre, string apellido, string correoelectronico, string contrasena, int tipousuarioid, string direccion, string telefono)
        {
            this.Usuarioid = usuarioid;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Correoelectronico = correoelectronico;
            this.Contrasena = contrasena;
            this.Tipousuarioid = tipousuarioid;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }

        public Usuario() { }
    }
}
