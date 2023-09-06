using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos;
using ApiIncidencias.Helpers;
using ApiIncidencias.Services;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers;
    public class UsuarioRolController : BaseApiController
    {
        private readonly IUserService _userService;
       private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
       public UsuarioRolController (IUserService userService,IMapper mapper, IUnitOfWork unitOfWork){
        _userService=userService;
        _unitOfWork=unitOfWork;
        _mapper = mapper;
       }
        [HttpPost("addrol")]
        [Authorize(Roles ="Administrador")]
        public async Task<IActionResult> AddRolAsync(AddRoleDTO model){
            var result= await _userService.addRoleAsync(model);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<UsuarioRolDTO>>> Get([FromQuery] Params param)
        {
            var personaDireccions = await _unitOfWork.UsuarioRoles.GetAllAsync(param.PageIndex, param.PageSize, param.Search);
            var lstUsuarioRoles = _mapper.Map<List<UsuarioRolDTO>>(personaDireccions.registros);
            return new Pager<UsuarioRolDTO>(lstUsuarioRoles, personaDireccions.totalRegistros, param.PageIndex, param.PageSize, param.Search);
        }

        [HttpGet("{idUsuario}/{idRol}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioRolDTO>> Get(int idUsuario, int idRol)
        {
            var personaDireccion = await _unitOfWork.UsuarioRoles.GetByIdAsync(idUsuario,idRol);
            return _mapper.Map<UsuarioRolDTO>(personaDireccion);
        }

        [HttpDelete("{idUsuario}/{idRol}")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int idUsuario, int idRol)
        {
            var usuarioRol = await _unitOfWork.UsuarioRoles.GetByIdAsync(idUsuario,idRol);
            if (usuarioRol == null) BadRequest();
            _unitOfWork.UsuarioRoles.Remove(usuarioRol);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
