using Domain;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class LeilaoService
    {
        LeilaoRepository leilaoRepository = new LeilaoRepository();

        public async void InsertLeilao(TB_LEILAO Leilao)
        {
            try
            {
                ValidateFields(Leilao);
                leilaoRepository.Insert(Leilao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TB_LEILAO> GetAll()
        {
            try
            {
                List<TB_LEILAO> lstLeilao = leilaoRepository.GetAll();
                return lstLeilao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TB_LEILAO GetById(int ID_LEILAO)
        {
            try
            {
                if (string.IsNullOrEmpty(ID_LEILAO.ToString()))
                    throw new Exception("Favor passar um ID válido de leilão");

                TB_LEILAO Leilao = leilaoRepository.GetById(ID_LEILAO);
                return Leilao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(int ID_LEILAO)
        {
            try
            {
                if (string.IsNullOrEmpty(ID_LEILAO.ToString()))
                    throw new Exception("Favor passar um ID válido de leilão");

                leilaoRepository.Delete(ID_LEILAO);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void Update(TB_LEILAO Leilao)
        {
            try
            {
                ValidateFields(Leilao);
                leilaoRepository.Update(Leilao);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void ValidateFields(TB_LEILAO Leilao)
        {
            try
            {
                if (string.IsNullOrEmpty(Leilao.DS_NOME_LEILAO))
                    throw new Exception("Favor inserir um nome para o leilão!");
                if (Leilao.DT_ABERTURA == null)
                    throw new Exception("A data de abertura não pode ser nula!");
                if (Leilao.DT_FINALIZACAO == null)
                    throw new Exception("A data de finalização não pode ser nula!");
                if (Leilao.DT_FINALIZACAO > Leilao.DT_ABERTURA)
                    throw new Exception("A data de finalização não pode ser anterior a data de abertura!");
                if (Leilao.ID_USUARIO_RESPONSAVEL == 0 || Leilao.ID_USUARIO_RESPONSAVEL == null)
                    throw new Exception("Favor inserir um usuário responsável!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
