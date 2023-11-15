using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Contrato
    {
        private int contratoid;
        private DateTime fechainicio;
        private DateTime fechafinalizacion;
        private string tipocontrato;
        private int estadocontratoid;
        private string demanda;
        private int cantidad;
        private int usuarioid;
        private int published;

        public int Contratoid { get => contratoid; set => contratoid = value; }
        public DateTime Fechainicio { get => fechainicio; set => fechainicio = value; }
        public DateTime Fechafinalizacion { get => fechafinalizacion; set => fechafinalizacion = value; }
        public string Tipocontrato { get => tipocontrato; set => tipocontrato = value; }
        public int Estadocontratoid { get => estadocontratoid; set => estadocontratoid = value; }
        public string Demanda { get => demanda; set => demanda = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Usuarioid { get => usuarioid; set => usuarioid = value; }
        public int Published { get => published; set => published = value; }

        public Contrato() { }
        public Contrato(int contratoid, DateTime fechainicio, DateTime fechafinalizacion, string tipocontrato, int estadocontratoid, string demanda, int cantidad, int usuarioid, int published)
        {
            this.Contratoid = contratoid;
            this.Fechainicio = fechainicio;
            this.Fechafinalizacion = fechafinalizacion;
            this.Tipocontrato = tipocontrato;
            this.Estadocontratoid = estadocontratoid;
            this.Demanda = demanda;
            this.Cantidad = cantidad;
            this.Usuarioid = usuarioid;
            this.Published = published;
        }
    }
}
