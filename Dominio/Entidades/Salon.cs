using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class Salon:EntidadGenericaA
    {
        public int NroPuestos {get;set;}
        public Area Area { get; set; }
        public int IdArea { get; set; }
        public ICollection<Puesto> Puestos {get;set;}
    }
