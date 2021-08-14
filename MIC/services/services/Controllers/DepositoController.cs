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
    [Route("[controller]")]
    public class DepositoController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public DepositoController (
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("deposito")]
        public IActionResult Deposito([FromBody]AutenticacaoModel model)
        {
            return BadRequest(new { message = "Username or password is incorrect" });
        }

        [HttpPost("cotacao")]
        public IActionResult Cotacao([FromBody]RegistroModel model)
        {
            return BadRequest(new { message = "Username or password is incorrect" });
        }

        [HttpGet("historico")]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{codigo_rastreamento}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
    }
}
