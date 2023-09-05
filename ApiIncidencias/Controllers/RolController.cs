using ApiIncidencias.Dtos.Rol;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class RolController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RolController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("agregar")]
        [ApiVersion("1.0")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolDTO>> Post(RolPostDTO rolDTO)
        {
            var rol = _mapper.Map<Rol>(rolDTO);
            _unitOfWork.Roles.Add(rol);
            await _unitOfWork.SaveAsync();
            if (rol == null) return BadRequest();
            return _mapper.Map<RolDTO>(rol);
        }

        [HttpGet("todos")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<RolGetAllDTO>>> Get([FromQuery] Params param)
        {
            var roles = await _unitOfWork.Roles.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstRoles = _mapper.Map<List<RolGetAllDTO>>(roles.registros);
            return new Pager<RolGetAllDTO>(lstRoles, roles.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolGetAllDTO>> Get(int id)
        {
            var rol = await _unitOfWork.Roles.GetByIdAsync(id);
            return _mapper.Map<RolGetAllDTO>(rol);
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolDTO>> Put(int id, [FromBody] RolPostDTO rolEdit)
        {
            if (rolEdit == null) return NotFound();
            var rol = _mapper.Map<Rol>(rolEdit);
            rol.Id = id;
            _unitOfWork.Roles.Update(rol);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<RolDTO>(rol);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var rol = await _unitOfWork.Roles.GetByIdAsync(id);
            if (rol == null) BadRequest();
            _unitOfWork.Roles.Remove(rol);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}