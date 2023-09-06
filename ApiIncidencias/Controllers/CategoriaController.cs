using ApiIncidencias.Dtos.Categoria;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class CategoriaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Authorize(Roles="Administrador, Trainer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaDTO>> Post(CategoriaPostDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            _unitOfWork.Categorias.Add(categoria);
            await _unitOfWork.SaveAsync();
            if (categoria == null) return BadRequest();
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<CategoriaGetAllDTO>>> Get([FromQuery] Params param)
        {
            var categorias = await _unitOfWork.Categorias.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstCategorias = _mapper.Map<List<CategoriaGetAllDTO>>(categorias.registros);
            return new Pager<CategoriaGetAllDTO>(lstCategorias, categorias.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaGetAllDTO>> Get(int id)
        {
            var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
            return _mapper.Map<CategoriaGetAllDTO>(categoria);
        }

        [HttpPut("{id}")]
        [Authorize(Roles="Administrador, Trainer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaDTO>> Put(int id, [FromBody] CategoriaPostDTO categoriaEdit)
        {
            if (categoriaEdit == null) return NotFound();
            var categoria = _mapper.Map<Categoria>(categoriaEdit);
            categoria.Id = id;
            _unitOfWork.Categorias.Update(categoria);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles="Administrador, Trainer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
            if (categoria == null) BadRequest();
            _unitOfWork.Categorias.Remove(categoria);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}