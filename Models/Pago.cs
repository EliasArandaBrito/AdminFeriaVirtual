using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pago
    {
        private int pagoid;
        private DateTime fechapago;
        private float pago;
        private int ventaid;
        private int usuarioid;

        public int Pagoid { get => pagoid; set => pagoid = value; }
        public DateTime Fechapago { get => fechapago; set => fechapago = value; }
        public float _pago { get => pago; set => pago = value; }
        public int Ventaid { get => ventaid; set => ventaid = value; }
        public int Usuarioid { get => usuarioid; set => usuarioid = value; }

        public Pago(int pagoid, DateTime fechapago, float pago, int ventaid, int usuarioid)
        {
            this.pagoid = pagoid;
            this.fechapago = fechapago;
            this.pago = pago;
            this.ventaid = ventaid;
            this.usuarioid = usuarioid;
        }
        public Pago() { }

    }
}
