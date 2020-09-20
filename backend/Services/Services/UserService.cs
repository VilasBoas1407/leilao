using Domain;

using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
        HashService hashService = new HashService();

        public void InsertUser(TB_USUARIO User)
        {
            bool validUser;
            try
            {

                if (string.IsNullOrEmpty(User.DS_USUARIO) || string.IsNullOrEmpty(User.DS_SENHA))
                    throw new Exception("Favor preencher todos os campos!");

                validUser = userRepository.ValidUser(User.DS_USUARIO);

                if (!validUser)
                {
                    throw new Exception("Usuário já cadastrado!");
                }
                User.FL_ATIVO = true;
                User.DS_SENHA = hashService.CriptografarSenha(User.DS_SENHA);
                userRepository.Insert(User);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TB_USUARIO LoginUser(string DS_USUARIO, string DS_SENHA)
        {
            try
            {
                TB_USUARIO User = new TB_USUARIO();

                if (string.IsNullOrEmpty(DS_USUARIO) && !string.IsNullOrEmpty(DS_SENHA))
                    throw new Exception("Favor preencher todos os campos!");

                DS_SENHA = hashService.CriptografarSenha(DS_SENHA);
                User = userRepository.Login(DS_USUARIO, DS_SENHA);

                return User;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TB_USUARIO> GetAll()
        {
            List<TB_USUARIO> lstUsers = new List<TB_USUARIO>();

            try
            {
                lstUsers = userRepository.GetAll();
                return lstUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
