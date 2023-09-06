using ApiIncidencias.Dtos.Verificacion;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class VerificacionController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VerificacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Authorize(Roles ="Administrador, Trainer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VerificacionDTO>> Post(VerificacionPostDTO verificacionDTO)
        {
            var verificacion = _mapper.Map<Verificacion>(verificacionDTO);
            _unitOfWork.Verificaciones.Add(verificacion);
            await _unitOfWork.SaveAsync();
            if (verificacion == null) return BadRequest();
            return _mapper.Map<VerificacionDTO>(verificacion);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<VerificacionDTO>>> Get([FromQuery] Params param)
        {
            var verificaciones = await _unitOfWork.Verificaciones.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstVerificaciones = _mapper.Map<List<VerificacionDTO>>(verificaciones.registros);
            return new Pager<VerificacionDTO>(lstVerificaciones, verificaciones.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VerificacionDTO>> Get(int id)
        {
            var verificacion = await _unitOfWork.Verificaciones.GetByIdAsync(id);
            return _mapper.Map<VerificacionDTO>(verificacion);
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="Administrador, Trainer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VerificacionDTO>> Put(int id, [FromBody] VerificacionPostDTO verificacionEdit)
        {
            if (verificacionEdit == null) return NotFound();
            var verificacion = _mapper.Map<Verificacion>(verificacionEdit);
            verificacion.Id = id;
            _unitOfWork.Verificaciones.Update(verificacion);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<VerificacionDTO>(verificacion);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Administrador,Trainer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var verificacion = await _unitOfWork.Verificaciones.GetByIdAsync(id);
            if (verificacion == null) BadRequest();
            _unitOfWork.Verificaciones.Remove(verificacion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}