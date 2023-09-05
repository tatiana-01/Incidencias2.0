using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiIncidencias.Dtos;
using ApiIncidencias.Dtos.Usuario;
using ApiIncidencias.Helpers;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ApiIncidencias.Services;
public class UserService : IUserService
{
    private readonly JWT _jwt;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<Usuario> _passwordHasher;

    public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt, IPasswordHasher<Usuario> passwordHasher)
    {
        _jwt = jwt.Value;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }
    public async Task<string> addRoleAsync(AddRoleDTO model)
    {
         var usuario = await _unitOfWork.Usuarios
                    .GetByUsernameAsync(model.Username);
        if (usuario == null)
        {
            return $"No existe algún usuario registrado con la cuenta {model.Username}.";
        }
        var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Contraseña, model.Password);
        if (resultado == PasswordVerificationResult.Success)
        {
            var rolExiste = _unitOfWork.Roles
                                        .Find(u => u.Nombre == model.Role)
                                        .FirstOrDefault();
            if (rolExiste != null)
            {
                var usuarioTieneRol = usuario.Roles
                                            .Any(u => u.Id == rolExiste.Id);

                if (usuarioTieneRol == false)
                {
                    usuario.Roles.Add(rolExiste);
                    _unitOfWork.Usuarios.Update(usuario);
                    await _unitOfWork.SaveAsync();
                }
                return $"Rol {model.Role} agregado a la cuenta {model.Username} de forma exitosa.";
            }
            return $"Rol {model.Role} no encontrado.";
        }
        return $"Credenciales incorrectas para el usuario {usuario.UsuarioPersona}.";
    }

    public async Task<DatosUsuarioDTO> GetTokenAsync(LoginDTO model)
    {
         DatosUsuarioDTO datosUsuarioDto = new DatosUsuarioDTO();
        var usuario = await _unitOfWork.Usuarios
                    .GetByUsernameAsync(model.Username);
        if (usuario == null)
        {
            datosUsuarioDto.EstaAutenticado = false;
            datosUsuarioDto.Mensaje = $"No existe ningún usuario con el username {model.Username}.";
            return datosUsuarioDto;
        }

        var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Contraseña, model.Password);
        if (result == PasswordVerificationResult.Success)
        {

            datosUsuarioDto.Mensaje = "Ok";
            datosUsuarioDto.EstaAutenticado = true;
            JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);
            datosUsuarioDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            datosUsuarioDto.UserName = usuario.UsuarioPersona;
            datosUsuarioDto.Email = usuario.Email;
            datosUsuarioDto.Roles = usuario.Roles
                                                .Select(p => p.Nombre)
                                                .ToList();
            return datosUsuarioDto;

        }
        datosUsuarioDto.EstaAutenticado = false;
        datosUsuarioDto.Mensaje = $"Credenciales incorrectas para el usuario {usuario.UsuarioPersona}.";
        return datosUsuarioDto;
    }

    public async Task<string> ResgisterAsync(UsuarioPostDTO usuarioPostDTO)
    {
        var usuario = new Usuario
        {

            Email = usuarioPostDTO.Email,
            UsuarioPersona = usuarioPostDTO.UsuarioPersona,
            IdPersona = usuarioPostDTO.IdPersona

        };

        usuario.Contraseña = _passwordHasher.HashPassword(usuario, usuarioPostDTO.Contraseña);

        var usuarioExiste = _unitOfWork.Usuarios
                                    .Find(u => u.UsuarioPersona.ToLower() == usuarioPostDTO.UsuarioPersona.ToLower())
                                    .FirstOrDefault();

        var personaExiste = _unitOfWork.Personas
                                    .Find(u => u.Id == usuarioPostDTO.IdPersona)
                                    .FirstOrDefault();

        if (usuarioExiste == null)
        {
            if (personaExiste != null)
            {
                var rolPredeterminado = _unitOfWork.Roles
                                    .Find(u => u.Nombre.ToLower() == Autorizacion.rol_predeterminado.ToString().ToLower())
                                    .First();
                try
                {
                    usuario.Roles.Add(rolPredeterminado);
                    _unitOfWork.Usuarios.Add(usuario);
                    await _unitOfWork.SaveAsync();

                    return $"El usuario  {usuarioPostDTO.UsuarioPersona} ha sido registrado exitosamente";
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                    return $"Error: {message}";
                }
            }else{
                return $"La persona con el Id {usuarioPostDTO.IdPersona} no se encuentra.";
            }

        }
        else
        {
            return $"El usuario con {usuarioPostDTO.UsuarioPersona} ya se encuentra registrado.";
        }
    }

    private JwtSecurityToken CreateJwtToken(Usuario usuario)
    {
        var roles = usuario.Roles;
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", role.Nombre));
        }
        var claims = new[]
        {
                                new Claim(JwtRegisteredClaimNames.Sub, usuario.UsuarioPersona),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                                new Claim("uid", usuario.Id.ToString())
                        }
        .Union(roleClaims);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        Console.WriteLine("", symmetricSecurityKey);
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }
}
