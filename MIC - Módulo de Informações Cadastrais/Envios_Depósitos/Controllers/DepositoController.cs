using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DepositoService.Data;
using DepositoService.Models;

namespace DepositoService.Controllers
{
    [Route("v1/depositos")]
    public class DepositoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Authorize(Roles="admin, funcionario")]
        // Consulta lista de depositos registrados
        public async Task<ActionResult<List<Deposito>>> Get([FromServices] DataContext context)
        {
            var depositos = await context.Depositos.AsNoTracking().ToListAsync();
            return Ok(depositos);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles="admin, funcionario, fornecedor, cliente")]
        // Consulta um deposito
        public async Task<ActionResult<Deposito>> GetById(int id,
                                                        [FromServices] DataContext context)
        {
            var depositos = await context.Depositos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Ok(depositos);
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles="admin, funcionario")]
        // Cadastra um novo deposito
        public async Task<ActionResult<List<Deposito>>> Post([FromBody]Deposito model,
                                                            [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                context.Depositos.Add(model);
                await context.SaveChangesAsync();

                return Ok(model);

            } catch (Exception e) {
                return BadRequest(new { message = "Internal Error, deposito não foi cadastrado"});
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles="admin, funcionario")]
        // Atualiza cadastro de um deposito
        public async Task<ActionResult<List<Deposito>>> Put(int id, [FromBody]Deposito model,
                                                                    [FromServices] DataContext context)
        {
            if (model.Id != id)
                return NotFound(new {message = "Deposito não encontrado"});

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Deposito>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);


            } catch (DbUpdateConcurrencyException e) {
                return BadRequest(new { message = "Internal Error, deposito atualizado"});
            } catch (Exception e) {
                return BadRequest(new { message = "Internal Error, deposito não atualizado"});
            }

        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles="admin, funcionario")]
        // Remove o cadastro de um deposito
        public async Task<ActionResult<List<Deposito>>> Delete(int id,
                                                            [FromServices] DataContext context)
        {
            var category = await context.Depositos.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound (new {message = "Deposito não encontrado"});

            try
            {
                context.Depositos.Remove(category);
                await context.SaveChangesAsync();
                return Ok(new {message = "Deposito removido com sucesso"});

            } catch {
                return BadRequest (new {message = "Internal Error requisição inválida"});
            }
        }
    }
}
