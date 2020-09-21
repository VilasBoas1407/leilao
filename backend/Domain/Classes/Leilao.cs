using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class Leilao
    {
        public int ID_LEILAO { get; set; }
        public string DS_NOME_LEILAO { get; set; }
        public double VL_INICIAL { get; set; }
        public bool FL_PRODUTO_USUADO { get; set; }
        public int ID_USUARIO_RESPONSAVEL { get; set; }
        public string DS_NOME_RESPONSAVEL { get; set; }
        public System.DateTime DT_ABERTURA { get; set; }
        public System.DateTime DT_FINALIZACAO { get; set; }
    }
}
