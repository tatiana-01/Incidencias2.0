using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class ComponenteRepository : GenericRepositoryInt<Componente>, IComponente
    {
        private readonly IncidenciasContext _context;
        
        public ComponenteRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }
    }
}