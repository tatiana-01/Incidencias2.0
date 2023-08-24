using ApiIncidencias.Dtos.Usuario;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class UsuarioController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioDTO>> Post(UsuarioPostDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            _unitOfWork.Usuarios.Add(usuario);
            await _unitOfWork.SaveAsync();
            if (usuario == null) return BadRequest();
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<UsuarioDTO>>> Get([FromQuery] Params param)
        {
            var usuarios = await _unitOfWork.Usuarios.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstUsuarios = _mapper.Map<List<UsuarioDTO>>(usuarios.registros);
            return new Pager<UsuarioDTO>(lstUsuarios, usuarios.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioDTO>> Put(int id, [FromBody] UsuarioPostDTO usuarioEdit)
        {
            if (usuarioEdit == null) return NotFound();
            var usuario = _mapper.Map<Usuario>(usuarioEdit);
            usuario.Id = id;
            _unitOfWork.Usuarios.Update(usuario);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        [HttpDelete("{id}")]
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
    }
}