using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEveris.Domain;

namespace TesteEveris.Repository.Configurations
{
    public class PedidoConfiguration: EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            ToTable("Pedido");
            HasKey(p => p.Id);

            Property(p => p.NomeCliente).HasMaxLength(200).IsRequired();
            Property(p => p.Email).HasMaxLength(200).IsRequired();
            Property(p => p.Cpf).HasMaxLength(20).IsRequired();
            Property(p => p.ValorTotal).IsRequired();
            Property(p => p.DataPedido).IsRequired();
        }
    }
}
