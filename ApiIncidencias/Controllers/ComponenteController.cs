using ApiIncidencias.Dtos.Componente;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class ComponenteController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ComponenteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ComponenteDTO>> Post(ComponentePostDTO componenteDTO)
        {
            var componente = _mapper.Map<Componente>(componenteDTO);
            _unitOfWork.Componentes.Add(componente);
            await _unitOfWork.SaveAsync();
            if (componente == null) return BadRequest();
            return _mapper.Map<ComponenteDTO>(componente);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ComponenteGetAllDTO>>> Get([FromQuery] Params param)
        {
            var componentes = await _unitOfWork.Componentes.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstComponentes = _mapper.Map<List<ComponenteGetAllDTO>>(componentes.registros);
            return new Pager<ComponenteGetAllDTO>(lstComponentes, componentes.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ComponenteGetAllDTO>> Get(int id)
        {
            var componente = await _unitOfWork.Componentes.GetByIdAsync(id);
            return _mapper.Map<ComponenteGetAllDTO>(componente);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ComponenteDTO>> Put(int id, [FromBody] ComponentePostDTO componenteEdit)
        {
            if (componenteEdit == null) return NotFound();
            var componente = _mapper.Map<Componente>(componenteEdit);
            componente.Id = id;
            _unitOfWork.Componentes.Update(componente);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ComponenteDTO>(componente);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var componente = await _unitOfWork.Componentes.GetByIdAsync(id);
            if (componente == null) BadRequest();
            _unitOfWork.Componentes.Remove(componente);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}