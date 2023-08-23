using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion;
    public class PuestoConfiguracion : IEntityTypeConfiguration<Puesto>
    {
        public void Configure(EntityTypeBuilder<Puesto> builder)
        {
            builder.ToTable("Puestos");

            builder.Property(p=>p.Descripcion)
            .HasMaxLength(100);

            builder.HasOne(p => p.Salon)
            .WithMany(p => p.Puestos)
            .HasForeignKey(p => p.IdSalon);
        }
    }