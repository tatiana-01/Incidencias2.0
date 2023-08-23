using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio;
    public class CiudadRepository: GenericRepositoryInt<Ciudad>, ICiudad
    {
        private readonly IncidenciasContext _context;
        
        public CiudadRepository(IncidenciasContext context) :  base(context)
        {
            _context = context;
        }
    }
