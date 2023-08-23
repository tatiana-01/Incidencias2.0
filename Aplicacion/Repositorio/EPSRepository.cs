using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio;
    public class EPSRepository: GenericRepositoryInt<EPS>, IEPS
    {
        private readonly IncidenciasContext _context;
        
        public EPSRepository(IncidenciasContext context): base (context)
        {
            _context = context;
        }
    }