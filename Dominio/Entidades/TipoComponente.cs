using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class TipoComponente:EntidadGenericaA
    {
        public Categoria Categoria { get; set; }
        public int IdCategoria { get; set; }
        public ICollection<Componente> Componentes {get;set;}
    }
