using ApiIncidencias.Dtos;
using ApiIncidencias.Dtos.IncidenciaPuesto;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class IncidenciaPuestoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IncidenciaPuestoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Authorize(Roles="Administrador, Trainer, Camper")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IncidenciaPuestoDTO>> Post(IncidenciaPuestoDTO entidadDTO)
        {
            var entidad = _mapper.Map<IncidenciaPuesto>(entidadDTO);
            _unitOfWork.IncidenciaPuestos.Add(entidad);
            await _unitOfWork.SaveAsync();
            if (entidad == null) return BadRequest();
            return _mapper.Map<IncidenciaPuestoDTO>(entidad);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<IncidenciaPuestoDTO>>> Get([FromQuery] Params param)
        {
            var entidads = await _unitOfWork.IncidenciaPuestos.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstIncidenciaPuestos = _mapper.Map<List<IncidenciaPuestoDTO>>(entidads.registros);
            return new Pager<IncidenciaPuestoDTO>(lstIncidenciaPuestos, entidads.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{idIncidencia}/{idPuesto}/{idComponente}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IncidenciaPuestoDTO>> Get(int IdIncidencia, int IdPuesto, int IdComponente)
        {
            var entidad = await _unitOfWork.IncidenciaPuestos.GetByIdAsync(IdIncidencia,IdPuesto,IdComponente);
            return _mapper.Map<IncidenciaPuestoDTO>(entidad);
        }

        [HttpPut("{idIncidencia}/{idPuesto}/{idComponente}")]
        [Authorize(Roles="Administrador, Trainer, Camper")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IncidenciaPuestoDTO>> Put(int IdIncidencia, int IdPuesto, int IdComponente, [FromBody] IncidenciaPuestoPutDTO entidadEdit)
        {
            if (entidadEdit == null) return NotFound();
            var entidad = _mapper.Map<IncidenciaPuesto>(entidadEdit);
            entidad.IdIncidencia = IdIncidencia;
            entidad.IdPuesto = IdPuesto;
            entidad.IdComponente = IdComponente;
            _unitOfWork.IncidenciaPuestos.Update(entidad);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<IncidenciaPuestoDTO>(entidad);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles="Administrador, Trainer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int IdIncidencia, int IdPuesto, int IdComponente)
        {
            var entidad = await _unitOfWork.IncidenciaPuestos.GetByIdAsync(IdIncidencia,IdPuesto,IdComponente);
            if (entidad == null) BadRequest();
            _unitOfWork.IncidenciaPuestos.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}