using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class Pais:EntidadGenericaA
    {
        public ICollection<Departamento> Departamentos {get;set;}
    }
