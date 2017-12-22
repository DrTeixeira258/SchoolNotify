using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mappings
{
    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        public AlunoMap()
        {
            HasKey(a => a.Id);

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(300);

            Property(a => a.Matricula)
                .IsRequired();

            Property(a => a.Ativo)
                .IsRequired();
        }
    }
}
