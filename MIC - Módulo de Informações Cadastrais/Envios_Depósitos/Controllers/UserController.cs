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

    [Route("v1/users")]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("")]
        [Authorize(Roles="admin, funcionario")]
        // Retorna lista de users
        public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context)
        {
            var users = await context
                            .User
                            .AsNoTracking()
                            .ToListAsync();
            return users;
        }


        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        // Registra cliente
        public async Task<ActionResult<User>> Register (
            [FromServices] DataContext context,
            [FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                model.Role = "cliente";

                context.User.Add(model);
                await context.SaveChangesAsync();

                model.Password = ""; // não retornar o password
                return Ok(model);
            } catch {
                return BadRequest(new {message = "Internal Error, usuário não criado"});
            }
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles="admin, funcionario")]
        // Registra funcionário, fornecedor e admin
        public async Task<ActionResult<User>> Post (
            [FromServices] DataContext context,
            [FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.User.Add(model);
                await context.SaveChangesAsync();

                model.Password = ""; // não retornar o password
                return Ok(model);
            } catch {
                return BadRequest(new {message = "Internal Error, usuário não criado"});
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles="admin, funcionario, cliente")]
        public async Task<ActionResult<User>> Put(
            int id,
            [FromServices] DataContext context,
            [FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != model.Id)
                return NotFound(new {message = "Usúario não encontrado"});


            try
            {
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            } catch {
                return BadRequest(new {message = "Internal Error, dados não foram atualizados"});
            }
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromServices] DataContext context,
            [FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await context.User
                                .AsNoTracking()
                                .Where(x => x.Username == model.Username && x.Password == model.Password)
                                .FirstOrDefaultAsync();

            if (user == null)
                return BadRequest(new {message = "Usuário ou password inválido"});

            var token = TokenService.GenerateToken(user);
            user.Password = ""; // não retornar o password
            
            return new {
                user = user,
                token = token
            };
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles="admin, funcionario")]
        public async Task<ActionResult<dynamic>> Remove (
            int id,
            [FromServices] DataContext context,
            [FromBody] User model)
        {
            try
            {
                User user = context.User.Find(id);

                context.User.Remove(user);
                await context.SaveChangesAsync();

                return Ok(new {message = "Usuário removido"});
            } catch {
                return BadRequest(new {message = "Internal Error, usuário não removido"});
            }
        }
    }

}