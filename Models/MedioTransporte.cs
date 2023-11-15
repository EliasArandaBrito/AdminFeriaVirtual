using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MedioTransporte
    {
        private int medioid;
        private string patente;
        private float ancho;
        private float largo;
        private float alto;
        private float capacidad;
        private int refrigerado;
        private float precio;
        private int transportistaid;

        
        public MedioTransporte() { }

        public MedioTransporte(int medioid, string patente, float ancho, float largo, float alto, float capacidad, int refrigerado, float precio, int transportistaid)
        {
            this.medioid = medioid;
            this.patente = patente;
            this.ancho = ancho;
            this.largo = largo;
            this.alto = alto;
            this.capacidad = capacidad;
            this.refrigerado = refrigerado;
            this.precio = precio;
            this.transportistaid = transportistaid;
        }

        public int Medioid { get => medioid; set => medioid = value; }
        public string Patente { get => patente; set => patente = value; }
        public float Ancho { get => ancho; set => ancho = value; }
        public float Largo { get => largo; set => largo = value; }
        public float Alto { get => alto; set => alto = value; }
        public float Capacidad { get => capacidad; set => capacidad = value; }
        public int Refrigerado { get => refrigerado; set => refrigerado = value; }
        public float Precio { get => precio; set => precio = value; }
        public int Transportistaid { get => transportistaid; set => transportistaid = value; }
    }
}
