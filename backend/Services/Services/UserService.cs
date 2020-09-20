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

        public async Task<TB_USUARIO> InsertUser(TB_USUARIO User)
        {
            bool validUser;
            try
            {
                if (string.IsNullOrEmpty(User.DS_USUARIO) && !string.IsNullOrEmpty(User.DS_SENHA))
                    throw new Exception("Favor preencher todos os campos!");

                validUser = userRepository.ValidUser(User.DS_USUARIO);

                if (!validUser)
                    throw new Exception("Usuário já cadastrado!");

                User.DS_SENHA = hashService.CriptografarSenha(User.DS_SENHA);
                User = await userRepository.Insert(User);

                return User;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TB_USUARIO> LoginUser(string DS_USUARIO, string DS_SENHA)
        {
            try
            {
                TB_USUARIO User = new TB_USUARIO();

                if (string.IsNullOrEmpty(DS_USUARIO) && !string.IsNullOrEmpty(DS_SENHA))
                    throw new Exception("Favor preencher todos os campos!");

                DS_SENHA = hashService.CriptografarSenha(DS_SENHA);
                User = await userRepository.Login(DS_USUARIO, DS_SENHA);

                return User;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
