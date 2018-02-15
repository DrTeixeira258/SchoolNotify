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

        public DbSet<Responsavel> Responsavel { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<SalaProfessorRelacional> SalaProfessorRelacional { get; set; }


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

            modelBuilder.Configurations.Add(new ResponsavelMap());
            modelBuilder.Configurations.Add(new SalaMap());
            modelBuilder.Configurations.Add(new ProfessorMap());
            modelBuilder.Configurations.Add(new AlunoMap());
            modelBuilder.Configurations.Add(new SalaProfessorRelacionalMap());
            #endregion

            base.OnModelCreating(modelBuilder);
        }


    }
}
