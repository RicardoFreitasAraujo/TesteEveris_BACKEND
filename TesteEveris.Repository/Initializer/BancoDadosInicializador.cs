using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEveris.Domain;

namespace TesteEveris.Repository.Initializer
{
    /// <summary>
    /// Inicializador de Banco de Dados
    /// </summary>
    public class BancoDadosInicializador : CreateDatabaseIfNotExists<RepositoryContext>
    {
        protected override void Seed(RepositoryContext context)
        {

            context.Pedidos.Add(
                new Pedido
                {
                    Id = 0,
                    NomeCliente = "Ricardo de Freitas Araújo",
                    Cpf = "56581608041",
                    Email = "ricardo.freitas.araujo@gmail.com",
                    DataPedido = System.DateTime.Now.AddDays(2),
                    ValorTotal = 456.90m
                });
            context.Pedidos.Add(
                new Pedido
                {
                    Id = 0,
                    NomeCliente = "Denise Oliveira Santos",
                    Cpf = "05670568052",
                    Email = "denise.santos@terra.com",
                    DataPedido = System.DateTime.Now.AddDays(6),
                    ValorTotal = 754.56m
                });
            context.Pedidos.Add(
               new Pedido
               {
                   Id = 0,
                   NomeCliente = "Rebeca Freitas Bamondes",
                   Cpf = "58624461090",
                   Email = "rebeca.bamondes@gmail.com",
                   DataPedido = System.DateTime.Now.AddDays(4),
                   ValorTotal = 56.89m
               });
            context.Pedidos.Add(
            new Pedido
            {
                Id = 0,
                NomeCliente = "Antonia Cleomar Freitas Araujo",
                Cpf = "46817098084",
                Email = "cleomar@gmail.com",
                DataPedido = System.DateTime.Now.AddDays(1),
                ValorTotal = 2586.02m
            });
            context.Pedidos.Add(
            new Pedido
            {
                Id = 0,
                NomeCliente = "Luna Freitas Santos",
                Cpf = "13653932084",
                Email = "luna.santos@gmail.com",
                DataPedido = System.DateTime.Now.AddDays(1),
                ValorTotal = 12.99m
            });

            context.SaveChanges();

            base.Seed(context);

        }
    }
}
