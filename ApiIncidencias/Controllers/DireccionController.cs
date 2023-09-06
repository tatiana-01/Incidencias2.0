using ApiIncidencias.Dtos.Direccion;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class DireccionController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DireccionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Authorize(Roles="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DireccionDTO>> Post(DireccionPostDTO direccionDTO)
        {
            var direccion = _mapper.Map<Direccion>(direccionDTO);
            _unitOfWork.Direcciones.Add(direccion);
            await _unitOfWork.SaveAsync();
            if (direccion == null) return BadRequest();
            return _mapper.Map<DireccionDTO>(direccion);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<DireccionGetAllDTO>>> Get([FromQuery] Params param)
        {
            var direccions = await _unitOfWork.Direcciones.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstDireccions = _mapper.Map<List<DireccionGetAllDTO>>(direccions.registros);
            return new Pager<DireccionGetAllDTO>(lstDireccions, direccions.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DireccionGetAllDTO>> Get(int id)
        {
            var direccion = await _unitOfWork.Direcciones.GetByIdAsync(id);
            return _mapper.Map<DireccionGetAllDTO>(direccion);
        }

        [HttpPut("{id}")]
        [Authorize(Roles="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DireccionDTO>> Put(int id, [FromBody] DireccionPostDTO direccionEdit)
        {
            if (direccionEdit == null) return NotFound();
            var direccion = _mapper.Map<Direccion>(direccionEdit);
            direccion.Id = id;
            _unitOfWork.Direcciones.Update(direccion);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<DireccionDTO>(direccion);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var direccion = await _unitOfWork.Direcciones.GetByIdAsync(id);
            if (direccion == null) BadRequest();
            _unitOfWork.Direcciones.Remove(direccion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}