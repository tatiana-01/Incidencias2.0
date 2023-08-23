using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion;
    public class ContactoConfiguracion : IEntityTypeConfiguration<Contacto>
    {
        public void Configure(EntityTypeBuilder<Contacto> builder)
        {
            builder.ToTable("Contactos");

            builder.Property(p => p.ContactoPersona)
            .IsRequired()
            .HasMaxLength(150);

            builder.HasOne(p => p.TipoContacto)
            .WithMany(p => p.Contactos)
            .HasForeignKey(p => p.IdTipoContacto);

            builder.HasOne(p => p.AreaContacto)
            .WithMany(p => p.Contactos)
            .HasForeignKey(p => p.IdAreaContacto);

        }
    }