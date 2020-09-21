using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class User
    {
        public int ID_USUARIO { get; set; }
        public string DS_USUARIO { get; set; }
        public string DS_SENHA { get; set; }
        public bool FL_ATIVO { get; set; }
        public string TOKEN { get; set; }

    }
}
