﻿using Domain;
using Domain.Classes;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace api_leilao.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LeilaoController : ApiController
    {
        LeilaoService leilaoService = new LeilaoService();

        [Route("api/leilao")]
        [HttpPost]
        public HttpResponseMessage Insert(TB_LEILAO Leilao)
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
        public HttpResponseMessage GetAll()
        {
            try
            {
                List<Leilao> lstLeilao = leilaoService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, lstLeilao });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }
        
        [Route("api/leilao/GetById")]
        [HttpGet]
        public HttpResponseMessage GetById(int ID_LEILAO)
        {
            try
            {
                TB_LEILAO Leilao =  leilaoService.GetById(ID_LEILAO);
                return Request.CreateResponse(HttpStatusCode.OK, new { Leilao });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }

        [Route("api/leilao")]
        [HttpPut]
        public HttpResponseMessage Update(TB_LEILAO Leilao)
        {
            try
            {
                leilaoService.Update(Leilao);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Leilão atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { message = ex.Message });
            }
        }

        [Route("api/leilao")]
        [HttpDelete]
        public HttpResponseMessage Delete(int ID_LEILAO)
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
