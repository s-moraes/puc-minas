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
    [Route("v1/envio")]
    public class EnvioController : ControllerBase
    {
        [HttpGet]
        [Route("{id:int}")]
        //[Authorize(Roles="admin", "funcionario", "cliente", "fornecedor")]
        [Authorize(Roles="fornecedor")]
        public async Task<ActionResult<Envio>> Get(int id, [FromServices] DataContext context)
        {
            var envio = await context.
                                    Envios.
                                    Include(x => x.Locais).
                                    AsNoTracking().
                                    FirstOrDefaultAsync(x => x.Id == id);
            return Ok(envio);
        }

        [HttpPost]
        [Route("{id:int}")]
        [Authorize(Roles="fornecedor")]
        public async Task<ActionResult<Envio>> Post(int id,
                                                    [FromBody]Product model,
                                                    [FromServices] DataContext context)
        {
            try {

                Product product = context.Products.Find(id);
                
                if (null == product)
                    return NotFound(new {message = "Produto não encontrado"});

                Envio envio = new Envio {Locais = new List<Local>{new Local("Para retirar", DateTime.Now)}, ProductId = product.Id};

                context.Envios.Add(envio);
                await context.SaveChangesAsync();

                return Ok(envio);

            } catch (Exception e) {
                return BadRequest(new { message = "Internal Error, product not created"});
            }
        }        
    }
}
