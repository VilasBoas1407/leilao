using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class LeilaoRepository
    {
        DB_LEILAOEntities db = new DB_LEILAOEntities();

        public void Insert(TB_LEILAO Leilao)
        {
            db.TB_LEILAO.Add(Leilao);
            db.SaveChanges();
        }

        public List<TB_LEILAO> GetAll()
        {
            List<TB_LEILAO> lstLeilao = new List<TB_LEILAO>();
            lstLeilao = db.TB_LEILAO.ToList();
            return lstLeilao;
        }
    }
}
