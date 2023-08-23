using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class VerificacionRepository : GenericRepositoryInt<Verificacion>, IVerificacion
    {
        private readonly IncidenciasContext _context;
        
        public VerificacionRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }
    }
}