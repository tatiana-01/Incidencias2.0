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
    public class PersonaRepository:IPersona
    {
        private readonly IncidenciasContext _context;
        
        public PersonaRepository(IncidenciasContext context)
        {
            _context = context;
        }
        
        public void Add(Persona entity)
        {
            _context.Set<Persona>().Add(entity);
        }
        
        public void AddRange(IEnumerable<Persona> entities)
        {
            _context.Set<Persona>().AddRange(entities);
        }
        
        public IEnumerable<Persona> Find(Expression<Func<Persona, bool>> expression)
        {
            return _context.Set<Persona>().Where(expression);
        }
        
        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Set<Persona>().ToListAsync();
        }
        
        public async Task<Persona> GetByIdAsync(string id)
        {
            return await _context.Personas
                .Include(p => p.PersonaDirecciones)
                .Include(p => p.PersonasContactos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        
        public void Remove(Persona entity)
        {
            _context.Set<Persona>().Remove(entity);
        }
        
        public void RemoveRange(IEnumerable<Persona> entities)
        {
            _context.Set<Persona>().RemoveRange(entities);
        }
        
        public void Update(Persona entity)
        {
            _context.Set<Persona>().Update(entity);
        }

        public virtual async Task<(int totalRegistros, IEnumerable<Persona> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Personas as IQueryable<Persona>;
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Nombre.ToLower().Contains(search));
            }
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.PersonaDirecciones)
                .Include(p => p.PersonasContactos)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
    }
