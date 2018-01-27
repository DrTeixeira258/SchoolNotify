using SchoolNotify.Domain.Entities;
using SchoolNotify.Infrastructure.Data.EntityConfiguration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SchoolNotify.Infrastructure.Data.Context
{
    public class SchoolNotifyContext : DbContext
    {
        public SchoolNotifyContext()
            : base("SchoolNotifyConnection")
        {
            Database.SetInitializer<SchoolNotifyContext>(null);
        }


        //public DbSet<Celula> Celula { get; set; }
        //public DbSet<CelulaUnidadeRelacional> CelulaUnidadeRelacional { get; set; }

        public DbSet<Sala> Sala { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            #endregion

            #region ModelConfiguration
            //modelBuilder.Configurations.Add(new CelulaMap());
            //modelBuilder.Configurations.Add(new CelulaUnidadeRelacionalMap());

            modelBuilder.Configurations.Add(new SalaMap());
            #endregion

            base.OnModelCreating(modelBuilder);
        }


    }
}
