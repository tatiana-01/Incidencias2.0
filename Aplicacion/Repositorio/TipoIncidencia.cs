using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class TipoIncidenciaRepository : GenericRepositoryInt<TipoIncidencia>, ITipoIncidencia
    {
        private readonly IncidenciasContext _context;
        
        public TipoIncidenciaRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<(int totalRegistros, IEnumerable<TipoIncidencia> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.TipoIncidencias as IQueryable<TipoIncidencia>;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Nombre.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Incidencias)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public override async Task<TipoIncidencia> GetByIdAsync(int id)
        {
            return await _context.TipoIncidencias
                .Include(p => p.Incidencias)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}