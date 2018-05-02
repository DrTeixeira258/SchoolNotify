using SchoolNotify.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SchoolNotify.Infrastructure.Data.EntityConfiguration
{
    public class NotificacaoMap : EntityTypeConfiguration<Notificacao>
    {
        public NotificacaoMap()
        {
            ToTable("Notificacao");
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(30);

            Property(x => x.Assunto)
                .IsRequired()
                .HasMaxLength(30);

            Property(x => x.Mensagem)
                .IsRequired()
                .HasMaxLength(500);

            Property(x => x.Data)
                .IsRequired();

            Property(x => x.IdProfessor)
                .IsRequired();

            Property(x => x.IdSala)
                .IsRequired();

            Property(x => x.IdAluno)
                .IsRequired();

            HasRequired(x => x.Professor)
               .WithMany(x => x.Notificacoes)
               .HasForeignKey(x => x.IdProfessor);

            HasRequired(x => x.Sala)
               .WithMany(x => x.Notificacoes)
               .HasForeignKey(x => x.IdSala);

            HasRequired(x => x.Aluno)
               .WithMany(x => x.Notificacoes)
               .HasForeignKey(x => x.IdAluno);
        }
    }
}