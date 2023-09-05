using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class Persona
    {
        public string Id {get;set;}
        public string Nombre {get;set;}
        public DateOnly FechaNacimiento {get;set;}
        public Genero Genero {get;set;}
        public int IdGenero {get;set;}
        public EPS EPS {get;set;}
        public int ? IdEPS {get;set;}
        public ARL ARL {get;set;}
        public int ? IdARL {get;set;}
        public ICollection<PersonaContacto> PersonasContactos {get;set;}
        public ICollection<Incidencia> Incidencias {get;set;}
        public ICollection<PersonaDireccion> PersonaDirecciones {get;set;}
        public ICollection<Verificacion> Verificaciones {get;set;}
    }
