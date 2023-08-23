using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class Area:EntidadGenericaA
    {
        public string Descripcion { get; set; }
        public ICollection<Salon> Salones {get;set;}
    }
