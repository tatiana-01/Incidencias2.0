using ApiIncidencias.Dtos.Genero;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class GeneroController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GeneroController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("agregar")]
        [ApiVersion("1.0")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GeneroDTO>> Post(GeneroPostDTO generoDTO)
        {
            var genero = _mapper.Map<Genero>(generoDTO);
            _unitOfWork.Generos.Add(genero);
            await _unitOfWork.SaveAsync();
            if (genero == null) return BadRequest();
            return _mapper.Map<GeneroDTO>(genero);
        }

        [HttpGet("todos")]
        [Authorize(Roles ="Administrador,Persona")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<GeneroGetAllDTO>>> Get([FromQuery] Params param)
        {
            var generos = await _unitOfWork.Generos.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstGeneros = _mapper.Map<List<GeneroGetAllDTO>>(generos.registros);
            return new Pager<GeneroGetAllDTO>(lstGeneros, generos.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [Authorize(Roles ="Administrador,Persona")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GeneroGetAllDTO>> Get(int id)
        {
            var genero = await _unitOfWork.Generos.GetByIdAsync(id);
            return _mapper.Map<GeneroGetAllDTO>(genero);
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GeneroDTO>> Put(int id, [FromBody] GeneroPostDTO generoEdit)
        {
            if (generoEdit == null) return NotFound();
            var genero = _mapper.Map<Genero>(generoEdit);
            genero.Id = id;
            _unitOfWork.Generos.Update(genero);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<GeneroDTO>(genero);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var genero = await _unitOfWork.Generos.GetByIdAsync(id);
            if (genero == null) BadRequest();
            _unitOfWork.Generos.Remove(genero);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}