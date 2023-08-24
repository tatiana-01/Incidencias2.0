using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class TipoComponenteRepository : GenericRepositoryInt<TipoComponente>, ITipoComponente
    {
        private readonly IncidenciasContext _context;
        
        public TipoComponenteRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<(int totalRegistros, IEnumerable<TipoComponente> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.TipoComponentes as IQueryable<TipoComponente>;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Nombre.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Componentes)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public override async Task<TipoComponente> GetByIdAsync(int id)
        {
            return await _context.TipoComponentes
                .Include(p => p.Componentes)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}