using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion;
    public class SalonConfiguracion : IEntityTypeConfiguration<Salon>
    {
        public void Configure(EntityTypeBuilder<Salon> builder)
        {
            builder.ToTable("Salones");

            builder.HasOne(p => p.Area)
            .WithMany(p => p.Salones)
            .HasForeignKey(p => p.IdArea);
        }
    }