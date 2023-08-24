using ApiIncidencias.Dtos.Incidencia;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class IncidenciaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IncidenciaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IncidenciaDTO>> Post(IncidenciaPostDTO incidenciaDTO)
        {
            var incidencia = _mapper.Map<Incidencia>(incidenciaDTO);
            _unitOfWork.Incidencias.Add(incidencia);
            await _unitOfWork.SaveAsync();
            if (incidencia == null) return BadRequest();
            return _mapper.Map<IncidenciaDTO>(incidencia);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<IncidenciaGetAllDTO>>> Get([FromQuery] Params param)
        {
            var incidencias = await _unitOfWork.Incidencias.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstIncidencias = _mapper.Map<List<IncidenciaGetAllDTO>>(incidencias.registros);
            return new Pager<IncidenciaGetAllDTO>(lstIncidencias, incidencias.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IncidenciaGetAllDTO>> Get(int id)
        {
            var incidencia = await _unitOfWork.Incidencias.GetByIdAsync(id);
            return _mapper.Map<IncidenciaGetAllDTO>(incidencia);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IncidenciaDTO>> Put(int id, [FromBody] IncidenciaPostDTO incidenciaEdit)
        {
            if (incidenciaEdit == null) return NotFound();
            var incidencia = _mapper.Map<Incidencia>(incidenciaEdit);
            incidencia.Id = id;
            _unitOfWork.Incidencias.Update(incidencia);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<IncidenciaDTO>(incidencia);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var incidencia = await _unitOfWork.Incidencias.GetByIdAsync(id);
            if (incidencia == null) BadRequest();
            _unitOfWork.Incidencias.Remove(incidencia);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}