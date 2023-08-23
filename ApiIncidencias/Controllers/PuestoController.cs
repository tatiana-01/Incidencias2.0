using ApiIncidencias.Dtos.Puesto;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class PuestoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PuestoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PuestoDTO>> Post(PuestoPostDTO puestoDTO)
        {
            var puesto = _mapper.Map<Puesto>(puestoDTO);
            _unitOfWork.Puestos.Add(puesto);
            await _unitOfWork.SaveAsync();
            if (puesto == null) return BadRequest();
            return _mapper.Map<PuestoDTO>(puesto);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PuestoGetAllDTO>>> Get([FromQuery] Params param)
        {
            var puestoes = await _unitOfWork.Puestos.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstPuestoes = _mapper.Map<List<PuestoGetAllDTO>>(puestoes.registros);
            return new Pager<PuestoGetAllDTO>(lstPuestoes, puestoes.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PuestoGetAllDTO>> Get(int id)
        {
            var puesto = await _unitOfWork.Puestos.GetByIdAsync(id);
            return _mapper.Map<PuestoGetAllDTO>(puesto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PuestoDTO>> Put(int id, [FromBody] PuestoPostDTO puestoEdit)
        {
            if (puestoEdit == null) return NotFound();
            var puesto = _mapper.Map<Puesto>(puestoEdit);
            puesto.Id = id;
            _unitOfWork.Puestos.Update(puesto);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PuestoDTO>(puesto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var puesto = await _unitOfWork.Puestos.GetByIdAsync(id);
            if (puesto == null) BadRequest();
            _unitOfWork.Puestos.Remove(puesto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}