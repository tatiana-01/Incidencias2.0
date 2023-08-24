using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class GeneroRepository : GenericRepositoryInt<Genero>, IGenero
    {
        private readonly IncidenciasContext _context;
        
        public GeneroRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<(int totalRegistros, IEnumerable<Genero> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Generos as IQueryable<Genero>;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Nombre.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Personas)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
        
        public override async Task<Genero> GetByIdAsync(int id)
        {
            return await _context.Generos
                .Include(p => p.Personas)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}