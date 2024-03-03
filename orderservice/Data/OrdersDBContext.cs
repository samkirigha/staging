using Microsoft.EntityFrameworkCore;
using orderservice.Models;
using ticketsservice.EF.EntityConfigs;

public class OrdersDBContext : DbContext
{
    private IConfiguration _configuration;

    public OrdersDBContext(DbContextOptions options, IConfiguration configuration) : base(options) {
        _configuration = configuration;
     }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new OrderConfig());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), builder => 
        {
          builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        });
        base.OnConfiguring(optionsBuilder);
    }
}
