using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class HashService
    {
        public string CriptografarSenha(string DS_SENHA)
        {
            try
            {
                string hash = "";

                using (SHA1 sha1Hash = SHA1.Create())
                {
                    byte[] sourceBytes = Encoding.UTF8.GetBytes(DS_SENHA);
                    byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                    hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                }

                return hash;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
