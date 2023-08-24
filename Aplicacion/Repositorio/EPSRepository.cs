using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio;
    public class EPSRepository: GenericRepositoryInt<EPS>, IEPS
    {
        private readonly IncidenciasContext _context;
        
        public EPSRepository(IncidenciasContext context): base (context)
        {
            _context = context;
        }

        public override async Task<(int totalRegistros, IEnumerable<EPS> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.EPSs as IQueryable<EPS>;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Nombre.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Personas)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public override async Task<EPS> GetByIdAsync(int id)
        {
            return await _context.EPSs
                .Include(p => p.Personas)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }