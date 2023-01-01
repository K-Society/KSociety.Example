using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Example.Infra.DataAccess.EntityTypeConfiguration
{
    public class Book : IEntityTypeConfiguration<Domain.Entity.Book>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Book> connectionConfiguration)
        {
            ((EntityTypeBuilder)connectionConfiguration).ToTable("Book");

            connectionConfiguration.HasKey(k => k.Id);
            connectionConfiguration.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();

            connectionConfiguration.HasIndex(i => new { i.Title, i.AuthorName }).IsUnique();
            connectionConfiguration.Property(p => p.Title).HasMaxLength(250).IsRequired();

            connectionConfiguration.Property(p => p.AuthorName).HasMaxLength(250).IsRequired();

        }
    }
}
