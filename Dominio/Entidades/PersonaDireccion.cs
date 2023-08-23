using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class PersonaDireccion
    {
        public Persona Persona { get; set; }    
        public string IdPersona { get; set; }
        public Direccion Direccion { get; set; }
        public int IdDireccion { get; set; }
    }
