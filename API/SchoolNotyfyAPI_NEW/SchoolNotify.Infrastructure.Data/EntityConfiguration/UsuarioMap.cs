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
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Senha)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Telefone)
                .IsOptional();

            Property(x => x.Responsavel)
                .IsOptional();

            Property(x => x.Professor)
                .IsOptional();
        }
    }
}
