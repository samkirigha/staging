
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ticketsservice.Models;

namespace ticketsservice.EF.EntityConfigs;

public class TicketConfig : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets");
        builder.Property(b => b.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsRowVersion();
        builder.HasOne<Category>(c => c.Category)
                .WithMany(c => c.Tickets)
                .HasForeignKey(p => p.CategoryID);
    }
}