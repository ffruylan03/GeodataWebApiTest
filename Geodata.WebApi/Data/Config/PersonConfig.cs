using System;
using Geodata.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geodata.WebApi.Data.Config
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.Property(p => p.Name)
                .HasMaxLength(225)
                .HasComputedColumnSql(@"LastName + ', ' + FirstName + (CASE WHEN Length(NameExtension) <= 0 THEN ' ' + NameExtension ELSE '' END)");

            builder.Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.MiddleName)
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
