using ApiIncidencias.Dtos;
using ApiIncidencias.Dtos.Usuario;
using ApiIncidencias.Helpers;
using ApiIncidencias.Services;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class UsuarioController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsuarioController(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService=userService;
        }

        [HttpPost("agregar")]
        [ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> Post(UsuarioPostDTO usuarioDTO)
        {
            var result = await _userService.ResgisterAsync(usuarioDTO);
            if (usuarioDTO == null) return BadRequest();
            return result;
        }

        [HttpGet("todos")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<UsuarioDTO>>> Get([FromQuery] Params param)
        {
            var usuarios = await _unitOfWork.Usuarios.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstUsuarios = _mapper.Map<List<UsuarioDTO>>(usuarios.registros);
            return new Pager<UsuarioDTO>(lstUsuarios, usuarios.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioDTO>> Put(int id, [FromBody] UsuarioPostDTO usuarioEdit)
        {
            if (usuarioEdit == null) return NotFound();
            var usuario = _mapper.Map<Usuario>(usuarioEdit);
            usuario.Id = id;
            _userService.UpdateUser(usuario);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
            if (usuario == null) BadRequest();
            _unitOfWork.Usuarios.Remove(usuario);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpPost("token")]
       public async Task<IActionResult> GetTokenAsync(LoginDTO model){
        var result = await _userService.GetTokenAsync(model);
        return Ok(result);
       }

    }
}