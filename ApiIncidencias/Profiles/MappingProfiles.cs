using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos;
using ApiIncidencias.Dtos.Area;
using ApiIncidencias.Dtos.Puesto;
using ApiIncidencias.Dtos.Salon;
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
    }

}
