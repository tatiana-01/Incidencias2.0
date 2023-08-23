using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos.Departamento;
    public class DepartamentoDTO
    {
        public int Id { get; set; }
        public string Nombre {get; set;}
        public int IdPais {get;set;}
    }
