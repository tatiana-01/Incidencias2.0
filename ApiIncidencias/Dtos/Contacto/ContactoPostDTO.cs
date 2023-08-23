using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos.Contacto;
    public class ContactoPostDTO
    {
        public string ContactoPersona {get;set;}
        public int IdTipoContacto {get;set;}
        public int IdAreaContacto {get;set;}
    }
