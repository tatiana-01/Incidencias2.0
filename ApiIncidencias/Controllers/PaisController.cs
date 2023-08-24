using ApiIncidencias.Dtos.Pais;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class PaisController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaisDTO>> Post(PaisPostDTO paisDTO)
        {
            var pais = _mapper.Map<Pais>(paisDTO);
            _unitOfWork.Paises.Add(pais);
            await _unitOfWork.SaveAsync();
            if (pais == null) return BadRequest();
            return _mapper.Map<PaisDTO>(pais);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PaisGetAllDTO>>> Get([FromQuery] Params param)
        {
            var paiss = await _unitOfWork.Paises.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstPaiss = _mapper.Map<List<PaisGetAllDTO>>(paiss.registros);
            return new Pager<PaisGetAllDTO>(lstPaiss, paiss.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaisGetAllDTO>> Get(int id)
        {
            var pais = await _unitOfWork.Paises.GetByIdAsync(id);
            return _mapper.Map<PaisGetAllDTO>(pais);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaisDTO>> Put(int id, [FromBody] PaisPostDTO paisEdit)
        {
            if (paisEdit == null) return NotFound();
            var pais = _mapper.Map<Pais>(paisEdit);
            pais.Id = id;
            _unitOfWork.Paises.Update(pais);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PaisDTO>(pais);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var pais = await _unitOfWork.Paises.GetByIdAsync(id);
            if (pais == null) BadRequest();
            _unitOfWork.Paises.Remove(pais);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}