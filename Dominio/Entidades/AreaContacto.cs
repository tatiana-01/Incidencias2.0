using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class AreaContacto:EntidadGenericaA
    {
        public ICollection<Contacto> Contactos {get;set;}
    }
