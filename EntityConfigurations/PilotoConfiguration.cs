using VoeAirLinesSenai.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VoeAirLinesSenai.EntitiesConfigurations;

public class PilotoConfiguration : IEntityTypeConfiguration<Piloto>
{
    public void Configure(EntityTypeBuilder<Piloto> Builder)
    {
        //Nome da tabela
        Builder.ToTable("Piloto");
        
        Builder.HasKey(p => p.Id);
        //Atributo Nome
        Builder.Property(p => p.Nome)
               .IsRequired()
               .HasMaxLength(80);
        //Atributo Matrícula
        Builder.Property(p => p.Matricula)
               .IsRequired()
               .HasMaxLength(10);
        //Definindo Matrícula como chave única
        Builder.HasIndex(p => p.Matricula)
               .IsUnique();
       Builder.HasMany(p => p.Voos)
       .WithOne(p => p.Piloto)
       .HasForeignKey(p => p.PilotoId);


    }

}

