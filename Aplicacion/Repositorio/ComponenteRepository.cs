using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class ComponenteRepository : GenericRepositoryInt<Componente>, IComponente
    {
        private readonly IncidenciasContext _context;
        
        public ComponenteRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<(int totalRegistros, IEnumerable<Componente> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Componentes as IQueryable<Componente>;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Descripcion.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.IncidenciaPuestos)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public override async Task<Componente> GetByIdAsync(int id)
        {
            return await _context.Componentes
                .Include(p => p.IncidenciaPuestos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}