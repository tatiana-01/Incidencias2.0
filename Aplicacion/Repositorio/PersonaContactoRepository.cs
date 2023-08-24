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
    public class PersonaContactoRepository:IPersonaContacto
    {
        private readonly IncidenciasContext _context;
        
        public PersonaContactoRepository(IncidenciasContext context)
        {
            _context = context;
        }
        
        public void Add(PersonaContacto entity)
        {
            _context.Set<PersonaContacto>().Add(entity);
        }
        
        public void AddRange(IEnumerable<PersonaContacto> entities)
        {
            _context.Set<PersonaContacto>().AddRange(entities);
        }
        
        public IEnumerable<PersonaContacto> Find(Expression<Func<PersonaContacto, bool>> expression)
        {
            return _context.Set<PersonaContacto>().Where(expression);
        }
        
        public async Task<(int totalRegistros, IEnumerable<PersonaContacto> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.PersonaContactos as IQueryable<PersonaContacto>;
            // if (!string.IsNullOrEmpty(search))
            //     query = query.Where(p => p.Nombre.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public async Task<PersonaContacto> GetByIdAsync(string idPersona, int idContacto)
        {
            return await _context.PersonaContactos
                .FirstOrDefaultAsync(p => p.IdPersona == idPersona && p.IdContacto == idContacto);
        }
        
        public void Remove(PersonaContacto entity)
        {
            _context.Set<PersonaContacto>().Remove(entity);
        }
        
        public void RemoveRange(IEnumerable<PersonaContacto> entities)
        {
            _context.Set<PersonaContacto>().RemoveRange(entities);
        }
        
        public void Update(PersonaContacto entity)
        {
            _context.Set<PersonaContacto>().Update(entity);
        }

    }
