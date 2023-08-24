using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class PuestoRepository : GenericRepositoryInt<Puesto>, IPuesto
    {
        private readonly IncidenciasContext _context;
        
        public PuestoRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<(int totalRegistros, IEnumerable<Puesto> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Puestos as IQueryable<Puesto>;
            if(!string.IsNullOrEmpty(search)) query = query.Where(p=>p.Descripcion.ToLower().Contains(search));
            var totalRegistros=await query.CountAsync();
            var registros = await query
                .Include(p => p.Componentes)
                .Include(p => p.IncidenciaPuestos)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public override async Task<Puesto> GetByIdAsync(int id)
        {
            return await _context.Puestos
                .Include(p => p.Componentes)
                .Include(p => p.IncidenciaPuestos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}