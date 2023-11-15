using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Subasta_Medio
    {
        private int medioid;
        private int subastaid;
        private int selected;

        public int Medioid { get => medioid; set => medioid = value; }
        public int Subastaid { get => subastaid; set => subastaid = value; }
        public int Selected { get => selected; set => selected = value; }

        public Subasta_Medio(int medioid, int subastaid, int selected)
        {
            this.Medioid = medioid;
            this.Subastaid = subastaid;
            this.Selected = selected;
        }

        public Subasta_Medio() { }

    }
}
