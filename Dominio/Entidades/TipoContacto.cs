using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class TipoContacto:EntidadGenericaA
    {
        public ICollection<Contacto> Contactos {get;set;}
    }
