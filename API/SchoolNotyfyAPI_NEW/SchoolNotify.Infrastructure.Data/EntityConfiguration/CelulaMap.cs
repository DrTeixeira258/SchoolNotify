using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mappings
{
    public class CelulaMap : EntityTypeConfiguration<Celula>
    {
        public CelulaMap()
        {
            //ToTable("Celula");

            //HasKey(x => x.Id);

            //Property(x => x.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Property(x => x.Numero)
            //    .IsRequired()
            //    .HasMaxLength(3);

            //Property(x => x.Cancelada)
            //    .IsRequired();

        }
    }
}

