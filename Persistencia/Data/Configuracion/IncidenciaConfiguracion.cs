using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion;
    public class IncidenciaConfiguracion : IEntityTypeConfiguration<Incidencia>
    {
        public void Configure(EntityTypeBuilder<Incidencia> builder)
        {
            builder.ToTable("Incidencias");

            builder.Property(p => p.Descripcion)
            .IsRequired()
            .HasMaxLength(150);

            builder.Property(p => p.FechaReporte)
            .IsRequired();

            builder.HasOne(p => p.TipoIncidencia)
            .WithMany(p => p.Incidencias)
            .HasForeignKey(p => p.IdTipoIncidencia);

            builder.HasOne(p => p.Categoria)
            .WithMany(p => p.Incidencias)
            .HasForeignKey(p => p.IdCategoria);

            builder.HasOne(p => p.Persona)
            .WithMany(p => p.Incidencias)
            .HasForeignKey(p => p.IdPersona);
            
        }
    }