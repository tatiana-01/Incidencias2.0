using ApiIncidencias.Dtos;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class PersonaContactoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonaContactoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaContactoDTO>> Post(PersonaContactoDTO entidadDTO)
        {
            var entidad = _mapper.Map<PersonaContacto>(entidadDTO);
            _unitOfWork.PersonaContactos.Add(entidad);
            await _unitOfWork.SaveAsync();
            if (entidad == null) return BadRequest();
            return _mapper.Map<PersonaContactoDTO>(entidad);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PersonaContactoDTO>>> Get([FromQuery] Params param)
        {
            var entidads = await _unitOfWork.PersonaContactos.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstPersonaContactos = _mapper.Map<List<PersonaContactoDTO>>(entidads.registros);
            return new Pager<PersonaContactoDTO>(lstPersonaContactos, entidads.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{idPersona}/{idContacto}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaContactoDTO>> Get(string idPersona, int idContacto)
        {
            var entidad = await _unitOfWork.PersonaContactos.GetByIdAsync(idPersona,idContacto);
            return _mapper.Map<PersonaContactoDTO>(entidad);
        }

        // [HttpPut("{id}")]
        // [ProducesResponseType(StatusCodes.Status201Created)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<ActionResult<PersonaContactoDTO>> Put(int id, [FromBody] PersonaContactoPostDTO entidadEdit)
        // {
        //     if (entidadEdit == null) return NotFound();
        //     var entidad = _mapper.Map<PersonaContacto>(entidadEdit);
        //     entidad.Id = id;
        //     _unitOfWork.PersonaContactos.Update(entidad);
        //     await _unitOfWork.SaveAsync();
        //     return _mapper.Map<PersonaContactoDTO>(entidad);
        // }

        [HttpDelete("{idPersona}/{idContacto}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(string idPersona, int idContacto)
        {
            var entidad = await _unitOfWork.PersonaContactos.GetByIdAsync(idPersona,idContacto);
            if (entidad == null) BadRequest();
            _unitOfWork.PersonaContactos.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}