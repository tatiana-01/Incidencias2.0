using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio;
    public class CiudadRepository: GenericRepositoryInt<Ciudad>, ICiudad
    {
        private readonly IncidenciasContext _context;
        
        public CiudadRepository(IncidenciasContext context) :  base(context)
        {
            _context = context;
        }

        public override async Task<(int totalRegistros, IEnumerable<Ciudad> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Ciudades as IQueryable<Ciudad>;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Nombre.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Direcciones)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public override async Task<Ciudad> GetByIdAsync(int id)
        {
            return await _context.Ciudades
                .Include(p => p.Direcciones)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
