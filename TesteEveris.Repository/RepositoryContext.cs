using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TesteEveris.Domain;
using TesteEveris.Repository.Configurations;
using TesteEveris.Repository.Initializer;

namespace TesteEveris.Repository
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext() : base("RepositoryContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;

            //Inicializar Banco de Dados 
            Database.SetInitializer<RepositoryContext>(new BancoDadosInicializador());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //Conveções Genéricas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Conveções Próprias
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<int>().Where(p => p.Name == "Id").Configure(p => p.IsKey());

            //Configurações
            modelBuilder.Configurations.Add(new PedidoConfiguration());

        }

        #region DbSet's

        public DbSet<Pedido> Pedidos { get; set; }
        
        #endregion
    }
}
