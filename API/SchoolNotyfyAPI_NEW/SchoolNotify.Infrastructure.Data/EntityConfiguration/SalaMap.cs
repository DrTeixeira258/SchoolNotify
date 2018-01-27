using SchoolNotify.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SchoolNotify.Infrastructure.Data.EntityConfiguration
{
    public class SalaMap : EntityTypeConfiguration<Sala>
    {
        public SalaMap()
        {
            ToTable("Sala");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.Serie)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
