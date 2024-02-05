using Microsoft.EntityFrameworkCore;
using ticketsservice.EF.EntityConfigs;
using ticketsservice.Models;

namespace ticketsservice.EF;

public class TicketsDBContext : DbContext
{
    private IConfiguration _configuration;

    public TicketsDBContext(DbContextOptions options, IConfiguration configuration) : base(options) {
        _configuration = configuration;
     }

    public virtual DbSet<Ticket> Tickets { get; set; }
    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CategoryConfig());
        modelBuilder.ApplyConfiguration(new TicketConfig());
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
