using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio;
    public class EstadoIncidenciaRepository: GenericRepositoryInt<EstadoIncidencia>, IEstadoIncidencia
    {
        private readonly IncidenciasContext _context;
        
        public EstadoIncidenciaRepository(IncidenciasContext context): base (context)
        {
            _context = context;
        }

        public override async Task<(int totalRegistros, IEnumerable<EstadoIncidencia> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.EstadoIncidencias as IQueryable<EstadoIncidencia>;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Nombre.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.IncidenciaPuestos)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public override async Task<EstadoIncidencia> GetByIdAsync(int id)
        {
            return await _context.EstadoIncidencias
                .Include(p => p.IncidenciaPuestos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }