using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion;
    public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.Property(p => p.UsuarioPersona)
            .IsRequired()
            .HasMaxLength(150);

            builder.Property(p => p.Contraseña)
            .IsRequired()
            .HasMaxLength(150);

            builder.HasOne(p => p.Persona)
            .WithOne()
            .HasForeignKey<Usuario>(p => p.IdPersona);
        }
    }