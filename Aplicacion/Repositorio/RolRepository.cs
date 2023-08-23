using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class RolRepository : GenericRepositoryInt<Rol>, IRol
    {
        private readonly IncidenciasContext _context;
        
        public RolRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }
    }
}