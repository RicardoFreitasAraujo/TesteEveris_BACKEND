using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TesteEveris.Web.Controllers
{
    public class BaseApiController : ApiController
    {
        protected HttpResponseMessage ResponderErroInterno(Exception ex)
        {
            return this.Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                mensagem = "Ocorreu um erro na sua solicitação",
                detalhes = ex.Message
            });
        }
    }
}
