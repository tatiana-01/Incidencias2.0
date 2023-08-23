using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class TipoComponenteRepository : GenericRepositoryInt<TipoComponente>, ITipoComponente
    {
        private readonly IncidenciasContext _context;
        
        public TipoComponenteRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }
    }
}