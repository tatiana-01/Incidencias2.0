using ApiIncidencias.Dtos.ARL;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    [ApiVersion("1.0")]
    public class ARLController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ARLController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ARLDTO>> Post(ARLPostDTO arlDTO)
        {
            var arl = _mapper.Map<ARL>(arlDTO);
            _unitOfWork.ARLs.Add(arl);
            await _unitOfWork.SaveAsync();
            if (arl == null) return BadRequest();
            return _mapper.Map<ARLDTO>(arl);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ARLGetAllDTO>>> Get([FromQuery] Params param)
        {
            var arls = await _unitOfWork.ARLs.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstARLs = _mapper.Map<List<ARLGetAllDTO>>(arls.registros);
            return new Pager<ARLGetAllDTO>(lstARLs, arls.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ARLGetAllDTO>> Get(int id)
        {
            var arl = await _unitOfWork.ARLs.GetByIdAsync(id);
            return _mapper.Map<ARLGetAllDTO>(arl);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ARLDTO>> Put(int id, [FromBody] ARLPostDTO arlEdit)
        {
            if (arlEdit == null) return NotFound();
            var arl = _mapper.Map<ARL>(arlEdit);
            arl.Id = id;
            _unitOfWork.ARLs.Update(arl);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ARLDTO>(arl);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var arl = await _unitOfWork.ARLs.GetByIdAsync(id);
            if (arl == null) BadRequest();
            _unitOfWork.ARLs.Remove(arl);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}