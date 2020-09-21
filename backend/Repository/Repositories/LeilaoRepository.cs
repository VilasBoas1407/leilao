using Domain;
using Domain.Classes;
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

        public List<Leilao> GetAll()
        {
            List<Leilao> leiloes = new List<Leilao>();
            IEnumerable<Leilao> lstLeilao = null;
                
            lstLeilao = (from l in db.TB_LEILAO 
                         join u in db.TB_USUARIO 
                         on new { key = l.ID_USUARIO_RESPONSAVEL } equals new { key = u.ID_USUARIO } 
                         into _u  from u in _u.DefaultIfEmpty()
                         select new Leilao
                         {
                             ID_LEILAO = l.ID_LEILAO,
                             DS_NOME_LEILAO = l.DS_NOME_LEILAO,
                             ID_USUARIO_RESPONSAVEL = u.ID_USUARIO,
                             DS_NOME_RESPONSAVEL = u.DS_USUARIO,
                             DT_ABERTURA = l.DT_ABERTURA,
                             DT_FINALIZACAO = l.DT_FINALIZACAO,
                             FL_PRODUTO_USUADO = l.FL_PRODUTO_USUADO,
                             VL_INICIAL = l.VL_INICIAL
                         }).AsEnumerable<Leilao>().ToList();

            leiloes = lstLeilao.ToList();
            return leiloes;
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
