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
    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        public AlunoMap()
        {
            ToTable("Aluno");
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Responsavel)
               .WithMany(x => x.Alunos)
               .HasForeignKey(x => x.IdResponsavel);

            HasRequired(x => x.SalaProfessorRelacional)
               .WithMany(x => x.Alunos)
               .HasForeignKey(x => x.IdSalaProfessorRelacional);
        }
    }
}
