using ApiIncidencias.Dtos.Persona;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class PersonaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("agregar")]
        [ApiVersion("1.0")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDTO>> Post(PersonaDTO personaDTO)
        {
            var persona = _mapper.Map<Persona>(personaDTO);
            _unitOfWork.Personas.Add(persona);
            await _unitOfWork.SaveAsync();
            if (persona == null) return BadRequest();
            return _mapper.Map<PersonaDTO>(persona);
        }

        [HttpGet("todos")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PersonaGetAllDTO>>> Get([FromQuery] Params param)
        {
            var personas = await _unitOfWork.Personas.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstPersonas = _mapper.Map<List<PersonaGetAllDTO>>(personas.registros);
            return new Pager<PersonaGetAllDTO>(lstPersonas, personas.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaGetAllDTO>> Get(string id)
        {
            var persona = await _unitOfWork.Personas.GetByIdAsync(id);
            return _mapper.Map<PersonaGetAllDTO>(persona);
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDTO>> Put(string id, [FromBody] PersonaDTO personaEdit)
        {
            if (personaEdit == null) return NotFound();
            var persona = _mapper.Map<Persona>(personaEdit);
            persona.Id = id;
            _unitOfWork.Personas.Update(persona);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PersonaDTO>(persona);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(string id)
        {
            var persona = await _unitOfWork.Personas.GetByIdAsync(id);
            if (persona == null) BadRequest();
            _unitOfWork.Personas.Remove(persona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}