using ApiIncidencias.Dtos.EstadoVerificacion;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class EstadoVerificacionController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EstadoVerificacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Authorize(Roles="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoVerificacionDTO>> Post(EstadoVerificacionPostDTO estadoVerificacionDTO)
        {
            var estadoVerificacion = _mapper.Map<EstadoVerificacion>(estadoVerificacionDTO);
            _unitOfWork.EstadoVerificaciones.Add(estadoVerificacion);
            await _unitOfWork.SaveAsync();
            if (estadoVerificacion == null) return BadRequest();
            return _mapper.Map<EstadoVerificacionDTO>(estadoVerificacion);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EstadoVerificacionGetAllDTO>>> Get([FromQuery] Params param)
        {
            var estadoVerificacions = await _unitOfWork.EstadoVerificaciones.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstEstadoVerificacions = _mapper.Map<List<EstadoVerificacionGetAllDTO>>(estadoVerificacions.registros);
            return new Pager<EstadoVerificacionGetAllDTO>(lstEstadoVerificacions, estadoVerificacions.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoVerificacionGetAllDTO>> Get(int id)
        {
            var estadoVerificacion = await _unitOfWork.EstadoVerificaciones.GetByIdAsync(id);
            return _mapper.Map<EstadoVerificacionGetAllDTO>(estadoVerificacion);
        }

        [HttpPut("{id}")]
        [Authorize(Roles="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoVerificacionDTO>> Put(int id, [FromBody] EstadoVerificacionPostDTO estadoVerificacionEdit)
        {
            if (estadoVerificacionEdit == null) return NotFound();
            var estadoVerificacion = _mapper.Map<EstadoVerificacion>(estadoVerificacionEdit);
            estadoVerificacion.Id = id;
            _unitOfWork.EstadoVerificaciones.Update(estadoVerificacion);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<EstadoVerificacionDTO>(estadoVerificacion);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var estadoVerificacion = await _unitOfWork.EstadoVerificaciones.GetByIdAsync(id);
            if (estadoVerificacion == null) BadRequest();
            _unitOfWork.EstadoVerificaciones.Remove(estadoVerificacion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}