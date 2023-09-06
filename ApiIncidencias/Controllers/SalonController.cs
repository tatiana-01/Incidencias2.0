using ApiIncidencias.Dtos.Salon;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers;
    [ApiVersion("1.0")]
    public class SalonController : BaseApiController
    {
       private readonly IUnitOfWork _unitOfWork;
       private readonly IMapper _mapper;

       public SalonController(IUnitOfWork unitOfWork, IMapper mapper){
        this._unitOfWork = unitOfWork;
        _mapper=mapper;
       }

        [HttpPost]
        [ApiVersion("1.0")]
        [Authorize(Roles ="Administrador, Trainer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SalonDTO>> Post(SalonPostDTO salonDTO){
            var salon = _mapper.Map<Salon>(salonDTO);
            _unitOfWork.Salones.Add(salon);
            await _unitOfWork.SaveAsync();
            if(salon==null) return BadRequest();
            return _mapper.Map<SalonDTO>(salon);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<SalonGetAllDTO>>> Get([FromQuery]Params param){
            var salones= await _unitOfWork.Salones.GetAllAsync(param.PageIndex,param.PageSize,param.Search);
            var lstSalones= _mapper.Map<List<SalonGetAllDTO>>(salones.registros);
            return new Pager<SalonGetAllDTO>(lstSalones, salones.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SalonGetAllDTO>> Get( int id){
            var salon = await _unitOfWork.Salones.GetByIdAsync(id);
            return _mapper.Map<SalonGetAllDTO>(salon);
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="Administrador, Trainer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SalonDTO>> Put(int id, [FromBody] SalonPostDTO salonEdit){
            if(salonEdit == null) return NotFound();
            var salon= _mapper.Map<Salon>(salonEdit);
            salon.Id=id;
            _unitOfWork.Salones.Update(salon);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<SalonDTO>(salon);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Administrador, Trainer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id){
            var salon= await _unitOfWork.Salones.GetByIdAsync(id);
            if(salon==null) BadRequest();
            _unitOfWork.Salones.Remove(salon);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
