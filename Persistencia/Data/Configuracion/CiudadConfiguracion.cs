using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion;
    public class CiudadConfiguracion : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.ToTable("Ciudades");

            builder.HasOne(p => p.Departamento)
            .WithMany(p => p.Ciudades)
            .HasForeignKey(p => p.IdDepartamento);
        }
    }