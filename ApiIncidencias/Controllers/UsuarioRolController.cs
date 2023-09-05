using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos;
using ApiIncidencias.Services;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers;
    public class UsuarioRolController : BaseApiController
    {
        private readonly IUserService _userService;
       private readonly IUnitOfWork _unitOfWork;
       public UsuarioRolController (IUserService userService, IUnitOfWork unitOfWork){
        _userService=userService;
        _unitOfWork=unitOfWork;
       }
        [HttpPost("addrol")]
        public async Task<IActionResult> AddRolAsync(AddRoleDTO model){
            var result= await _userService.addRoleAsync(model);
            return Ok(result);
        }

        [HttpDelete("{idUsuario}/{idRol}")]
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
