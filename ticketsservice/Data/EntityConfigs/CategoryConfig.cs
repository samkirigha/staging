using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ticketsservice.Models;

namespace ticketsservice.EF.EntityConfigs;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.Property(b => b.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsRowVersion();
        builder.HasMany(t => t.Tickets)
                .WithOne(c => c.Category)
                .HasForeignKey(p => p.TicketID);
    }
}