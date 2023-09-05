using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositorio;
public class UsuarioRepository : GenericRepositoryInt<Usuario>, IUsuario
{
    private readonly IncidenciasContext _context;
    private readonly IPasswordHasher<Usuario> _passwordHasher;

    public UsuarioRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return await _context.Usuarios
                            .Include(u => u.Roles)
                            .FirstOrDefaultAsync(u => u.UsuarioPersona.ToLower() == username.ToLower());
    }

    public override async Task<(int totalRegistros, IEnumerable<Usuario> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Usuarios as IQueryable<Usuario>;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.UsuarioPersona.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Roles)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
    public override async Task<Usuario> GetByIdAsync(int id)
    {
        return await _context.Set<Usuario>()
                .Include(p => p.Roles)
                .FirstOrDefaultAsync(p => p.Id == id);
    }
 
    
}
