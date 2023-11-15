using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Venta
    {
        private int ventaid;
        private string tipoventa;
        private DateTime fechaventa;
        private double totalventa;
        private int estadoventaid;
        private Nullable<int> transporteid;
        private Nullable<int> productorid;
        private Nullable<int> clienteid;

        public int Ventaid { get => ventaid; set => ventaid = value; }
        public string TipoVenta { get => tipoventa; set => tipoventa = value; }
        public DateTime Fechaventa { get => fechaventa; set => fechaventa = value; }
        public double Totalventa { get => totalventa; set => totalventa = value; }
        public int Estadoventaid { get => estadoventaid; set => estadoventaid = value; }
        public Nullable<int> Transporteid { get => transporteid; set => transporteid = value; }
        public Nullable<int> Productorid { get => productorid; set => productorid = value; }
        public Nullable<int> Clienteid { get => clienteid; set => clienteid = value; }

        public Venta(int ventaid, string tipoventa, DateTime fechaventa, double totalventa, int estadoventaid, Nullable<int> transporteid, Nullable<int> productorid, Nullable<int> clienteid)
        {
            this.Ventaid = ventaid;
            this.TipoVenta = tipoventa;
            this.Fechaventa = fechaventa;
            this.Totalventa = totalventa;
            this.Estadoventaid = estadoventaid;
            this.Transporteid = transporteid;
            this.Productorid = productorid;
            this.Clienteid = clienteid;
        }

        public Venta() { }

        
    }
}
