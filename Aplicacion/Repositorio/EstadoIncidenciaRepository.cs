using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio;
    public class EstadoIncidenciaRepository: GenericRepositoryInt<EstadoIncidencia>, IEstadoIncidencia
    {
        private readonly IncidenciasContext _context;
        
        public EstadoIncidenciaRepository(IncidenciasContext context): base (context)
        {
            _context = context;
        }
    }