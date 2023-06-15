using AutoMapper;
using Backend_Kineapp.Dtos;
using Backend_Kineapp.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Cryptography;
using Azure.Core;

namespace Backend_Kineapp.Controllers
{
    [ApiController]
    //[Authorize]
    public class LoginController : ControllerBase
    {
        private readonly KineappContext _context;
        private readonly IMapper _mapper;
        private readonly SignInManager<DtoUsuario> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly UserManager<DtoUsuario> _userManager;

        public LoginController(KineappContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("api/Login/loguear")]

        public async Task<ActionResult<DtoUsuario>> LoginPaciente(DtoUsuario usuario)
        {
            var paciente = await _context.Pacientes
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefaultAsync(p => p.IdUsuarioNavigation.NombreUsuario == usuario.NombreUsuario && p.IdUsuarioNavigation.Password == usuario.Password);

            if (paciente == null)
            {
                return Unauthorized();
            }
            else
            {
                    var usuarioDto = _mapper.Map<DtoUsuario>(paciente.IdUsuarioNavigation);
                    var token = GenerateAuthToken(usuarioDto);
                // return Ok(new { token });  
                return usuarioDto;
            }
        }


        private string GenerateAuthToken(DtoUsuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new byte[16]; // Tamaño de clave de 128 bits (16 bytes)
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            // Clave secreta para firmar el token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("NombreUsuario", usuario.NombreUsuario),
                new Claim("Password" , usuario.Password)
                // Agrega otros claims según tus necesidades
            }),
                Expires = DateTime.UtcNow.AddMinutes(20), // Tiempo de expiración del token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
