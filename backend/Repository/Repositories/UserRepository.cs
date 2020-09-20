using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository
    {
        DB_LEILAOEntities db = new DB_LEILAOEntities();

        public bool ValidUser(string DS_USUARIO)
        {
            bool validUser = true;

            TB_USUARIO user = new TB_USUARIO();
            user = db.TB_USUARIO.Where(u => u.DS_USUARIO == DS_USUARIO).FirstOrDefault();

            if (user != null)
                validUser = false;

            return validUser;
        }

        public void Insert(TB_USUARIO user)
        {
            try
            {
                user = db.TB_USUARIO.Add(user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TB_USUARIO Login(string DS_USUARIO, string DS_SENHA)
        {
            TB_USUARIO user = new TB_USUARIO();
            try
            {
                user = db.TB_USUARIO
                    .Where(u => u.DS_USUARIO == DS_USUARIO
                            && u.DS_SENHA == DS_SENHA
                            && u.FL_ATIVO == true)
                    .FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TB_USUARIO> GetAll()
        {
            List<TB_USUARIO> lstUsers = new List<TB_USUARIO>();

            lstUsers = db.TB_USUARIO
                .Where(u => u.FL_ATIVO == true)
                .ToList();

            return lstUsers;
        }
    }
}
