using Data.Interfaces.Context;
using Data.Mappings;
using Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;

namespace Data.Context
{
    public class SchoolNotifyContext : DbContext, IDbContext
    {
        public SchoolNotifyContext()
            : base("SchoolNotifyConnection")
        {
            Database.SetInitializer<SchoolNotifyContext>(null);
            var ensureDLLIsCopied = SqlProviderServices.Instance;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Convenções
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //Mapeamentos
            modelBuilder.Configurations.Add(new AlunoMap());

            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();   
        }
    }
}
