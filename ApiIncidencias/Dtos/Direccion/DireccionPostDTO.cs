using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos.Direccion;
    public class DireccionPostDTO
    {
        public string TipoVia {get;set;}
        public int ? Numero {get;set;}
        public char ? Letra {get;set;}
        public string ? SufijoCardinal {get;set;}
        public string ? NroViaSecundaria {get;set;}
        public char ? LetraViaSecundaria {get;set;}
        public int IdCiudad {get;set;}
    }
