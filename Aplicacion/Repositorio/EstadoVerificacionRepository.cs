using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class EstadoVerificacionRepository : GenericRepositoryInt<EstadoVerificacion>, IEstadoVerificacion
    {
        private readonly IncidenciasContext _context;
        
        public EstadoVerificacionRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<(int totalRegistros, IEnumerable<EstadoVerificacion> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.EstadoVerificaciones as IQueryable<EstadoVerificacion>;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Nombre.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Verificaciones)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public override async Task<EstadoVerificacion> GetByIdAsync(int id)
        {
            return await _context.EstadoVerificaciones
                .Include(p => p.Verificaciones)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}