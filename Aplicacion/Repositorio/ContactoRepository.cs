using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio;
public class ContactoRepository : GenericRepositoryInt<Contacto>, IContacto
{
    private readonly IncidenciasContext _context;
    public ContactoRepository(IncidenciasContext context) : base(context)
    {
        _context=context;
    }
    public override async Task<(int totalRegistros, IEnumerable<Contacto> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Contactos as IQueryable<Contacto>;
        if (!string.IsNullOrEmpty(search))
            query = query.Where(p => p.ContactoPersona.ToLower().Contains(search));
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Include(p => p.PersonasContactos)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }
    
    public override async Task<Contacto> GetByIdAsync(int id)
    {
        return await _context.Contactos
            .Include(p => p.PersonasContactos)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
