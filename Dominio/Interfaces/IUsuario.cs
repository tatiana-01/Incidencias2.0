using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Interfaces;
    public interface IUsuario:IGenericRepositoryInt<Usuario>
    {
        Task<Usuario> GetByUsernameAsync(string username);
    }
