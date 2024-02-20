using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PhoneBook.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactContext _context;

        public ContactsController(ContactContext context)
        {
            _context = context;
        }

        // GET: api/contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactItem>>> GetContactItems()
        {
            return await _context.ContactItems.ToListAsync();
        }

        // GET: api/contacts/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactItem>> GetContactItem(long id)
        {
            var cntactItem = await _context.ContactItems.FindAsync(id);

            if (cntactItem == null)
            {
                return NotFound();
            }

            return cntactItem;
        }

        // PUT: api/contacts/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactItem(long id, ContactItem contactItem)
        {
            if (id != contactItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactItemExists(id))
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

        // POST: api/contacts
        [HttpPost]
        public async Task<ActionResult<ContactItem>> PostContactItem(ContactItem contactItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ContactItems.Add(contactItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactItem", new { id = contactItem.Id }, contactItem);
        }

        // DELETE: api/contacts/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactItem(long id)
        {
            var contactItem = await _context.ContactItems.FindAsync(id);
            if (contactItem == null)
            {
                return NotFound();
            }

            _context.ContactItems.Remove(contactItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactItemExists(long id)
        {
            return _context.ContactItems.Any(e => e.Id == id);
        }
    }
}

