using SchoolNotify.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SchoolNotify.Infrastructure.Data.EntityConfiguration
{
    public class TokenMap : EntityTypeConfiguration<Token>
    {
        public TokenMap()
        {
            ToTable("Token");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.TelefoneResp)
                .IsRequired();
        }
    }
}
