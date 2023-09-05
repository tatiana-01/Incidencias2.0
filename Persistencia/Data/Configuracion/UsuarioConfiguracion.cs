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

        builder.HasIndex(p => new
        {
            p.UsuarioPersona,
            p.Email
        }).HasDatabaseName("IX_MiIndice")
       .IsUnique();

        builder.Property(p => p.Email)
                        .IsRequired()
                        .HasMaxLength(200);

        builder.HasOne(p => p.Persona)
        .WithOne()
        .HasForeignKey<Usuario>(p => p.IdPersona);

        builder
   .HasMany(p => p.Roles)
           .WithMany(p => p.Usuarios)
           .UsingEntity<UsuarioRol>(
           j => j
               .HasOne(pt => pt.Rol)
                   .WithMany(t => t.UsuarioRoles)
                   .HasForeignKey(pt => pt.IdRol),
               j => j
                   .HasOne(pt => pt.Usuario)
                   .WithMany(p => p.UsuarioRoles)
                   .HasForeignKey(pt => pt.IdUsuario),
               j =>
               {
                   j.HasKey(t => new
                   {
                       t.IdUsuario,
                       t.IdRol
                   });
               });
    }
}