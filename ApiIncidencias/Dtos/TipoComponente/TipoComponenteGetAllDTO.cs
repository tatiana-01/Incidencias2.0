using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos.Componente;

namespace ApiIncidencias.Dtos.TipoComponente;
    public class TipoComponenteGetAllDTO
    {
        public int Id { get; set; }
        public string Nombre {get; set;}
        public ICollection<ComponenteDTO> Componentes {get;set;}
    }
