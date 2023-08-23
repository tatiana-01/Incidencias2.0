using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class TipoIncidenciaRepository : GenericRepositoryInt<TipoIncidencia>, ITipoIncidencia
    {
        private readonly IncidenciasContext _context;
        
        public TipoIncidenciaRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }
    }
}