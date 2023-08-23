using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion;
    public class VerificacionConfiguracion : IEntityTypeConfiguration<Verificacion>
    {
        public void Configure(EntityTypeBuilder<Verificacion> builder)
        {
            builder.ToTable("Verificaciones");

            builder.HasOne(p => p.EstadoVerificacion)
            .WithMany(p => p.Verificaciones)
            .HasForeignKey(p => p.IdEstado);

            builder.HasOne(p => p.Persona)
            .WithMany(p => p.Verificaciones)
            .HasForeignKey(p => p.IdTrainer);

            builder.HasOne(p => p.Incidencia)
            .WithOne()
            .HasForeignKey<Verificacion>(p => p.IdIncidencia);
        }
    }