using Dessalement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dessalement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsagerController : ControllerBase
    {
        private readonly MyContext dbContext;

        public UsagerController(MyContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usager>>> GetUsagers()
        {
            if(this.dbContext == null)
            {
                return NotFound();
            }
            return await this.dbContext.usagers.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Usager>>PostUsager(Usager usager)
        {
            this.dbContext.usagers.Add(usager);
            await this.dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsagers), new {id =usager.codeusage} , usager);
        }
        [HttpPut("{typeusage}/{codeusage}")]
        public async Task<ActionResult> PutUsager(string typeusage, string codeusage,Usager usager)
        {
            if (codeusage != usager.codeusage || typeusage != usager.typeusage)
            {
                return BadRequest();
            }

            this.dbContext.Entry(usager).State = EntityState.Modified;

            try
            {
                await this.dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsagerAvailable(typeusage, codeusage))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        private bool UsagerAvailable(string typeusage, string codeusage)
        {
            return this.dbContext.usagers.Any(x => x.typeusage == typeusage && x.codeusage == codeusage);
        }

        [HttpDelete("{typeusage}/{codeusage}")]
        public async Task<IActionResult> DeleteUsager(string typeusage, string codeusage)
        {
            if (this.dbContext == null)
            {
                return NotFound();
            }
            var usager = await this.dbContext.usagers.FindAsync(typeusage, codeusage);

            if (usager == null)
            {   
                return NotFound();
            }
            this.dbContext.usagers.Remove(usager);
            await this.dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
