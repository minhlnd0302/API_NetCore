using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ActionModels.ContactsMGT;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly TGDDContext _context;

        public ContactsController(TGDDContext context)
        {
            _context = context;
        }

        // GET: api/Contacts
        [Authorize(Roles = "0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var contactGetAll = new ContactGetAll();
            return await contactGetAll.Excute();
        }

        // GET: api/Contacts/5
        [Authorize(Roles = "0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(long id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "0")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(long id)
        {
            var updateReply = new ContactsUpdateReply { ContactId = id };

            return await updateReply.Excute();
        } 
  
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            var contactCreate = new ContactsCreate { contact = contact };
            return await contactCreate.Excute(); 
        }

        // DELETE: api/Contacts/5
        [Authorize(Roles = "0")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> DeleteContact(long id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        private bool ContactExists(long id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
