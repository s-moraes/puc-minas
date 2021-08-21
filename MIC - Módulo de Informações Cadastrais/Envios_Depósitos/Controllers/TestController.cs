using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DepositoService.Data;
using DepositoService.Models;
using DepositoService.Services;

namespace DepositoService.Controllers
{

    [Route("v1/data")]
    public class TestController : Controller
    {
        [HttpGet]
        [Route("/create")]
        public async Task<ActionResult<dynamic>> Get([FromServices] DataContext context)
        {
            var cliente1 = new User {Id = 1, Username = "cliente1", Password = "cliente1", Role = "cliente"};
            var cliente2 = new User {Id = 2, Username = "cliente2", Password = "cliente2", Role = "cliente"};
            var cliente3 = new User {Id = 3, Username = "cliente3", Password = "cliente3", Role = "cliente"};
            var cliente4 = new User {Id = 4, Username = "cliente4", Password = "cliente4", Role = "cliente"};
            var cliente5 = new User {Id = 5, Username = "cliente5", Password = "cliente5", Role = "cliente"};

            var admin = new User {Id = 6, Username = "admin", Password = "admin", Role = "admin"};

            var fornecedor1 = new User {Id = 7, Username = "fornecedor1", Password = "fornecedor1", Role = "fornecedor"};
            var fornecedor2 = new User {Id = 8, Username = "fornecedor2", Password = "fornecedor2", Role = "fornecedor"};
            var fornecedor3 = new User {Id = 9, Username = "fornecedor3", Password = "fornecedor3", Role = "fornecedor"};

            var funcionario1 = new User {Id = 10, Username = "funcionario1", Password = "funcionario1", Role = "funcionario"};
            var funcionario2 = new User {Id = 11, Username = "funcionario2", Password = "funcionario2", Role = "funcionario"};

            var deposito1 = new Deposito {Id = 1, Title = "Deposito 01", FornecedorId=funcionario1.Id};
            var deposito2 = new Deposito {Id = 2, Title = "Deposito 02", FornecedorId=funcionario2.Id};

            var product1 = new Product {Id = 1, Title="Prod01", Description="Desc", Price=2, DepositoId=deposito1.Id};
            var product2 = new Product {Id = 2, Title="Prod02", Description="Desc", Price=8, DepositoId=deposito1.Id};
            var product3 = new Product {Id = 3, Title="Prod03", Description="Desc", Price=20, DepositoId=deposito2.Id};
            var product4 = new Product {Id = 4, Title="Prod04", Description="Desc", Price=92, DepositoId=deposito2.Id};

            var envio1 = new Envio {Id = 1, Locais = new List<Local>{new Local("SP", DateTime.Now), new Local("MG", DateTime.Now)}, ProductId = 1};
            var envio2 = new Envio {Id = 2, Locais = new List<Local>{new Local("MG", DateTime.Now)}, ProductId = 2};
            var envio3 = new Envio {Id = 3, Locais = new List<Local>{new Local("RJ", DateTime.Now)}, ProductId = 3};
            var envio4 = new Envio {Id = 4, Locais = new List<Local>{new Local("GO", DateTime.Now)}, ProductId = 4};

            context.Database.EnsureDeleted();

            context.User.Add(cliente1);
            context.User.Add(cliente2);
            context.User.Add(cliente3);
            context.User.Add(cliente4);
            context.User.Add(cliente5);

            context.User.Add(admin);

            context.User.Add(fornecedor1);
            context.User.Add(fornecedor2);
            context.User.Add(fornecedor3);

            context.User.Add(funcionario1);
            context.User.Add(funcionario2);

            context.Depositos.Add(deposito1);
            context.Depositos.Add(deposito2);

            context.Products.Add(product1);
            context.Products.Add(product2);
            context.Products.Add(product3);
            context.Products.Add(product4);

            context.Envios.Add(envio1);
            context.Envios.Add(envio2);
            context.Envios.Add(envio3);
            context.Envios.Add(envio4);

            await context.SaveChangesAsync();

            return Ok(new
            {
                message = "Dados configurados"
            });
        }

        [HttpGet]
        [Route("/clean")]
        public async Task<ActionResult<dynamic>> CleanUp([FromServices] DataContext context)
        {
            context.Database.EnsureDeleted();

            await context.SaveChangesAsync();

            return Ok(new
            {
                message = "Dados removidos"
            });
        }
    }

}