using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos.Contacto;

namespace ApiIncidencias.Dtos.TipoContacto;
    public class TipoContactoGetAllDTO
    {
        public int Id { get; set; }
        public string Nombre {get; set;}
        public ICollection<ContactoDTO> Contactos {get;set;}
    }
