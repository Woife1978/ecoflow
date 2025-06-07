using Microsoft.EntityFrameworkCore;

public class EcoflowPostgreDbContext : DbContext
{
    public DbSet<SolarInputOutputTracker> solarinputoutputtracker { get; set; }
    public DbSet<BatterySocVoltageTracker> batterysocvoltagetracker { get; set; }
    public DbSet<EcoflowDevice> ecoflowdevice { get; set; }

    private readonly string _connectionString;

    public EcoflowPostgreDbContext(DbContextOptions<EcoflowPostgreDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Update the connection string with your PostgreSQL database details
        if (!optionsBuilder.IsConfigured)
        {
            // Optionally configure here if not already configured
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}