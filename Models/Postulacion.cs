using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Postulacion
    {
        private int postulacionid;
        private Nullable<float> precio;
        private int cantidad;
        private Nullable<DateTime> fechacosecha;
        private int contratoid;
        private int productorid;
        private int selected;

        public int Postulacionid { get => postulacionid; set => postulacionid = value; }
        public Nullable<float> Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public Nullable<DateTime> Fechacosecha { get => fechacosecha; set => fechacosecha = value; }
        public int Contratoid { get => contratoid; set => contratoid = value; }
        public int Productorid { get => productorid; set => productorid = value; }
        public int Selected { get => selected; set => selected = value; }

        public Postulacion(int postulacionid, Nullable<float> precio, int cantidad, Nullable<DateTime> fechacosecha, int contratoid, int productorid, int selected)
        {
            this.Postulacionid = postulacionid;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.Fechacosecha = fechacosecha;
            this.Productorid = productorid;
            this.Contratoid = contratoid;
            this.selected = selected;
        }

        public Postulacion() { }

    }
}
