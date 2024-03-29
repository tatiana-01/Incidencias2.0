using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Seeding;
public class SeedingInicial
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var genero = new Genero()
        {
            Id = 1,
            Nombre = "Otros"
        };
        var Administrador = new Persona()
        {
            Id = "123456",
            Nombre = "Admin",
            FechaNacimiento = DateOnly.FromDateTime(DateTime.Now),
            IdGenero = 1,
            IdEPS = null,
            IdARL = null
        };
        var UserAdministrador = new Usuario()
        {
            Id = 1,
            Email = "admin@corre.com",
            UsuarioPersona = "Admin",
            IdPersona = Administrador.Id
        };
        var _passwordHasher = new PasswordHasher<Usuario>();
        UserAdministrador.Contraseña = _passwordHasher.HashPassword(UserAdministrador, "12345");
        var RolPersona = new Rol()
        {
            Id = 1,
            Nombre = "Persona",
            Permisos = "Basicos"
        };
        var RolAdmin = new Rol()
        {
            Id = 2,
            Nombre = "Administrador",
            Permisos = "Todos"
        };
        var AdminUsuarioRol = new UsuarioRol()
        {
            IdRol = 2,
            IdUsuario = 1
        };
        modelBuilder.Entity<Genero>().HasData(genero);
        modelBuilder.Entity<Persona>().HasData(Administrador);
        modelBuilder.Entity<Usuario>().HasData(UserAdministrador);
        modelBuilder.Entity<Rol>().HasData(RolPersona, RolAdmin);
        modelBuilder.Entity<UsuarioRol>().HasData(AdminUsuarioRol);
    }
}
