using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OLC.Cases.Api.Models;

namespace OLC.Cases.Api.Data.Mappings
{
    public class CaseMapping : IEntityTypeConfiguration<Case>
    {
        public void Configure(EntityTypeBuilder<Case> builder)
        {
            builder.HasKey(c => c.CaseNumber);

            builder.Property(c => c.CaseNumber)
                .IsRequired()
                .HasColumnType("varchar(24)");


            builder.Property(c => c.CourtName)
                .IsRequired();

            builder.Property(c => c.NameOfTheResponsible)
                .IsRequired();

            builder.Property(c => c.RegistrationDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.ToTable("Cases");
        }
    }
}
