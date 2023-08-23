using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class Puesto:EntidadGenericaInt
    {
        public Salon Salon { get; set; }
        public int IdSalon { get; set; }
        public string Descripcion {get; set;}
        public ICollection<Componente> Componentes {get;set;}
        public ICollection<IncidenciaPuesto> IncidenciaPuestos {get;set;}
        
    }
