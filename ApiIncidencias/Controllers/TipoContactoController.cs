using ApiIncidencias.Dtos.TipoContacto;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class TipoContactoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoContactoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoContactoDTO>> Post(TipoContactoPostDTO tipoContactoDTO)
        {
            var tipoContacto = _mapper.Map<TipoContacto>(tipoContactoDTO);
            _unitOfWork.TipoContactos.Add(tipoContacto);
            await _unitOfWork.SaveAsync();
            if (tipoContacto == null) return BadRequest();
            return _mapper.Map<TipoContactoDTO>(tipoContacto);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<TipoContactoGetAllDTO>>> Get([FromQuery] Params param)
        {
            var tipoContactos = await _unitOfWork.TipoContactos.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstTipoContactos = _mapper.Map<List<TipoContactoGetAllDTO>>(tipoContactos.registros);
            return new Pager<TipoContactoGetAllDTO>(lstTipoContactos, tipoContactos.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoContactoGetAllDTO>> Get(int id)
        {
            var tipoContacto = await _unitOfWork.TipoContactos.GetByIdAsync(id);
            return _mapper.Map<TipoContactoGetAllDTO>(tipoContacto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoContactoDTO>> Put(int id, [FromBody] TipoContactoPostDTO tipoContactoEdit)
        {
            if (tipoContactoEdit == null) return NotFound();
            var tipoContacto = _mapper.Map<TipoContacto>(tipoContactoEdit);
            tipoContacto.Id = id;
            _unitOfWork.TipoContactos.Update(tipoContacto);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TipoContactoDTO>(tipoContacto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var tipoContacto = await _unitOfWork.TipoContactos.GetByIdAsync(id);
            if (tipoContacto == null) BadRequest();
            _unitOfWork.TipoContactos.Remove(tipoContacto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}