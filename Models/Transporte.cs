using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Transporte
    {
        private int transporteid;
        private string tipotransporte;
        private DateTime fechatransporte;
        private string origen;
        private string destino;
        private string estadotransporte;
        private int medioid;

        public int Transporteid { get => transporteid; set => transporteid = value; }
        public string Tipotransporte { get => tipotransporte; set => tipotransporte = value; }
        public DateTime Fechatransporte { get => fechatransporte; set => fechatransporte = value; }
        public string Origen { get => origen; set => origen = value; }
        public string Destino { get => destino; set => destino = value; }
        public string Estadotransporte { get => estadotransporte; set => estadotransporte = value; }
        public int Medioid { get => medioid; set => medioid = value; }

        public Transporte(int transporteid, string tipotransporte, DateTime fechatransporte, string origen, string destino, string estadotransporte, int medioid)
        {
            this.Transporteid = transporteid;
            this.Tipotransporte = tipotransporte;
            this.Fechatransporte = fechatransporte;
            this.Origen = origen;
            this.Destino = destino;
            this.Estadotransporte = estadotransporte;
            this.Medioid = medioid;
        }

        public Transporte() { }
    }
}
