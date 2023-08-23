using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio;
    public class AreaContactoRepository: GenericRepositoryInt<AreaContacto>, IAreaContacto
    {
        private readonly IncidenciasContext _context;
        
        public AreaContactoRepository(IncidenciasContext context): base (context)
        {
            _context = context;
        }
    }
