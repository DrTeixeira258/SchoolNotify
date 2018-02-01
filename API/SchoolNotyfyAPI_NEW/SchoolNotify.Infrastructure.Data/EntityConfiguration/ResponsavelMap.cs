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
    public class ResponsavelMap : EntityTypeConfiguration<Responsavel>
    {
        public ResponsavelMap()
        {
            ToTable("Responsavel");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(x => x.Telefone)
                .IsRequired();

            Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
