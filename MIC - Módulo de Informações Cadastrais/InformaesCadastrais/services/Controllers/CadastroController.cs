using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1/cadastro")]
    public class CadastroController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public CadastroController (
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        // Login
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AutenticacaoModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password incorreto" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                Token = tokenString
            });
        }

        // Permite o registro de um novo cliente
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegistroModel model)
        {
            // Mapeamento para a entity
            var user = _mapper.Map<User>(model);

            try
            {
                model.Role = "cliente";
                _userService.Create(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Permite o registro de um novo fornecedor, apenas funcionarios podem registrar um novo fornecedor
        [HttpPost("registerFornecedor")]
        [Authorize(Roles="funcionario")]
        public IActionResult RegisterFornecedor([FromBody]RegistroModel model)
        {
            // Mapeamento para a entity
            var user = _mapper.Map<User>(model);

            try
            {
                model.Role = "fornecedor";
                _userService.Create(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Retorna todos os usuários registrados
        [HttpGet]
        [Authorize(Roles="admin, funcionario")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var model = _mapper.Map<IList<UsuarioModel>>(users);
            return Ok(model);
        }

        // Retorna os dados de um usuário especifico
        [HttpGet("{id}")]
        [Authorize(Roles="admin, funcionario, fornecedor, cliente")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            var model = _mapper.Map<UsuarioModel>(user);
            return Ok(model);
        }

        // Atualiza os dados de um usuário especifico
        [HttpPut("{id}")]
        [Authorize(Roles="admin, funcionario, fornecedor, cliente")]
        public IActionResult Update(int id, [FromBody]UsuarioUpdateModel model)
        {
            // Mapeamento para a entity
            var user = _mapper.Map<User>(model);
            user.Id = id;

            try
            {
                _userService.Update(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Remove um usuário
        [HttpDelete("{id}")]
        [Authorize(Roles="admin, funcionario")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
