using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DepositoService.Data;
using DepositoService.Models;

namespace DepositoService.Controllers
{
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Authorize(Roles="funcionario, fornecedor, cliente")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var products = await context.
                                    Products.
                                    AsNoTracking().
                                    ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles="funcionario, fornecedor, cliente")]
        public async Task<ActionResult<List<Product>>> Get(int id,
                                                           [FromServices] DataContext context)
        {
            var products = await context.
                                    Products.
                                    AsNoTracking().
                                    FirstOrDefaultAsync(x => x.Id == id);
            return Ok(products);
        }

        [HttpGet]
        [Route("depositos/{id:int}")]
        [Authorize(Roles="funcionario, fornecedor, cliente")]
        public async Task<ActionResult<List<Product>>> GetByDeposito(int id,
                                                           [FromServices] DataContext context)
        {
            var products = await context.
                                    Products.
                                    AsNoTracking().
                                    Where(x => x.DepositoId == id).
                                    ToListAsync();
            return Ok(products);
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles="fornecedor")]
        public async Task<ActionResult<List<Deposito>>> Post([FromBody]Product model,
                                                            [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return Ok(new { message = "Produto registrado"});

            } catch (Exception e) {
                return BadRequest(new { message = "Internal Error, product not created"});
            }
        }        
    }
}
