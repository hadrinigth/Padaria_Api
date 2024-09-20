using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Padaria_Api.Data;
using Padaria_Api.Models;


namespace Padaria_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositosController : ControllerBase
    {
        private readonly Padaria_ApiContext _context;

        public DepositosController(Padaria_ApiContext context)
        {
            _context = context;
        }

        // GET: api/Depositos // listando todo os items do deposito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deposito>>> GetDeposito()
        {
            return await _context.Deposito.ToListAsync();
        }

        // GET: api/Depositos/~id  // item do deposito por id 
        [HttpGet("{id}")]
        public async Task<ActionResult<Deposito>> GetDeposito(int id)
        {
            var deposito = await _context.Deposito.FindAsync(id);

            if (deposito == null)
            {
                return NotFound();
            }

            return deposito;
        }

        // PUT: api/Depositos/~id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeposito(int id, Deposito deposito)
        {
            if (id != deposito.Id)
            {
                return BadRequest();
            }

            _context.Entry(deposito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositoExists(id))
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

        // POST: api/Depositos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deposito>> PostDeposito([FromBody] Deposito deposito)
        {
            _context.Deposito.Add(deposito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeposito", new { id = deposito.Id }, deposito);
        }

        // DELETE: api/Depositos/~id //deleta os item por id 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeposito(int id)
        {
            var deposito = await _context.Deposito.FindAsync(id);
            if (deposito == null)
            {
                return NotFound();
            }

            _context.Deposito.Remove(deposito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepositoExists(int id)
        {
            return _context.Deposito.Any(e => e.Id == id);
        }
    }
}
