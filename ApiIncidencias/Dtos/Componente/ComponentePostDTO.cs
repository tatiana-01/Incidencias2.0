using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos.Componente;
    public class ComponentePostDTO
    {
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoComponente { get; set; }
        public int IdPuesto { get; set; }
        public int IdCategoria { get; set; }
    }
