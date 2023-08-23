using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion;
    public class PersonaContactoConfiguracion : IEntityTypeConfiguration<PersonaContacto>
    {
        public void Configure(EntityTypeBuilder<PersonaContacto> builder)
        {
            builder.ToTable("PersonaContactos");

            builder.HasOne(p => p.Persona)
            .WithMany(p => p.PersonasContactos)
            .HasForeignKey(p => p.IdPersona);

            builder.HasOne(p => p.Contacto)
            .WithMany(p => p.PersonasContactos)
            .HasForeignKey(p => p.IdContacto);

            builder.HasKey(p => new { p.IdPersona, p.IdContacto });
        }
    }