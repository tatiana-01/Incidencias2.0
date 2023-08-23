using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio
{
    public class TipoContactoRepository : GenericRepositoryInt<TipoContacto>, ITipoContacto
    {
        private readonly IncidenciasContext _context;
        
        public TipoContactoRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }
    }
}