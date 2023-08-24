using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio;
    public class IncidenciaPuestoRepository:IIncidenciaPuesto
    {
        private readonly IncidenciasContext _context;
        
        public IncidenciaPuestoRepository(IncidenciasContext context)
        {
            _context = context;
        }
        
        public void Add(IncidenciaPuesto entity)
        {
            _context.Set<IncidenciaPuesto>().Add(entity);
        }
        
        public void AddRange(IEnumerable<IncidenciaPuesto> entities)
        {
            _context.Set<IncidenciaPuesto>().AddRange(entities);
        }
        
        public IEnumerable<IncidenciaPuesto> Find(Expression<Func<IncidenciaPuesto, bool>> expression)
        {
            return _context.Set<IncidenciaPuesto>().Where(expression);
        }
        
        public async Task<IEnumerable<IncidenciaPuesto>> GetAllAsync()
        {
            return await _context.Set<IncidenciaPuesto>().ToListAsync();
        }
        
        public virtual async Task<(int totalRegistros, IEnumerable<IncidenciaPuesto> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.IncidenciaPuestos as IQueryable<IncidenciaPuesto>;
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Descripcion.ToLower().Contains(search));
            }
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }

    public async Task<IncidenciaPuesto> GetByIdAsync(int IdIncidencia, int IdPuesto, int IdComponente)
        {
            return await _context.IncidenciaPuestos
                .FirstOrDefaultAsync(p => p.IdIncidencia == IdIncidencia && p.IdPuesto == IdPuesto && p.IdComponente == IdComponente);
        }
        
        public void Remove(IncidenciaPuesto entity)
        {
            _context.Set<IncidenciaPuesto>().Remove(entity);
        }
        
        public void RemoveRange(IEnumerable<IncidenciaPuesto> entities)
        {
            _context.Set<IncidenciaPuesto>().RemoveRange(entities);
        }
        
        public void Update(IncidenciaPuesto entity)
        {
            _context.Set<IncidenciaPuesto>().Update(entity);
        }
    }
