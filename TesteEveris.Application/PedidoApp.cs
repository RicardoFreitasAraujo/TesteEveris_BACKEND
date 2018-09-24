using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEveris.Domain;
using TesteEveris.Repository.Repositores;
using TesteEveris.Utils;

namespace TesteEveris.Application
{
    /// <summary>
    /// Classe de aplicação de Pedidos
    /// </summary>
    public class PedidoApp
    {
        private PedidoRepository _repo;

        public PedidoApp()
        {
            this._repo = new PedidoRepository();
        }

        #region métodos CRUD

        public List<Pedido> RetornarTodos()
        {
            return _repo.RetornarTodos();
        }

        public Pedido RetornarPedidoPorId(int Id)
        {
            return _repo.RetornarPor(p => p.Id == Id).FirstOrDefault();
        }

        public Pedido Adicionar(Pedido pedido)
        {
            this.ValidarPedido(pedido);
            pedido = _repo.Adicionar(pedido);
            _repo.Salvar();
            return pedido;
        }

        public void Alterar(Pedido pedido)
        {
            this.ValidarPedido(pedido);
            _repo.Alterar(pedido);
            _repo.Salvar();
        }

        public void Excluir(int Id)
        {
            Pedido pedido = this.RetornarPedidoPorId(Id);
            if (pedido != null)
            {
                this.Excluir(pedido);
            } else
            {
                throw new Exception("Número de Pedido não localizado");
            }
        }

        public void Excluir(Pedido pedido)
        {
            _repo.Excluir(pedido);
            _repo.Salvar();
        }
        #endregion

        #region Métodos Privados
        private void ValidarPedido(Pedido pedido)
        {
            if (pedido == null) throw new Exception("Pedido não informado");
            if (Validacao.Vazio(pedido.NomeCliente)) throw new Exception("Nome do cliente não definido");
            if (Validacao.TamanhoMaiorQue(pedido.NomeCliente,200)) throw new Exception("Nome do cliente muito grande");
            if (Validacao.EmailInvalido(pedido.Email)) throw new Exception("Email do cliente inválido");
            if (!Validacao.CpfValido(pedido.Cpf)) throw new Exception("CPF do cliente inválido");
            if (Validacao.ValorVazio(pedido.ValorTotal)) throw new Exception("Valor do pedido está zerado");
            if (Validacao.DataVazio(pedido.DataPedido)) throw new Exception("Data do pedido está vazia");
        }
        #endregion


    }
}
