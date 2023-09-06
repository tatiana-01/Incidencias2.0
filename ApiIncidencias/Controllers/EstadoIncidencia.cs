using ApiIncidencias.Dtos.EstadoIncidencia;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class EstadoIncidenciaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EstadoIncidenciaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Authorize(Roles="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoIncidenciaDTO>> Post(EstadoIncidenciaPostDTO estadoIncidenciaDTO)
        {
            var estadoIncidencia = _mapper.Map<EstadoIncidencia>(estadoIncidenciaDTO);
            _unitOfWork.EstadoIncidencias.Add(estadoIncidencia);
            await _unitOfWork.SaveAsync();
            if (estadoIncidencia == null) return BadRequest();
            return _mapper.Map<EstadoIncidenciaDTO>(estadoIncidencia);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EstadoIncidenciaGetAllDTO>>> Get([FromQuery] Params param)
        {
            var estadoIncidencias = await _unitOfWork.EstadoIncidencias.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstEstadoIncidencias = _mapper.Map<List<EstadoIncidenciaGetAllDTO>>(estadoIncidencias.registros);
            return new Pager<EstadoIncidenciaGetAllDTO>(lstEstadoIncidencias, estadoIncidencias.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoIncidenciaGetAllDTO>> Get(int id)
        {
            var estadoIncidencia = await _unitOfWork.EstadoIncidencias.GetByIdAsync(id);
            return _mapper.Map<EstadoIncidenciaGetAllDTO>(estadoIncidencia);
        }

        [HttpPut("{id}")]
        [Authorize(Roles="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoIncidenciaDTO>> Put(int id, [FromBody] EstadoIncidenciaPostDTO estadoIncidenciaEdit)
        {
            if (estadoIncidenciaEdit == null) return NotFound();
            var estadoIncidencia = _mapper.Map<EstadoIncidencia>(estadoIncidenciaEdit);
            estadoIncidencia.Id = id;
            _unitOfWork.EstadoIncidencias.Update(estadoIncidencia);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<EstadoIncidenciaDTO>(estadoIncidencia);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var estadoIncidencia = await _unitOfWork.EstadoIncidencias.GetByIdAsync(id);
            if (estadoIncidencia == null) BadRequest();
            _unitOfWork.EstadoIncidencias.Remove(estadoIncidencia);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}