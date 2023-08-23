using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion;
    public class ComponenteConfiguracion : IEntityTypeConfiguration<Componente>
    {
        public void Configure(EntityTypeBuilder<Componente> builder)
        {
            builder.ToTable("Componentes");

            builder.Property(p => p.Marca)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.Descripcion)
            .HasMaxLength(150);

            builder.HasOne(p => p.TipoComponente)
            .WithMany(p => p.Componentes)
            .HasForeignKey(p => p.IdTipoComponente);

            builder.HasOne(p => p.Puesto)
            .WithMany(p => p.Componentes)
            .HasForeignKey(p => p.IdPuesto);

            builder.HasOne(p => p.Categoria)
            .WithMany(p => p.Componentes)
            .HasForeignKey(p => p.IdCategoria);
        }
    }