using ApiIncidencias.Dtos.Area;
using ApiIncidencias.Helpers;
using Aplicacion.Repositorio;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class AreaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AreaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize(Roles="Administrador, Trainer")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaDTO>> Post(AreaPostDTO areaDTO){
        var area = _mapper.Map<Area>(areaDTO);
        this._unitOfWork.Areas.Add(area);
        await _unitOfWork.SaveAsync();
        if(area == null) return BadRequest();
        return this._mapper.Map<AreaDTO>(area); 
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<AreaGetAllDTO>>> Get([FromQuery] Params areaParam)
    {
        var areas = await _unitOfWork.Areas.GetAllAsync(areaParam.PageIndex, areaParam.PageSize, areaParam.Search);
        var lstAreasDto = _mapper.Map<List<AreaGetAllDTO>>(areas.registros);
        return new Pager<AreaGetAllDTO>(lstAreasDto, areas.totalRegistros, areaParam.PageIndex, areaParam.PageSize, areaParam.Search);
    }

    [HttpGet("{id}")]
    [MapToApiVersion("1.1")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaGetAllDTO>> Get (int id){
        var area = await _unitOfWork.Areas.GetByIdAsync(id);
        if(area == null) return BadRequest();
        return this._mapper.Map<AreaGetAllDTO>(area);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Administrador, Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id){
        var area = await _unitOfWork.Areas.GetByIdAsync(id);
        if(area == null) return BadRequest();
        _unitOfWork.Areas.Remove(area);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Administrador, Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaDTO>> Put (int id, [FromBody] AreaPostDTO areaEdicion){
        if(areaEdicion == null) return NotFound();
        var area = _mapper.Map<Area>(areaEdicion);
        area.Id=id;
        _unitOfWork.Areas.Update(area);
        await _unitOfWork.SaveAsync();
        return this._mapper.Map<AreaDTO>(area);

    }
    
}


