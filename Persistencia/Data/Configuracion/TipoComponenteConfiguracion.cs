using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion;
    public class TipoComponenteConfiguracion : IEntityTypeConfiguration<TipoComponente>
    {
        public void Configure(EntityTypeBuilder<TipoComponente> builder)
        {
            builder.ToTable("TipoComponentes");

            builder.HasOne(p => p.Categoria)
            .WithMany(p => p.TipoComponentes)
            .HasForeignKey(p => p.IdCategoria);
        }
    }