using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EstadoContrato
    {
        private int estadocontratoid;
        private string nombreestado;

        public int Estadocontratoid { get => estadocontratoid; set => estadocontratoid = value; }
        public string Nombreestado { get => nombreestado; set => nombreestado = value; }

        public EstadoContrato(int estadocontratoid, string nombreestado)
        {
            this.Estadocontratoid = estadocontratoid;
            this.Nombreestado = nombreestado;
        }

        public EstadoContrato() { }

    }
}
