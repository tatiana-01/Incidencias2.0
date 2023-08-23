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
        
        public async Task<IEnumerable<PersonaContacto>> GetAllAsync()
        {
            return await _context.Set<PersonaContacto>().ToListAsync();
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
