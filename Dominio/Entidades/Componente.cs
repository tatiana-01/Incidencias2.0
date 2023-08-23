using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class Componente:EntidadGenericaInt
    {
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public TipoComponente TipoComponente { get; set; }
        public int IdTipoComponente { get; set; }
        public Puesto Puesto { get; set; }
        public int IdPuesto { get; set; }
        public Categoria Categoria { get; set; }
        public int IdCategoria { get; set; }
        public ICollection<IncidenciaPuesto> IncidenciaPuestos {get;set;}
    }
