using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos;
using ApiIncidencias.Dtos.Usuario;
using Dominio.Entidades;

namespace ApiIncidencias.Services;
    public interface IUserService
    {
        Task<string> ResgisterAsync(UsuarioPostDTO usuarioPostDTO);
        Task<DatosUsuarioDTO> GetTokenAsync (LoginDTO model);
        Task<string> addRoleAsync(AddRoleDTO model);
        void UpdateUser(Usuario entity);
    }
