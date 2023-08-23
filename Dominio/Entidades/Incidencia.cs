using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class Incidencia:EntidadGenericaInt
    {
        public TipoIncidencia TipoIncidencia {get;set;}
        public int IdTipoIncidencia {get;set;}
        public Categoria Categoria { get; set; }
        public int IdCategoria { get; set; }
        public Persona Persona {get;set;}
        public string IdPersona { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaReporte { get; set; }
        public ICollection<IncidenciaPuesto> IncidenciaPuestos {get;set;}
    }
