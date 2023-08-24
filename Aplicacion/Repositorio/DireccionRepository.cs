using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio;
    public class DireccionRepository: GenericRepositoryInt<Direccion>, IDireccion
    {
        private readonly IncidenciasContext _context;
        
        public DireccionRepository(IncidenciasContext context): base (context)
        {
            _context = context;
        }
        public override async Task<(int totalRegistros, IEnumerable<Direccion> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Direcciones as IQueryable<Direccion>;
            // if (!string.IsNullOrEmpty(search))
            //     query = query.Where(p => p..ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.PersonaDirecciones)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public override async Task<Direccion> GetByIdAsync(int id)
        {
            return await _context.Direcciones
                .Include(p => p.PersonaDirecciones)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
