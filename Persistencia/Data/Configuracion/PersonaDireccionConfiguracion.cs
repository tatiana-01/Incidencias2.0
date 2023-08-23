using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion;
    public class PersonaDireccionConfiguracion : IEntityTypeConfiguration<PersonaDireccion>
    {
        public void Configure(EntityTypeBuilder<PersonaDireccion> builder)
        {
            builder.ToTable("PersonaDirecciones");

            builder.HasOne(p => p.Persona)
            .WithMany(p => p.PersonaDirecciones)
            .HasForeignKey(p => p.IdPersona);

            builder.HasOne(p => p.Direccion)
            .WithMany(p => p.PersonaDirecciones)
            .HasForeignKey(p => p.IdDireccion);

            builder.HasKey(p => new { p.IdPersona, p.IdDireccion });
        }
    }