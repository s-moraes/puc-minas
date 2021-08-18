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
    [Route("v1/create_data")]
    public class TestController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public TestController (
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        // Rastrear encomenda
        [AllowAnonymous]
        [HttpGet]
        [Route("/create")]
        public IActionResult Get()
        {
            var cliente1 = new RegistroModel {FirstName = "Pedro",
                                              LastName = "Silva",
                                              Username = "cliente",
                                              Password = "cliente",
                                              Documento = "41234354534",
                                              Cidade = "São Paulo",
                                              Endereco = "Rua São Paulo, n15",
                                              CEP = "12234-234",
                                              Role = "cliente"};

            var user = _mapper.Map<User>(cliente1);
            _userService.Create(user, cliente1.Password);

            var fornecedor1 = new RegistroModel {FirstName = "João",
                                              LastName = "Nogueira",
                                              Username = "fornecedor",
                                              Password = "fornecedor",
                                              Documento = "23325909878",
                                              Cidade = "Campinas",
                                              Endereco = "Rua Primavera, n843",
                                              CEP = "23234-234",
                                              Role = "fornecedor"};

            user = _mapper.Map<User>(fornecedor1);
            _userService.Create(user, fornecedor1.Password);

            var admin1 = new RegistroModel {FirstName = "Edgar",
                                              LastName = "Toledo",
                                              Username = "admin",
                                              Password = "admin",
                                              Documento = "33245123233",
                                              Cidade = "Campinas",
                                              Endereco = "Rua das Palmeiras, n67",
                                              CEP = "66234-234",
                                              Role = "admin"};

            user = _mapper.Map<User>(admin1);
            _userService.Create(user, admin1.Password);

            var funcionario1 = new RegistroModel {FirstName = "Paulo",
                                              LastName = "Moraes",
                                              Username = "funcionario",
                                              Password = "funcionario",
                                              Documento = "33456723412",
                                              Cidade = "Itapira",
                                              Endereco = "Rua Pio XV, n154",
                                              CEP = "75234-234",
                                              Role = "funcionario"};

            user = _mapper.Map<User>(funcionario1);
            _userService.Create(user, funcionario1.Password);

            return Ok(new { message = "OK" });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/clean")]
        public IActionResult CleanUp()
        {
            _userService.CleanUp();

            return Ok(new { message = "OK" });
        }
    }
}
