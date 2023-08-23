using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion;
    public class PersonaConfiguracion : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Personas");

            builder.Property(p => p.Id)
            .IsRequired()
            .HasMaxLength(100);
            
            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(150);

            builder.Property(p => p.FechaNacimiento)
            .IsRequired();

            builder.HasOne(p => p.Genero)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdGenero);

            builder.HasOne(p => p.EPS)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdEPS);

            builder.HasOne(p => p.ARL)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdARL);

            builder.HasOne(p => p.Rol)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdRol);

        }
    }