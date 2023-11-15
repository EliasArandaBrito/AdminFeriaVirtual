using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Subasta
    {
        private int subastaid;
        private int ventaid;
        private DateTime fechainicio;
        private DateTime fechatermino;
        private float ancho_min;
        private float largo_min;
        private float alto_min;
        private float capacidad;
        private int refrigerado;
        private int finished;
        

        public Subasta() { }

        public Subasta(int subastaid, int ventaid, DateTime fechainicio, DateTime fechatermino, float ancho_min, float largo_min, float alto_min, float capacidad, int refrigerado, int finished)
        {
            this.subastaid = subastaid;
            this.ventaid = ventaid;
            this.fechainicio = fechainicio;
            this.fechatermino = fechatermino;
            this.ancho_min = ancho_min;
            this.largo_min = largo_min;
            this.alto_min = alto_min;
            this.capacidad = capacidad;
            this.refrigerado = refrigerado;
            this.finished = finished;
        }

        public int Subastaid { get => subastaid; set => subastaid = value; }
        public int Ventaid { get => ventaid; set => ventaid = value; }
        public DateTime Fechainicio { get => fechainicio; set => fechainicio = value; }
        public DateTime Fechatermino { get => fechatermino; set => fechatermino = value; }
        public float Ancho_min { get => ancho_min; set => ancho_min = value; }
        public float Largo_min { get => largo_min; set => largo_min = value; }
        public float Alto_min { get => alto_min; set => alto_min = value; }
        public float Capacidad { get => capacidad; set => capacidad = value; }
        public int Refrigerado { get => refrigerado; set => refrigerado = value; }
        public int Finished { get => finished; set => finished = value; }
    }
}
