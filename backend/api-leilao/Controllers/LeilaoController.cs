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

        [Route("api/leilao")]
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

        [Route("api/leilao")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "ok" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }
        
        [Route("api/leilao/{id}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetById(int ID_LEILAO)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "ok" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }

        [Route("api/leilao")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(TB_LEILAO Leilao)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "ok" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }

        [Route("api/leilao")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int ID_LEILAO)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "ok" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }

    }
}
