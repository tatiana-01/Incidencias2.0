using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos.Verificacion;
    public class VerificacionDTO
    {
        public int Id { get; set;}
        public int IdEstado { get; set; }
        public string IdTrainer { get; set; }
        public DateTime FechaVerificacion { get; set; }
        public int IdIncidencia {get;set;}
    }
