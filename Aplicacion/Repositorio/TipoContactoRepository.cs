using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class TipoContactoRepository : GenericRepositoryInt<TipoContacto>, ITipoContacto
    {
        private readonly IncidenciasContext _context;
        
        public TipoContactoRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<(int totalRegistros, IEnumerable<TipoContacto> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.TipoContactos as IQueryable<TipoContacto>;
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
        
        public override async Task<TipoContacto> GetByIdAsync(int id)
        {
            return await _context.TipoContactos
                .Include(p => p.Contactos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}