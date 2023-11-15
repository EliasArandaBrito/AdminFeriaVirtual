using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TipoUsuario
    {
        private int tipousuarioid;
        private string nombretipo;

        public int Tipousuarioid { get => tipousuarioid; set => tipousuarioid = value; }
        public string Nombretipo { get => nombretipo; set => nombretipo = value; }

        public TipoUsuario(int tipousuarioid, string nombretipo)
        {
            this.Tipousuarioid = tipousuarioid;
            this.Nombretipo = nombretipo;
        }

        public TipoUsuario() { }
    }
}
