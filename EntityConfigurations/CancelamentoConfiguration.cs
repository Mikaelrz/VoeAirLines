using VoeAirLinesSenai.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VoeAirLinesSenai.EntitiesConfigurations;

public class CancelamentoConfiguration : IEntityTypeConfiguration<Cancelamento>
{

    public void Configure(EntityTypeBuilder<Cancelamento> Builder)
    {
        Builder.ToTable("Cancelamento");

        Builder.HasKey(c => c.Id);

        Builder.Property(c => c.Motivo)
               .IsRequired()
               .HasMaxLength(100);

        Builder.Property(c => c.DataHoraNotificacao)
               .IsRequired();
        Builder.Property(c => c.VooId).IsRequired();
    }

}