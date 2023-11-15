using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EstadoVenta
    {
        private int estadoventaid;
        private string nombreestadoventa;

        public int Estadoventaid { get => estadoventaid; set => estadoventaid = value; }
        public string Nombreestadoventa { get => nombreestadoventa; set => nombreestadoventa = value; }

        public EstadoVenta(int estadoventaid, string nombreestadoventa)
        {
            this.Estadoventaid = estadoventaid;
            this.Nombreestadoventa = nombreestadoventa;
        }

        public EstadoVenta() { }


    }
}
