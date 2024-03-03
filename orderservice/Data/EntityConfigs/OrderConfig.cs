
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using orderservice.Models;

namespace ticketsservice.EF.EntityConfigs;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.Property(b => b.RowVersion)
                .ValueGeneratedOnAddOrUpdate()
                .IsRowVersion();
        builder.Property(p => p.OrderID)
                .ValueGeneratedOnAdd();
    }
}