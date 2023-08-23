using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class IncidenciaRepository : GenericRepositoryInt<Incidencia>, IIncidencia
    {
        private readonly IncidenciasContext _context;
        
        public IncidenciaRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }
    }
}