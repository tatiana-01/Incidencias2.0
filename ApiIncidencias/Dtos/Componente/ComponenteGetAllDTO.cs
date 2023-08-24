using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos.IncidenciaPuesto;

namespace ApiIncidencias.Dtos.Componente;
    public class ComponenteGetAllDTO
    {
        public int Id { get; set;}
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoComponente { get; set; }
        public int IdPuesto { get; set; }
        public int IdCategoria { get; set; }
        public ICollection<IncidenciaPuestoDTO> IncidenciaPuestos {get;set;}
    }
