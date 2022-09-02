using Microsoft.EntityFrameworkCore;
using VoeAirLinesSenai.Entities;
using VoeAirLinesSenai.EntitiesConfigurations;

namespace VoeAirLinesSenai.Contexts;

public class VoeAirlinesContext:DbContext
{


 private readonly IConfiguration _configuration;

    public VoeAirlinesContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

public DbSet<Aeronave> Aeronaves =>Set<Aeronave>();
public DbSet<Manutencao> Manutencoes =>Set<Manutencao>();
public DbSet<Piloto> Pilotos =>Set<Piloto>();
public DbSet<Voo> Voos =>Set<Voo>();
public DbSet<Cancelamento> Cancelamentos=>Set<Cancelamento>();

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("VoeAirLinesSenai"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    modelBuilder.ApplyConfiguration(new AeronaveConfiguration());
    modelBuilder.ApplyConfiguration(new PilotoConfiguration());
    modelBuilder.ApplyConfiguration(new VooConfigurations());
    modelBuilder.ApplyConfiguration(new CancelamentoConfiguration());
    modelBuilder.ApplyConfiguration(new ManutencaoConfiguration());
    }
}

