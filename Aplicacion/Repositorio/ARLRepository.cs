using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio;

public class ARLRepository : GenericRepositoryInt<ARL>, IARL
{
        private readonly IncidenciasContext _context;
        
        public ARLRepository(IncidenciasContext context) : base (context)
        {
            _context = context;
        }
    }
