using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Helpers;
    public class Autorizacion
    {
        public enum Roles{
            Persona,
            Administrador
        }
        public const Roles rol_predeterminado = Roles.Persona;
    }
