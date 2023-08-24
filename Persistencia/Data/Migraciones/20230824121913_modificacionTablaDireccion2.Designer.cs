﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Data.Migraciones
{
    [DbContext(typeof(IncidenciasContext))]
    [Migration("20230824121913_modificacionTablaDireccion2")]
    partial class modificacionTablaDireccion2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dominio.Entidades.ARL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ARLs");
                });

            modelBuilder.Entity("Dominio.Entidades.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Areas", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.AreaContacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AreaContactos");
                });

            modelBuilder.Entity("Dominio.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Dominio.Entidades.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdDepartamento")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartamento");

                    b.ToTable("Ciudades", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Componente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdPuesto")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoComponente")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdPuesto");

                    b.HasIndex("IdTipoComponente");

                    b.ToTable("Componentes", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Contacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ContactoPersona")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("IdAreaContacto")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoContacto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAreaContacto");

                    b.HasIndex("IdTipoContacto");

                    b.ToTable("Contactos", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPais")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdPais");

                    b.ToTable("Departamentos", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdCiudad")
                        .HasColumnType("int");

                    b.Property<string>("Letra")
                        .HasColumnType("varchar(1)");

                    b.Property<string>("LetraViaSecundaria")
                        .HasColumnType("varchar(1)");

                    b.Property<string>("NroViaSecundaria")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("SufijoCardinal")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("TipoVia")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdCiudad");

                    b.ToTable("Direcciones", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.EPS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EPSs");
                });

            modelBuilder.Entity("Dominio.Entidades.EstadoIncidencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EstadoIncidencias");
                });

            modelBuilder.Entity("Dominio.Entidades.EstadoVerificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EstadoVerificaciones");
                });

            modelBuilder.Entity("Dominio.Entidades.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("Dominio.Entidades.Incidencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("FechaReporte")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("IdPersona")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdTipoIncidencia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdPersona");

                    b.HasIndex("IdTipoIncidencia");

                    b.ToTable("Incidencias", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.IncidenciaPuesto", b =>
                {
                    b.Property<int>("IdIncidencia")
                        .HasColumnType("int");

                    b.Property<int>("IdPuesto")
                        .HasColumnType("int");

                    b.Property<int>("IdComponente")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdEstadoIncidencia")
                        .HasColumnType("int");

                    b.HasKey("IdIncidencia", "IdPuesto", "IdComponente");

                    b.HasIndex("IdComponente");

                    b.HasIndex("IdEstadoIncidencia");

                    b.HasIndex("IdPuesto");

                    b.ToTable("IncidenciaPuestos", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("Dominio.Entidades.Persona", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateOnly>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<int?>("IdARL")
                        .HasColumnType("int");

                    b.Property<int?>("IdEPS")
                        .HasColumnType("int");

                    b.Property<int>("IdGenero")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("IdARL");

                    b.HasIndex("IdEPS");

                    b.HasIndex("IdGenero");

                    b.HasIndex("IdRol");

                    b.ToTable("Personas", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.PersonaContacto", b =>
                {
                    b.Property<string>("IdPersona")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdContacto")
                        .HasColumnType("int");

                    b.HasKey("IdPersona", "IdContacto");

                    b.HasIndex("IdContacto");

                    b.ToTable("PersonaContactos", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.PersonaDireccion", b =>
                {
                    b.Property<string>("IdPersona")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdDireccion")
                        .HasColumnType("int");

                    b.HasKey("IdPersona", "IdDireccion");

                    b.HasIndex("IdDireccion");

                    b.ToTable("PersonaDirecciones", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Puesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdSalon")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdSalon");

                    b.ToTable("Puestos", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Permisos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Salon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.Property<int>("IdArea")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("NroPuestos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdArea");

                    b.ToTable("Salones", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.TipoComponente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoComponentes");
                });

            modelBuilder.Entity("Dominio.Entidades.TipoContacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoContactos");
                });

            modelBuilder.Entity("Dominio.Entidades.TipoIncidencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoIncidencias");
                });

            modelBuilder.Entity("Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("IdPersona")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UsuarioPersona")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("IdPersona")
                        .IsUnique();

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Verificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaVerificacion")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdIncidencia")
                        .HasColumnType("int");

                    b.Property<string>("IdTrainer")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdIncidencia")
                        .IsUnique();

                    b.HasIndex("IdTrainer");

                    b.ToTable("Verificaciones", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Ciudad", b =>
                {
                    b.HasOne("Dominio.Entidades.Departamento", "Departamento")
                        .WithMany("Ciudades")
                        .HasForeignKey("IdDepartamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Dominio.Entidades.Componente", b =>
                {
                    b.HasOne("Dominio.Entidades.Categoria", "Categoria")
                        .WithMany("Componentes")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Puesto", "Puesto")
                        .WithMany("Componentes")
                        .HasForeignKey("IdPuesto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.TipoComponente", "TipoComponente")
                        .WithMany("Componentes")
                        .HasForeignKey("IdTipoComponente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Puesto");

                    b.Navigation("TipoComponente");
                });

            modelBuilder.Entity("Dominio.Entidades.Contacto", b =>
                {
                    b.HasOne("Dominio.Entidades.AreaContacto", "AreaContacto")
                        .WithMany("Contactos")
                        .HasForeignKey("IdAreaContacto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.TipoContacto", "TipoContacto")
                        .WithMany("Contactos")
                        .HasForeignKey("IdTipoContacto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AreaContacto");

                    b.Navigation("TipoContacto");
                });

            modelBuilder.Entity("Dominio.Entidades.Departamento", b =>
                {
                    b.HasOne("Dominio.Entidades.Pais", "Pais")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Dominio.Entidades.Direccion", b =>
                {
                    b.HasOne("Dominio.Entidades.Ciudad", "Ciudad")
                        .WithMany("Direcciones")
                        .HasForeignKey("IdCiudad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");
                });

            modelBuilder.Entity("Dominio.Entidades.Incidencia", b =>
                {
                    b.HasOne("Dominio.Entidades.Categoria", "Categoria")
                        .WithMany("Incidencias")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Persona", "Persona")
                        .WithMany("Incidencias")
                        .HasForeignKey("IdPersona");

                    b.HasOne("Dominio.Entidades.TipoIncidencia", "TipoIncidencia")
                        .WithMany("Incidencias")
                        .HasForeignKey("IdTipoIncidencia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Persona");

                    b.Navigation("TipoIncidencia");
                });

            modelBuilder.Entity("Dominio.Entidades.IncidenciaPuesto", b =>
                {
                    b.HasOne("Dominio.Entidades.Componente", "Componente")
                        .WithMany("IncidenciaPuestos")
                        .HasForeignKey("IdComponente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.EstadoIncidencia", "EstadoIncidencia")
                        .WithMany("IncidenciaPuestos")
                        .HasForeignKey("IdEstadoIncidencia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Incidencia", "Incidencia")
                        .WithMany("IncidenciaPuestos")
                        .HasForeignKey("IdIncidencia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Puesto", "Puesto")
                        .WithMany("IncidenciaPuestos")
                        .HasForeignKey("IdPuesto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Componente");

                    b.Navigation("EstadoIncidencia");

                    b.Navigation("Incidencia");

                    b.Navigation("Puesto");
                });

            modelBuilder.Entity("Dominio.Entidades.Persona", b =>
                {
                    b.HasOne("Dominio.Entidades.ARL", "ARL")
                        .WithMany("Personas")
                        .HasForeignKey("IdARL");

                    b.HasOne("Dominio.Entidades.EPS", "EPS")
                        .WithMany("Personas")
                        .HasForeignKey("IdEPS");

                    b.HasOne("Dominio.Entidades.Genero", "Genero")
                        .WithMany("Personas")
                        .HasForeignKey("IdGenero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Rol", "Rol")
                        .WithMany("Personas")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ARL");

                    b.Navigation("EPS");

                    b.Navigation("Genero");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Dominio.Entidades.PersonaContacto", b =>
                {
                    b.HasOne("Dominio.Entidades.Contacto", "Contacto")
                        .WithMany("PersonasContactos")
                        .HasForeignKey("IdContacto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Persona", "Persona")
                        .WithMany("PersonasContactos")
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contacto");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Dominio.Entidades.PersonaDireccion", b =>
                {
                    b.HasOne("Dominio.Entidades.Direccion", "Direccion")
                        .WithMany("PersonaDirecciones")
                        .HasForeignKey("IdDireccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Persona", "Persona")
                        .WithMany("PersonaDirecciones")
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direccion");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Dominio.Entidades.Puesto", b =>
                {
                    b.HasOne("Dominio.Entidades.Salon", "Salon")
                        .WithMany("Puestos")
                        .HasForeignKey("IdSalon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("Dominio.Entidades.Salon", b =>
                {
                    b.HasOne("Dominio.Entidades.Area", "Area")
                        .WithMany("Salones")
                        .HasForeignKey("IdArea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("Dominio.Entidades.Usuario", b =>
                {
                    b.HasOne("Dominio.Entidades.Persona", "Persona")
                        .WithOne()
                        .HasForeignKey("Dominio.Entidades.Usuario", "IdPersona");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Dominio.Entidades.Verificacion", b =>
                {
                    b.HasOne("Dominio.Entidades.EstadoVerificacion", "EstadoVerificacion")
                        .WithMany("Verificaciones")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Incidencia", "Incidencia")
                        .WithOne()
                        .HasForeignKey("Dominio.Entidades.Verificacion", "IdIncidencia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Persona", "Persona")
                        .WithMany("Verificaciones")
                        .HasForeignKey("IdTrainer");

                    b.Navigation("EstadoVerificacion");

                    b.Navigation("Incidencia");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Dominio.Entidades.ARL", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entidades.Area", b =>
                {
                    b.Navigation("Salones");
                });

            modelBuilder.Entity("Dominio.Entidades.AreaContacto", b =>
                {
                    b.Navigation("Contactos");
                });

            modelBuilder.Entity("Dominio.Entidades.Categoria", b =>
                {
                    b.Navigation("Componentes");

                    b.Navigation("Incidencias");
                });

            modelBuilder.Entity("Dominio.Entidades.Ciudad", b =>
                {
                    b.Navigation("Direcciones");
                });

            modelBuilder.Entity("Dominio.Entidades.Componente", b =>
                {
                    b.Navigation("IncidenciaPuestos");
                });

            modelBuilder.Entity("Dominio.Entidades.Contacto", b =>
                {
                    b.Navigation("PersonasContactos");
                });

            modelBuilder.Entity("Dominio.Entidades.Departamento", b =>
                {
                    b.Navigation("Ciudades");
                });

            modelBuilder.Entity("Dominio.Entidades.Direccion", b =>
                {
                    b.Navigation("PersonaDirecciones");
                });

            modelBuilder.Entity("Dominio.Entidades.EPS", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entidades.EstadoIncidencia", b =>
                {
                    b.Navigation("IncidenciaPuestos");
                });

            modelBuilder.Entity("Dominio.Entidades.EstadoVerificacion", b =>
                {
                    b.Navigation("Verificaciones");
                });

            modelBuilder.Entity("Dominio.Entidades.Genero", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entidades.Incidencia", b =>
                {
                    b.Navigation("IncidenciaPuestos");
                });

            modelBuilder.Entity("Dominio.Entidades.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Dominio.Entidades.Persona", b =>
                {
                    b.Navigation("Incidencias");

                    b.Navigation("PersonaDirecciones");

                    b.Navigation("PersonasContactos");

                    b.Navigation("Verificaciones");
                });

            modelBuilder.Entity("Dominio.Entidades.Puesto", b =>
                {
                    b.Navigation("Componentes");

                    b.Navigation("IncidenciaPuestos");
                });

            modelBuilder.Entity("Dominio.Entidades.Rol", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entidades.Salon", b =>
                {
                    b.Navigation("Puestos");
                });

            modelBuilder.Entity("Dominio.Entidades.TipoComponente", b =>
                {
                    b.Navigation("Componentes");
                });

            modelBuilder.Entity("Dominio.Entidades.TipoContacto", b =>
                {
                    b.Navigation("Contactos");
                });

            modelBuilder.Entity("Dominio.Entidades.TipoIncidencia", b =>
                {
                    b.Navigation("Incidencias");
                });
#pragma warning restore 612, 618
        }
    }
}
