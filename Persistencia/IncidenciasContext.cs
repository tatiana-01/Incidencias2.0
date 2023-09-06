using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dominio.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia.Seeding;

namespace Persistencia;
public class IncidenciasContext : DbContext
{
    public IncidenciasContext(DbContextOptions<IncidenciasContext> options) : base(options)
    {
    }

    public DbSet<Area> Areas {get;set;}
    public DbSet<AreaContacto> AreaContactos { get; set; }
    public DbSet<ARL> ARLs { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Ciudad> Ciudades { get; set; }
    public DbSet<Contacto> Contactos { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Direccion> Direcciones { get; set; }
    public DbSet<EPS> EPSs { get; set; }
    public DbSet<EstadoIncidencia> EstadoIncidencias { get; set; }
    public DbSet<EstadoVerificacion> EstadoVerificaciones { get; set; }
    public DbSet<Genero> Generos { get; set; }  
    public DbSet<Componente> Componentes { get; set; }
    public DbSet<Incidencia> Incidencias { get; set; }
    public DbSet<IncidenciaPuesto> IncidenciaPuestos { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<PersonaContacto> PersonaContactos { get; set; }
    public DbSet<PersonaDireccion> PersonaDirecciones { get; set; }
    public DbSet<Puesto> Puestos { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Salon> Salones { get; set; }
    public DbSet<TipoComponente> TipoComponentes { get; set; }
    public DbSet<TipoContacto> TipoContactos { get; set; }
    public DbSet<TipoIncidencia> TipoIncidencias { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioRol> UsuarioRoles { get; set; }
    public DbSet<Verificacion> Verificaciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        SeedingInicial.Seed(modelBuilder);
    }

}
