using VoeAirLinesSenai.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VoeAirLinesSenai.EntitiesConfigurations;

public class AeronaveConfiguration : IEntityTypeConfiguration<Aeronave>
{

    public void Configure(EntityTypeBuilder<Aeronave> Builder)
    {
        Builder.ToTable("Aeronaves");

        Builder.HasKey(a => a.Id);

        Builder.Property(a => a.Fabricante)
               .IsRequired()
               .HasMaxLength(50);

        Builder.Property(a => a.Modelo)
               .IsRequired()
               .HasMaxLength(50);

        Builder.Property(a => a.Codigo)
               .IsRequired()
               .HasMaxLength(10);

        Builder.HasMany(a => a.Manutencoes)
                .WithOne(m => m.Aeronave)
                .HasForeignKey(m => m.AeronaveId);


    }
}