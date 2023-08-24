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
    public class PersonaDireccionRepository:IPersonaDireccion
    {
        private readonly IncidenciasContext _context;
        
        public PersonaDireccionRepository(IncidenciasContext context)
        {
            _context = context;
        }
        
        public void Add(PersonaDireccion entity)
        {
            _context.Set<PersonaDireccion>().Add(entity);
        }
        
        public void AddRange(IEnumerable<PersonaDireccion> entities)
        {
            _context.Set<PersonaDireccion>().AddRange(entities);
        }
        
        public IEnumerable<PersonaDireccion> Find(Expression<Func<PersonaDireccion, bool>> expression)
        {
            return _context.Set<PersonaDireccion>().Where(expression);
        }
        
        public async Task<(int totalRegistros, IEnumerable<PersonaDireccion> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.PersonaDirecciones as IQueryable<PersonaDireccion>;
            // if (!string.IsNullOrEmpty(search))
            //     query = query.Where(p => p.Nombre.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public async Task<PersonaDireccion> GetByIdAsync(string idPersona, int idDireccion)
        {
            return await _context.PersonaDirecciones
                .FirstOrDefaultAsync(p => p.IdPersona == idPersona && p.IdDireccion == idDireccion);
        }
        
        public void Remove(PersonaDireccion entity)
        {
            _context.Set<PersonaDireccion>().Remove(entity);
        }
        
        public void RemoveRange(IEnumerable<PersonaDireccion> entities)
        {
            _context.Set<PersonaDireccion>().RemoveRange(entities);
        }
        
        public void Update(PersonaDireccion entity)
        {
            _context.Set<PersonaDireccion>().Update(entity);
        }
    }
