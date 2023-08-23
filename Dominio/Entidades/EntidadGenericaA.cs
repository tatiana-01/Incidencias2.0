using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class EntidadGenericaA : EntidadGenericaInt
    {
        [MaxLength(50),Required]
        public string Nombre {get; set;}
    }
