using ApiIncidencias.Dtos.TipoComponente;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class TipoComponenteController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoComponenteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoComponenteDTO>> Post(TipoComponentePostDTO tipoComponenteDTO)
        {
            var tipoComponente = _mapper.Map<TipoComponente>(tipoComponenteDTO);
            _unitOfWork.TipoComponentes.Add(tipoComponente);
            await _unitOfWork.SaveAsync();
            if (tipoComponente == null) return BadRequest();
            return _mapper.Map<TipoComponenteDTO>(tipoComponente);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<TipoComponenteGetAllDTO>>> Get([FromQuery] Params param)
        {
            var tipoComponentes = await _unitOfWork.TipoComponentes.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstTipoComponentes = _mapper.Map<List<TipoComponenteGetAllDTO>>(tipoComponentes.registros);
            return new Pager<TipoComponenteGetAllDTO>(lstTipoComponentes, tipoComponentes.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoComponenteGetAllDTO>> Get(int id)
        {
            var tipoComponente = await _unitOfWork.TipoComponentes.GetByIdAsync(id);
            return _mapper.Map<TipoComponenteGetAllDTO>(tipoComponente);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoComponenteDTO>> Put(int id, [FromBody] TipoComponentePostDTO tipoComponenteEdit)
        {
            if (tipoComponenteEdit == null) return NotFound();
            var tipoComponente = _mapper.Map<TipoComponente>(tipoComponenteEdit);
            tipoComponente.Id = id;
            _unitOfWork.TipoComponentes.Update(tipoComponente);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TipoComponenteDTO>(tipoComponente);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var tipoComponente = await _unitOfWork.TipoComponentes.GetByIdAsync(id);
            if (tipoComponente == null) BadRequest();
            _unitOfWork.TipoComponentes.Remove(tipoComponente);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}