using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio;
    public class AreaContactoRepository: GenericRepositoryInt<AreaContacto>, IAreaContacto
    {
        private readonly IncidenciasContext _context;
        
        public AreaContactoRepository(IncidenciasContext context): base (context)
        {
            _context = context;
        }

        public override async Task<(int totalRegistros, IEnumerable<AreaContacto> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.AreaContactos as IQueryable<AreaContacto>;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Nombre.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Contactos)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public override async Task<AreaContacto> GetByIdAsync(int id)
        {
            return await _context.AreaContactos
                .Include(p => p.Contactos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
