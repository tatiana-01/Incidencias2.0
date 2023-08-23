using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos.Verificacion;
    public class VerificacionPostDTO
    {
        public int IdEstado { get; set; }
        public string IdTrainer { get; set; }
        public DateTime FechaVerificacion { get; set; }
        public int IdIncidencia {get;set;}
    }
