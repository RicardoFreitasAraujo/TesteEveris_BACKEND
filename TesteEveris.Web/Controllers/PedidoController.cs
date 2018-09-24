using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteEveris.Application;
using TesteEveris.Domain;

namespace TesteEveris.Web.Controllers
{
   
    [RoutePrefix("api")]
    public class PedidoController : BaseApiController
    {

        private PedidoApp _app;

        public PedidoController()
        {
            this._app = new PedidoApp();
        }

        [HttpGet]
        [Route("pedidos")]
        public HttpResponseMessage ListarTodos()
        {
            List<Pedido> pedidos = null;
            try
            {
                pedidos = _app.RetornarTodos();
            }
            catch (Exception ex)
            {
                return this.ResponderErroInterno(ex);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, pedidos);
        }

        [HttpGet]
        [Route("pedidos/{id}")]
        public HttpResponseMessage ListarUnico(int id)
        {
            Pedido pedido = null;
            try
            {
                pedido = _app.RetornarPedidoPorId(id);
            }
            catch (Exception ex)
            {
                return this.ResponderErroInterno(ex);
            }

            if (pedido == null)
                return this.Request.CreateResponse(HttpStatusCode.NotFound, "Pedido não localizado");
            else
                return this.Request.CreateResponse(HttpStatusCode.OK, pedido);
        }

        [HttpPost]
        [Route("pedidos")]
        public HttpResponseMessage Adicionar(Pedido pedido)
        {
            try
            {
                pedido = _app.Adicionar(pedido);
            }
            catch (Exception ex)
            {
                return this.ResponderErroInterno(ex);
            }

            return this.Request.CreateResponse(HttpStatusCode.Created, pedido);
        }

        [HttpPut]
        [Route("pedidos")]
        public HttpResponseMessage Alterar(Pedido pedido)
        {
            try
            {
                _app.Alterar(pedido);
            }
            catch (Exception ex)
            {
                return this.ResponderErroInterno(ex);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, "Pedido alterado com sucesso");
        }

        [HttpDelete]
        [Route("pedidos/{id}")]
        public HttpResponseMessage Excluir(int id)
        {
            
            try
            {
                Pedido pedido = _app.RetornarPedidoPorId(id);
                if (pedido != null)
                {
                    _app.Excluir(id);
                }
                else
                {
                    return this.Request.CreateResponse(HttpStatusCode.NotFound, "Pedido não localizado para excluir");
                }
                
            }
            catch (Exception ex)
            {
                return this.ResponderErroInterno(ex);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, "Pedido excluído com sucesso.");
        }

    }
}
