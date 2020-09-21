using Domain;
using Domain.Classes;
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

        public User Login(string DS_USUARIO, string DS_SENHA)
        {
            User user = new User();
            try
            {
                user = (from u in db.TB_USUARIO
                        where (u.DS_USUARIO == DS_USUARIO && u.DS_SENHA == DS_SENHA && u.FL_ATIVO == true)
                        select new User
                        {
                            ID_USUARIO = u.ID_USUARIO,
                            DS_USUARIO = u.DS_USUARIO,
                            DS_SENHA = u.DS_SENHA,
                            FL_ATIVO = u.FL_ATIVO
                        }).FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<User> GetAll()
        {
            List<User> lstUsers = new List<User>();

            lstUsers = (from u in db.TB_USUARIO
                        select new User
                        {
                            ID_USUARIO = u.ID_USUARIO,
                            DS_USUARIO = u.DS_USUARIO,
                            DS_SENHA = "",
                            FL_ATIVO = u.FL_ATIVO,
                        }).ToList();

            return lstUsers;
        }
    }
}
