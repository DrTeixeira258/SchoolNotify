using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class CelulaUnidadeRelacionalMap : EntityTypeConfiguration<CelulaUnidadeRelacional>
    {
        public CelulaUnidadeRelacionalMap()
        {
            //ToTable("CelulaUnidadeRelacional");
            //HasKey(x => x.Id);

            //Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //HasRequired(x => x.Celula)
            //   .WithMany(x => x.CelulaUnidadeRelacional)
            //   .HasForeignKey(x => x.CelulaId);

            //HasRequired(x => x.Unidade)
            //   .WithMany(x => x.CelulaUnidadeRelacional)
            //   .HasForeignKey(x => x.UnidadeId);
        }
        
    }
}
