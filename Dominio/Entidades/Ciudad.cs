using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class Ciudad:EntidadGenericaA
    {
        public Departamento Departamento { get; set; }
        public int IdDepartamento { get; set; }
        public ICollection<Direccion> Direcciones {get;set;}
    }
