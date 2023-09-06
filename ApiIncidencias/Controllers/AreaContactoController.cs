using ApiIncidencias.Dtos.AreaContacto;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class AreaContactoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AreaContactoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Authorize(Roles="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AreaContactoDTO>> Post(AreaContactoPostDTO areaContactoDTO)
        {
            var areaContacto = _mapper.Map<AreaContacto>(areaContactoDTO);
            _unitOfWork.AreaContactos.Add(areaContacto);
            await _unitOfWork.SaveAsync();
            if (areaContacto == null) return BadRequest();
            return _mapper.Map<AreaContactoDTO>(areaContacto);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<AreaContactoGetAllDTO>>> Get([FromQuery] Params param)
        {
            var areaContactos = await _unitOfWork.AreaContactos.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstAreaContactos = _mapper.Map<List<AreaContactoGetAllDTO>>(areaContactos.registros);
            return new Pager<AreaContactoGetAllDTO>(lstAreaContactos, areaContactos.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AreaContactoGetAllDTO>> Get(int id)
        {
            var areaContacto = await _unitOfWork.AreaContactos.GetByIdAsync(id);
            return _mapper.Map<AreaContactoGetAllDTO>(areaContacto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AreaContactoDTO>> Put(int id, [FromBody] AreaContactoPostDTO areaContactoEdit)
        {
            if (areaContactoEdit == null) return NotFound();
            var areaContacto = _mapper.Map<AreaContacto>(areaContactoEdit);
            areaContacto.Id = id;
            _unitOfWork.AreaContactos.Update(areaContacto);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<AreaContactoDTO>(areaContacto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var areaContacto = await _unitOfWork.AreaContactos.GetByIdAsync(id);
            if (areaContacto == null) BadRequest();
            _unitOfWork.AreaContactos.Remove(areaContacto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}