using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class RolRepository : GenericRepositoryInt<Rol>, IRol
    {
        private readonly IncidenciasContext _context;
        
        public RolRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<(int totalRegistros, IEnumerable<Rol> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Roles as IQueryable<Rol>;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Nombre.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Usuarios)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public async Task<Rol> GetByIdAsync(int id)
        {
            return await _context.Roles
                .Include(p => p.Usuarios)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}