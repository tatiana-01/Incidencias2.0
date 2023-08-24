using ApiIncidencias.Dtos;
using ApiIncidencias.Dtos.Area;
using ApiIncidencias.Dtos.AreaContacto;
using ApiIncidencias.Dtos.ARL;
using ApiIncidencias.Dtos.Categoria;
using ApiIncidencias.Dtos.Ciudad;
using ApiIncidencias.Dtos.Componente;
using ApiIncidencias.Dtos.Contacto;
using ApiIncidencias.Dtos.Departamento;
using ApiIncidencias.Dtos.Direccion;
using ApiIncidencias.Dtos.EPS;
using ApiIncidencias.Dtos.EstadoIncidencia;
using ApiIncidencias.Dtos.EstadoVerificacion;
using ApiIncidencias.Dtos.Genero;
using ApiIncidencias.Dtos.Incidencia;
using ApiIncidencias.Dtos.IncidenciaPuesto;
using ApiIncidencias.Dtos.Pais;
using ApiIncidencias.Dtos.Persona;
using ApiIncidencias.Dtos.Puesto;
using ApiIncidencias.Dtos.Rol;
using ApiIncidencias.Dtos.Salon;
using ApiIncidencias.Dtos.TipoComponente;
using ApiIncidencias.Dtos.TipoContacto;
using ApiIncidencias.Dtos.TipoIncidencia;
using ApiIncidencias.Dtos.Usuario;
using ApiIncidencias.Dtos.Verificacion;
using AutoMapper;
using Dominio.Entidades;

namespace ApiIncidencias.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Area, AreaGetAllDTO>().ReverseMap();
        CreateMap<Area, AreaDTO>().ReverseMap();
        CreateMap<Area, AreaPostDTO>().ReverseMap();

        CreateMap<Salon, SalonGetAllDTO>().ReverseMap();
        CreateMap<Salon, SalonDTO>().ReverseMap();
        CreateMap<Salon, SalonPostDTO>().ReverseMap();

        CreateMap<Puesto, PuestoGetAllDTO>().ReverseMap();
        CreateMap<Puesto, PuestoDTO>().ReverseMap();
        CreateMap<Puesto, PuestoPostDTO>().ReverseMap();

        CreateMap<AreaContacto, AreaContactoGetAllDTO>().ReverseMap();
        CreateMap<AreaContacto, AreaContactoDTO>().ReverseMap();
        CreateMap<AreaContacto, AreaContactoPostDTO>().ReverseMap();

        CreateMap<ARL, ARLGetAllDTO>().ReverseMap();
        CreateMap<ARL, ARLDTO>().ReverseMap();
        CreateMap<ARL, ARLPostDTO>().ReverseMap();

        CreateMap<Categoria, CategoriaGetAllDTO>().ReverseMap();
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        CreateMap<Categoria, CategoriaPostDTO>().ReverseMap();

        CreateMap<Ciudad, CiudadGetAllDTO>().ReverseMap();
        CreateMap<Ciudad, CiudadDTO>().ReverseMap();
        CreateMap<Ciudad, CiudadPostDTO>().ReverseMap();

        CreateMap<Componente, ComponenteDTO>().ReverseMap();
        CreateMap<Componente, ComponentePostDTO>().ReverseMap();

        CreateMap<Contacto, ContactoGetAllDTO>().ReverseMap();
        CreateMap<Contacto, ContactoDTO>().ReverseMap();
        CreateMap<Contacto, ContactoPostDTO>().ReverseMap();

        CreateMap<Departamento, DepartamentoGetAllDTO>().ReverseMap();
        CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
        CreateMap<Departamento, DepartamentoPostDTO>().ReverseMap();

        CreateMap<Direccion, DireccionGetAllDTO>().ReverseMap();
        CreateMap<Direccion, DireccionDTO>().ReverseMap();
        CreateMap<Direccion, DireccionPostDTO>().ReverseMap();

        CreateMap<EPS, EPSGetAllDTO>().ReverseMap();
        CreateMap<EPS, EPSDTO>().ReverseMap();
        CreateMap<EPS, EPSPostDTO>().ReverseMap();

        CreateMap<EstadoIncidencia, EstadoIncidenciaGetAllDTO>().ReverseMap();
        CreateMap<EstadoIncidencia, EstadoIncidenciaDTO>().ReverseMap();
        CreateMap<EstadoIncidencia, EstadoIncidenciaPostDTO>().ReverseMap();

        CreateMap<EstadoVerificacion, EstadoVerificacionGetAllDTO>().ReverseMap();
        CreateMap<EstadoVerificacion, EstadoVerificacionDTO>().ReverseMap();
        CreateMap<EstadoVerificacion, EstadoVerificacionPostDTO>().ReverseMap();

        CreateMap<Genero, GeneroGetAllDTO>().ReverseMap();
        CreateMap<Genero, GeneroDTO>().ReverseMap();
        CreateMap<Genero, GeneroPostDTO>().ReverseMap();

        CreateMap<Incidencia, IncidenciaGetAllDTO>().ReverseMap();
        CreateMap<Incidencia, IncidenciaDTO>().ReverseMap();
        CreateMap<Incidencia, IncidenciaPostDTO>().ReverseMap();

        CreateMap<Pais, PaisGetAllDTO>().ReverseMap();
        CreateMap<Pais, PaisDTO>().ReverseMap();
        CreateMap<Pais, PaisPostDTO>().ReverseMap();

        CreateMap<Persona, PersonaGetAllDTO>().ReverseMap();
        CreateMap<Persona, PersonaDTO>().ReverseMap();

        CreateMap<Rol, RolGetAllDTO>().ReverseMap();
        CreateMap<Rol, RolDTO>().ReverseMap();
        CreateMap<Rol, RolPostDTO>().ReverseMap();
        
        CreateMap<TipoComponente, TipoComponenteGetAllDTO>().ReverseMap();
        CreateMap<TipoComponente, TipoComponenteDTO>().ReverseMap();
        CreateMap<TipoComponente, TipoComponentePostDTO>().ReverseMap();

        CreateMap<TipoContacto, TipoContactoGetAllDTO>().ReverseMap();
        CreateMap<TipoContacto, TipoContactoDTO>().ReverseMap();
        CreateMap<TipoContacto, TipoContactoPostDTO>().ReverseMap();

        CreateMap<TipoIncidencia, TipoIncidenciaGetAllDTO>().ReverseMap();
        CreateMap<TipoIncidencia, TipoIncidenciaDTO>().ReverseMap();
        CreateMap<TipoIncidencia, TipoIncidenciaPostDTO>().ReverseMap();

        CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        CreateMap<Usuario, UsuarioPostDTO>().ReverseMap();

        CreateMap<Verificacion, VerificacionDTO>().ReverseMap();
        CreateMap<Verificacion, VerificacionPostDTO>().ReverseMap();

        CreateMap<IncidenciaPuesto, IncidenciaPuestoDTO>().ReverseMap();
        CreateMap<IncidenciaPuesto, IncidenciaPuestoPutDTO>().ReverseMap();

        CreateMap<PersonaContacto, PersonaContactoDTO>().ReverseMap();
        CreateMap<PersonaDireccion, PersonaDireccionDTO>().ReverseMap();

    }

}
