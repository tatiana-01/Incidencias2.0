using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class SalonRepository : GenericRepositoryInt<Salon>, ISalon
    {
        private readonly IncidenciasContext _context;
        
        public SalonRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<(int totalRegistros, IEnumerable<Salon>registros)>GetAllAsync(int pageIndex, int pageSize, string search){
            var query= _context.Salones as IQueryable<Salon>;
            if(!string.IsNullOrEmpty(search)) query = query.Where(p=>p.Nombre.ToLower().Contains(search));
            var totalRegistros=await query.CountAsync();
            var registros = await query
            .Include(p=>p.Puestos)
            .Skip((pageIndex-1)*pageSize)
            .Take(pageSize)
            .ToListAsync();
            return(totalRegistros,registros);
        }

        public override async Task<Salon> GetByIdAsync(int id){
            return await _context.Salones
            .Include(p=>p.Puestos)
            .FirstOrDefaultAsync(p=>p.Id==id);
        }
    }
}