using ApiIncidencias.Dtos.EPS;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class EPSController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EPSController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("agregar")]
        [ApiVersion("1.0")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EPSDTO>> Post(EPSPostDTO epsDTO)
        {
            var eps = _mapper.Map<EPS>(epsDTO);
            _unitOfWork.EPSs.Add(eps);
            await _unitOfWork.SaveAsync();
            if (eps == null) return BadRequest();
            return _mapper.Map<EPSDTO>(eps);
        }

        [HttpGet("todos")]
        [Authorize(Roles ="Administrador,Persona")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EPSGetAllDTO>>> Get([FromQuery] Params param)
        {
            var epss = await _unitOfWork.EPSs.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstEPSs = _mapper.Map<List<EPSGetAllDTO>>(epss.registros);
            return new Pager<EPSGetAllDTO>(lstEPSs, epss.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [Authorize(Roles ="Administrador,Persona")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EPSGetAllDTO>> Get(int id)
        {
            var eps = await _unitOfWork.EPSs.GetByIdAsync(id);
            return _mapper.Map<EPSGetAllDTO>(eps);
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EPSDTO>> Put(int id, [FromBody] EPSPostDTO epsEdit)
        {
            if (epsEdit == null) return NotFound();
            var eps = _mapper.Map<EPS>(epsEdit);
            eps.Id = id;
            _unitOfWork.EPSs.Update(eps);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<EPSDTO>(eps);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var eps = await _unitOfWork.EPSs.GetByIdAsync(id);
            if (eps == null) BadRequest();
            _unitOfWork.EPSs.Remove(eps);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}