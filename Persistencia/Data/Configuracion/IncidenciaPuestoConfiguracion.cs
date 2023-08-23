using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion;
    public class IncidenciaPuestoConfiguracion : IEntityTypeConfiguration<IncidenciaPuesto>
    {
        public void Configure(EntityTypeBuilder<IncidenciaPuesto> builder)
        {
            builder.ToTable("IncidenciaPuestos");

            builder.HasKey(p => new { p.IdIncidencia, p.IdPuesto, p.IdComponente }); 
            
            builder.Property(p=>p.Descripcion)
            .HasMaxLength(100);

            builder.HasOne(p => p.EstadoIncidencia)
            .WithMany(p => p.IncidenciaPuestos)
            .HasForeignKey(p => p.IdEstadoIncidencia);

            builder.HasOne(p => p.Incidencia)
            .WithMany(p => p.IncidenciaPuestos)
            .HasForeignKey(p => p.IdIncidencia);

            builder.HasOne(p => p.Puesto)
            .WithMany(p => p.IncidenciaPuestos)
            .HasForeignKey(p => p.IdPuesto);

            builder.HasOne(p => p.Componente)
            .WithMany(p => p.IncidenciaPuestos)
            .HasForeignKey(p => p.IdComponente);

            
        }
    }