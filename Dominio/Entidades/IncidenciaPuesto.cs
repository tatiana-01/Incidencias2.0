using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades;
    public class IncidenciaPuesto
    {
        public Incidencia Incidencia { get; set; }
        public int IdIncidencia { get; set; }
        public Puesto Puesto { get; set; }
        public int IdPuesto { get; set; }
        public Componente Componente { get; set; }
        public int IdComponente { get; set; }
        public EstadoIncidencia EstadoIncidencia { get; set; }
        public int IdEstadoIncidencia { get; set; }
        public string Descripcion {get; set;}
    }
