using Microsoft.EntityFrameworkCore;

public class EcoflowPostgreDbContext : DbContext
{
    public DbSet<SolarInputOutputTracker> solarinputoutputtracker { get; set; }
    public DbSet<BatterySocVoltageTracker> batterysocvoltagetracker { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Update the connection string with your PostgreSQL database details
        optionsBuilder.UseNpgsql("Host=127.0.0.1;port=5433;Username=ecoflowuser;Password=Ecoflow1;Database=EcoflowData");
    }
}