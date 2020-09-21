using AutoMapper;
using Domain;
using Domain.Classes;
using Repository.Repositories;
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
    public class UserController : ApiController
    {

        UserService userService = new UserService();
        TokenService tokenService = new TokenService();

        [Route("api/user")]
        [HttpPost]
        public HttpResponseMessage New(TB_USUARIO User)
        {
            try
            {
                userService.InsertUser(User);
                return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, message = "Usuário cadastrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { valid = false, message = ex.Message });
            }
        }

        [Route("api/user")]
        [HttpGet]
        public HttpResponseMessage Login(string DS_USUARIO, string DS_SENHA)
        {
            try
            {
                User user = new User();
                user = userService.LoginUser(DS_USUARIO, DS_SENHA);

                if (User != null)
                {
                    user.TOKEN = tokenService.GenerateToken(user);
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, UserData = user });
                }
                else
                    throw new Exception("Usuário ou senha inválidos!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { valid = false, message = ex.Message });
            }
        }

        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            List<User> lstUser = new List<User>();
            try
            {
                lstUser = userService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, lstUser });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { valid = false, message = ex.Message });
            }
        }
    }
}
