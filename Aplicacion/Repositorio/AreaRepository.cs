using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio;
public class AreaRepository : GenericRepositoryInt<Area>, IArea
{
    private readonly IncidenciasContext _context;
    
    public AreaRepository(IncidenciasContext context): base (context)
    {
        _context = context;
    }

    public override async Task<(int totalRegistros, IEnumerable<Area> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Areas as IQueryable<Area>;
        if(!string.IsNullOrEmpty(search)) query=query.Where(p=>p.Nombre.ToLower().Contains(search));
        var totalRegistros=await query.CountAsync();
        var registros = await query
            .Include(p=>p.Salones)
            .Skip((pageIndex-1)*pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros,registros);
    }

     public override async Task<Area> GetByIdAsync(int id)
    {
        return await _context.Areas
        .Include(p=>p.Salones)
        .FirstOrDefaultAsync(p=>p.Id == id);
    }
}
