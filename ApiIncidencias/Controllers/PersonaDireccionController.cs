using ApiIncidencias.Dtos;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class PersonaDireccionController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonaDireccionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDireccionDTO>> Post(PersonaDireccionDTO personaDireccionDTO)
        {
            var personaDireccion = _mapper.Map<PersonaDireccion>(personaDireccionDTO);
            _unitOfWork.PersonaDirecciones.Add(personaDireccion);
            await _unitOfWork.SaveAsync();
            if (personaDireccion == null) return BadRequest();
            return _mapper.Map<PersonaDireccionDTO>(personaDireccion);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PersonaDireccionDTO>>> Get([FromQuery] Params param)
        {
            var personaDireccions = await _unitOfWork.PersonaDirecciones.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstPersonaDirecciones = _mapper.Map<List<PersonaDireccionDTO>>(personaDireccions.registros);
            return new Pager<PersonaDireccionDTO>(lstPersonaDirecciones, personaDireccions.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{idPersona}/{idDireccion}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDireccionDTO>> Get(string idPersona, int idDireccion)
        {
            var personaDireccion = await _unitOfWork.PersonaDirecciones.GetByIdAsync(idPersona,idDireccion);
            return _mapper.Map<PersonaDireccionDTO>(personaDireccion);
        }

        // [HttpPut("{id}")]
        // [ProducesResponseType(StatusCodes.Status201Created)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<ActionResult<PersonaDireccionDTO>> Put(int id, [FromBody] PersonaDireccionDTO personaDireccionEdit)
        // {
        //     if (personaDireccionEdit == null) return NotFound();
        //     var personaDireccion = _mapper.Map<PersonaDireccion>(personaDireccionEdit);
        //     personaDireccion.Id = id;
        //     _unitOfWork.PersonaDirecciones.Update(personaDireccion);
        //     await _unitOfWork.SaveAsync();
        //     return _mapper.Map<PersonaDireccionDTO>(personaDireccion);
        // }

        [HttpDelete("{idPersona}/{idDireccion}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(string idPersona, int idDireccion)
        {
            var personaDireccion = await _unitOfWork.PersonaDirecciones.GetByIdAsync(idPersona,idDireccion);
            if (personaDireccion == null) BadRequest();
            _unitOfWork.PersonaDirecciones.Remove(personaDireccion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}