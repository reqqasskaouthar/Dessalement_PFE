using Dessalement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dessalement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelleController : ControllerBase
    {
        private readonly MyContext dbContext;
        public ParcelleController(MyContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parcelle>>> GetParcelles()
        {
            if (this.dbContext == null)
            {
                return NotFound();
            }
            return await this.dbContext.parcelles.ToListAsync();
        }
     
        [HttpGet("{codeparcelle}")]
        public async Task<ActionResult<Parcelle>> GetParcelle(string codeparcelle)
        {
            var Parcelle = await dbContext.parcelles.FindAsync(codeparcelle);

            if (Parcelle == null)
            {
                return NotFound();
            }

            return Parcelle;
        }
        [HttpPost]
        public async Task<ActionResult<Parcelle>> PostParcelle(Parcelle parcelle)
        {
            this.dbContext.parcelles.Add(parcelle);
            await this.dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetParcelles), new { id = parcelle.codeparcelle }, parcelle);
        }
        [HttpPut("{codeparcelle}")]
        public async Task<IActionResult> PutTodoItem(string codeparcelle, Parcelle parcelle)
        {
            if (codeparcelle != parcelle.codeparcelle)
            {
                return BadRequest();
            }

            dbContext.Entry(parcelle).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParcelleAvailable(codeparcelle))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool ParcelleAvailable( string codeparcelle)
        {
            return this.dbContext.parcelles.Any(x => x.codeparcelle == codeparcelle );
        }
        [HttpDelete("{codeparcelle}")]


        public async Task<ActionResult<Parcelle>> DeleteParcelle(string codeparcelle)
        {
            if (this.dbContext == null)
            {
                return NotFound();
            }
            var parcelle = await this.dbContext.parcelles.FindAsync(codeparcelle);

            if (parcelle == null)
            {
                return NotFound();
            }
            this.dbContext.parcelles.Remove(parcelle);
            await this.dbContext.SaveChangesAsync();

            return Ok();

        }
    }
}
