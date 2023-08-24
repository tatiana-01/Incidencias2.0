using ApiIncidencias.Dtos.TipoIncidencia;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class TipoIncidenciaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoIncidenciaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoIncidenciaDTO>> Post(TipoIncidenciaPostDTO tipoIncidenciaDTO)
        {
            var tipoIncidencia = _mapper.Map<TipoIncidencia>(tipoIncidenciaDTO);
            _unitOfWork.TipoIncidencias.Add(tipoIncidencia);
            await _unitOfWork.SaveAsync();
            if (tipoIncidencia == null) return BadRequest();
            return _mapper.Map<TipoIncidenciaDTO>(tipoIncidencia);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<TipoIncidenciaGetAllDTO>>> Get([FromQuery] Params param)
        {
            var tipoIncidencias = await _unitOfWork.TipoIncidencias.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstTipoIncidencias = _mapper.Map<List<TipoIncidenciaGetAllDTO>>(tipoIncidencias.registros);
            return new Pager<TipoIncidenciaGetAllDTO>(lstTipoIncidencias, tipoIncidencias.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoIncidenciaGetAllDTO>> Get(int id)
        {
            var tipoIncidencia = await _unitOfWork.TipoIncidencias.GetByIdAsync(id);
            return _mapper.Map<TipoIncidenciaGetAllDTO>(tipoIncidencia);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoIncidenciaDTO>> Put(int id, [FromBody] TipoIncidenciaPostDTO tipoIncidenciaEdit)
        {
            if (tipoIncidenciaEdit == null) return NotFound();
            var tipoIncidencia = _mapper.Map<TipoIncidencia>(tipoIncidenciaEdit);
            tipoIncidencia.Id = id;
            _unitOfWork.TipoIncidencias.Update(tipoIncidencia);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TipoIncidenciaDTO>(tipoIncidencia);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var tipoIncidencia = await _unitOfWork.TipoIncidencias.GetByIdAsync(id);
            if (tipoIncidencia == null) BadRequest();
            _unitOfWork.TipoIncidencias.Remove(tipoIncidencia);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}