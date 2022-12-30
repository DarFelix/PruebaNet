using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaNet.Data;
using PruebaNet.Models;

namespace PruebaNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {

        private readonly ContactoContexto _context;

        public ContactosController(ContactoContexto context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetContactoItems()
        {
            return await _context.ContactoItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contacto>> GetContactoItem(int id)
        {
            var contactoItem = await _context.ContactoItems.FindAsync(id);

            if(contactoItem == null) 
            {
                    return NotFound();
            }

            return contactoItem;
        }

        [HttpPost]
        public async Task<ActionResult<Contacto>> PostContactoItem(Contacto item)
        {
            _context.ContactoItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContactoItem), new {id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutContactoItem(int id, Contacto item)
        {
            if(id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State= EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContactoItem(int id)
        {
            var contactoItem = await _context.ContactoItems.FindAsync(id);

            if(contactoItem == null)
            {
                return NotFound();
            }

            _context.ContactoItems.Remove(contactoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
