using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class GeneroRepository : GenericRepositoryInt<Genero>, IGenero
    {
        private readonly IncidenciasContext _context;
        
        public GeneroRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }
    }
}