using SchoolNotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNotify.Infrastructure.Data.EntityConfiguration
{
    public class SalaProfessorRelacionalMap : EntityTypeConfiguration<SalaProfessorRelacional>
    {
        public SalaProfessorRelacionalMap()
        {
            ToTable("SalaProfessorRelacional");
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Professor)
               .WithMany(x => x.SalaProfessorRelacional)
               .HasForeignKey(x => x.IdProfessor);

            HasRequired(x => x.Sala)
               .WithMany(x => x.SalaProfessorRelacional)
               .HasForeignKey(x => x.IdSala);
        }
    }
}
