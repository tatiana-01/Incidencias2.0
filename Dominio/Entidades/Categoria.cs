using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class Categoria:EntidadGenericaA
    {
        public ICollection<Incidencia> Incidencias {get;set;}
        public ICollection<Componente> Componentes {get;set;}
        public ICollection<TipoComponente> TipoComponentes {get;set;}
    }
