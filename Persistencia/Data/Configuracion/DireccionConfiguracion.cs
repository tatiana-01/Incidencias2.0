using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion;
    public class DireccionConfiguracion : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.ToTable("Direcciones");

            builder.Property(p => p.TipoVia)
            .IsRequired()
            .HasMaxLength(20);

            builder.Property(p => p.Letra)
            .IsRequired();

            builder.Property(p => p.SufijoCardinal)
            .IsRequired()
            .HasMaxLength(30);

            builder.Property(p => p.NroViaSecundaria)
            .IsRequired()
            .HasMaxLength(10);

            builder.Property(p => p.LetraViaSecundaria)
            .IsRequired();

            builder.HasOne(p => p.Ciudad)
            .WithMany(p => p.Direcciones)
            .HasForeignKey(p => p.IdCiudad);            

        }
    }