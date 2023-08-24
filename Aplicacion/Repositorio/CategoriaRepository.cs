using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio;
    public class CategoriaRepository:GenericRepositoryInt<Categoria>, ICategoria
    {
        private readonly IncidenciasContext _context;
        
        public CategoriaRepository(IncidenciasContext context) : base (context)
        {
            _context = context;
        }

        public override async Task<(int totalRegistros, IEnumerable<Categoria> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Categorias as IQueryable<Categoria>;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Nombre.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Componentes)
                .Include(p => p.Incidencias)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public override async Task<Categoria> GetByIdAsync(int id)
        {
            return await _context.Categorias
                .Include(p => p.Componentes)
                .Include(p => p.Incidencias)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
