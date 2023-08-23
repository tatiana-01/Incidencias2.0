using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos.Contacto;
    public class ContactoGetAllDTO
    {
        public int Id { get; set;}
        public string ContactoPersona {get;set;}
        public int IdTipoContacto {get;set;}
        public int IdAreaContacto {get;set;}
        public ICollection<PersonaContactoDTO> PersonasContactos {get;set;}
    }
