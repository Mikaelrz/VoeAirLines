using VoeAirLinesSenai.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VoeAirLinesSenai.EntitiesConfigurations;

public class ManutencaoConfiguration : IEntityTypeConfiguration<Manutencao>
{

    //Tabela em C#
    public void Configure(EntityTypeBuilder<Manutencao> Builder)
    {
        Builder.ToTable("Manutencoes");

        Builder.HasKey(m => m.Id);

        Builder.Property(m => m.DataHora)
               .IsRequired();

        Builder.Property(m => m.Tipo)
               .IsRequired();

        Builder.Property(m => m.Observacoes)
                .HasMaxLength(100);
        Builder.Property(m => m.AeronaveId);

    }
}
