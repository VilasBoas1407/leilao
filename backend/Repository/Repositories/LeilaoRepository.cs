using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public TB_LEILAO GetById(int ID_LEILAO)
        {
            TB_LEILAO Leilao = new TB_LEILAO();
            Leilao = db.TB_LEILAO.Where(l => l.ID_LEILAO == ID_LEILAO).FirstOrDefault();
            return Leilao;
        }

        public void Update(TB_LEILAO Leilao)
        {
            db.TB_LEILAO.Attach(Leilao);
            db.Entry(Leilao).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int ID_LEILAO)
        {
            TB_LEILAO leilao = new TB_LEILAO();
            leilao = db.TB_LEILAO.Find(ID_LEILAO);
            db.TB_LEILAO.Attach(leilao);
            db.TB_LEILAO.Remove(leilao);
            db.SaveChanges();
        }
    }
}
