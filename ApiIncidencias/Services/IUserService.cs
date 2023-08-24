using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Services;
    public interface IUserService
    {
        Task<string> ResgisterAsync(RegisterDTO model);
        Task<DatosUsuarioDTO> GetTokenAsync (LoginDTO model);
        Task<string> addRoleAsync(AddRoleDTO model);
    }
