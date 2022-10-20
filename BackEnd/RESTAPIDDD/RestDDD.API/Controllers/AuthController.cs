using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestDDD.API.Properties;
using RestDDD.Domain.Entities;

namespace RestDDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public AuthController(SignInManager<IdentityUser> signInManager, 
                                UserManager<IdentityUser> userManager,
                                IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Add(Usuario usuario)
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            }

            var user = new IdentityUser
            {
                UserName = usuario.Email,
                Email = usuario.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, usuario.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                await _signInManager.SignInAsync(user, false);
                var ret = new ObjectResult(new { message = "Usuário criado com sucesso", 
                                                    userLogin = user.Email,
                                                    token = await GerarJwt(usuario.Email)
                                            });
                ret.StatusCode = 201;
                return ret;
            }
        }

        [HttpPost("signin")]
        public async Task<ActionResult<dynamic>> Login([FromBody]Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            }

            var result = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Password, false, true);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Usuário ou senha inválida"});
            }
            else
            {
                return Ok( new { message = "Login efetuado com sucesso", token = await GerarJwt(usuario.Email) });
            }
        }

        private async Task<string> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            try
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _appSettings.Emissor,
                    Audience = _appSettings.ValidoEm,
                    Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                    SigningCredentials = new SigningCredentials(
                                            new SymmetricSecurityKey(key),
                                            SecurityAlgorithms.HmacSha256Signature)
                };

                return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}
/*
 {
  "id": 0,
  "email": "user@user.com",
  "password": "User@123",
  "tipo": 1
}
 */
