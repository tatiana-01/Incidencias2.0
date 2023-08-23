using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class PaisRepository : GenericRepositoryInt<Pais>, IPais
    {
        private readonly IncidenciasContext _context;
        
        public PaisRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }
    }
}