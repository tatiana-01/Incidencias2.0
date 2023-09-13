using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repositorio;
public class UserRefreshTokenRepository : GenericRepositoryInt<UserRefreshToken>, IUserRefreshToken
{
    public UserRefreshTokenRepository(IncidenciasContext context) : base(context)
    {
    }
}
