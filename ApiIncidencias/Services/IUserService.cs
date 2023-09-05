using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos;
using ApiIncidencias.Dtos.Usuario;

namespace ApiIncidencias.Services;
    public interface IUserService
    {
        Task<string> ResgisterAsync(UsuarioPostDTO usuarioPostDTO);
        Task<DatosUsuarioDTO> GetTokenAsync (LoginDTO model);
        Task<string> addRoleAsync(AddRoleDTO model);
    }
