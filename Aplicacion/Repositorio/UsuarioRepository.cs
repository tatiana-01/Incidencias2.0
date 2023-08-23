using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class UsuarioRepository : GenericRepositoryInt<Usuario>, IUsuario
    {
        private readonly IncidenciasContext _context;
        
        public UsuarioRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }
    }
}