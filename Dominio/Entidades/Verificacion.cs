using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class Verificacion:EntidadGenericaInt    
    {
        public EstadoVerificacion EstadoVerificacion { get; set; }
        public int IdEstado { get; set; }
        public Persona Persona { get; set; }
        public string IdTrainer { get; set; }
        public DateTime FechaVerificacion { get; set; }
        public Incidencia Incidencia {get;set;}
        public int IdIncidencia {get;set;}
    }
