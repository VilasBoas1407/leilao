﻿using AutoMapper;
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

    public class UserController : ApiController
    {

        UserService userService = new UserService();

        [Route("api/user")]
        [HttpPost]
        public async Task<HttpResponseMessage> New(TB_USUARIO User)
        {
            try
            {                
                User = await userService.InsertUser(User);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Usuário cadastrado com sucesso!" });
            }
            catch (Exception ex)
            {
               return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }

        [Route ("api/user")]
        [HttpGet]
        public async Task<HttpResponseMessage> Login(string DS_USUARIO, string DS_SENHA)
        {
            try
            {
                TB_USUARIO User = new TB_USUARIO();
                User = await userService.LoginUser(DS_USUARIO, DS_SENHA);
                if (User != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, UserData = User });
                else
                    throw new Exception("Usuário ou senha inválidos!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }
    }
}