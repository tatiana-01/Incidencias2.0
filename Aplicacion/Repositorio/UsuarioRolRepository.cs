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
    public class UsuarioRolRepository:IUsuarioRol
    {
        private readonly IncidenciasContext _context;
        
        public UsuarioRolRepository(IncidenciasContext context)
        {
            _context = context;
        }
        
        public void Add(UsuarioRol entity)
        {
            _context.Set<UsuarioRol>().Add(entity);
        }
        
        public void AddRange(IEnumerable<UsuarioRol> entities)
        {
            _context.Set<UsuarioRol>().AddRange(entities);
        }
        
        public IEnumerable<UsuarioRol> Find(Expression<Func<UsuarioRol, bool>> expression)
        {
            return _context.Set<UsuarioRol>().Where(expression);
        }
        
        public async Task<(int totalRegistros, IEnumerable<UsuarioRol> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.UsuarioRoles as IQueryable<UsuarioRol>;
            // if (!string.IsNullOrEmpty(search))
            //     query = query.Where(p => p.Nombre.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public async Task<UsuarioRol> GetByIdAsync(int IdUsuario, int IdRol)
        {
            return await _context.UsuarioRoles
                .FirstOrDefaultAsync(p => p.IdUsuario == IdUsuario && p.IdRol == IdRol);
        }
        
        public void Remove(UsuarioRol entity)
        {
            _context.Set<UsuarioRol>().Remove(entity);
        }
        
        public void RemoveRange(IEnumerable<UsuarioRol> entities)
        {
            _context.Set<UsuarioRol>().RemoveRange(entities);
        }
        
        public void Update(UsuarioRol entity)
        {
            _context.Set<UsuarioRol>().Update(entity);
        }
    }
