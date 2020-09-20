using Domain;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace api_leilao.Controllers
{
    public class LeilaoController : ApiController
    {
        LeilaoService leilaoService = new LeilaoService();

        [Route("api/leilao/Insert")]
        [HttpPost]
        public async Task<HttpResponseMessage> Insert(TB_LEILAO Leilao)
        {
            try
            {
                leilaoService.InsertLeilao(Leilao);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Leilão cadastrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }

        [Route("api/leilao/GetAll")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                List<TB_LEILAO> lstLeilao = await leilaoService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, new { lstLeilao });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }
        
        [Route("api/leilao/GetById")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetById(int ID_LEILAO)
        {
            try
            {
                TB_LEILAO Leilao = await leilaoService.GetById(ID_LEILAO);
                return Request.CreateResponse(HttpStatusCode.OK, new { Leilao });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }

        [Route("api/leilao/Update")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(TB_LEILAO Leilao)
        {
            try
            {
                leilaoService.Update(Leilao);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Leilão atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }

        [Route("api/leilao/Delete")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int ID_LEILAO)
        {
            try
            {
                leilaoService.Delete(ID_LEILAO);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Leilão excluído com sucesso!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }

    }
}
