using ApiIncidencias.Dtos.Contacto;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class ContactoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoDTO>> Post(ContactoPostDTO contactoDTO)
        {
            var contacto = _mapper.Map<Contacto>(contactoDTO);
            _unitOfWork.Contactos.Add(contacto);
            await _unitOfWork.SaveAsync();
            if (contacto == null) return BadRequest();
            return _mapper.Map<ContactoDTO>(contacto);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ContactoGetAllDTO>>> Get([FromQuery] Params param)
        {
            var contactos = await _unitOfWork.Contactos.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstContactos = _mapper.Map<List<ContactoGetAllDTO>>(contactos.registros);
            return new Pager<ContactoGetAllDTO>(lstContactos, contactos.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoGetAllDTO>> Get(int id)
        {
            var contacto = await _unitOfWork.Contactos.GetByIdAsync(id);
            return _mapper.Map<ContactoGetAllDTO>(contacto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoDTO>> Put(int id, [FromBody] ContactoPostDTO contactoEdit)
        {
            if (contactoEdit == null) return NotFound();
            var contacto = _mapper.Map<Contacto>(contactoEdit);
            contacto.Id = id;
            _unitOfWork.Contactos.Update(contacto);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ContactoDTO>(contacto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var contacto = await _unitOfWork.Contactos.GetByIdAsync(id);
            if (contacto == null) BadRequest();
            _unitOfWork.Contactos.Remove(contacto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}