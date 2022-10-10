using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjApiAula20221003.Data;
using ProjApiAula20221003.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ProjApiAula20221003.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {

        private readonly ProjApiAula20221003Context _context;

        public EnderecoController(ProjApiAula20221003Context context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetEndereco(int id)
        {
            var endereco = await _context.Endereco.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }


        [HttpPost]
        public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
        {

            _context.Endereco.Add(endereco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEndereco", new { id = endereco.Id }, endereco);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEndereco()
        {
            return await _context.Endereco.ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEndereco(int id)
        {
            var endereco = await _context.Endereco.FindAsync(id);
            
            if (endereco == null)
            {
                return NotFound();
            }

            //Delete Cascate: Exemplo:
            var clientes = _context.Cliente.Include(c => c.Endereco)
                                           .Where(c => c.Endereco.Id == id)
                                           .ToList();

            clientes.ForEach(c => _context.Cliente.Remove(c));
            
            _context.Endereco.Remove(endereco);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
