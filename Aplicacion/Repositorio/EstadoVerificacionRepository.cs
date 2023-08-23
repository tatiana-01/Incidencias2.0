using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class EstadoVerificacionRepository : GenericRepositoryInt<EstadoVerificacion>, IEstadoVerificacion
    {
        private readonly IncidenciasContext _context;
        
        public EstadoVerificacionRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }
    }
}