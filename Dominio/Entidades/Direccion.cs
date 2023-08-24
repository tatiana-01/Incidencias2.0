using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class Direccion:EntidadGenericaInt
    {
        public string TipoVia {get;set;}
        public int ? Numero {get;set;}
        public char ? Letra {get;set;}
        public string ? SufijoCardinal {get;set;}
        public string ? NroViaSecundaria {get;set;}
        public char ? LetraViaSecundaria {get;set;}
        public Ciudad Ciudad {get;set;}
        public int IdCiudad {get;set;}
        public ICollection<PersonaDireccion> PersonaDirecciones {get;set;}

    }
