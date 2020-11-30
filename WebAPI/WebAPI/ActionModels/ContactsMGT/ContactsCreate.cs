using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.ContactsMGT
{
    public class ContactsCreate : ControllerBase
    { 
        public Contact contact { get; set; }
        public async Task<ActionResult<Contact>> Excute()
        {
            var _context = new TGDDContext();

            contact.Id = _context.Contacts.Max(c => c.Id) + 1;

            _context.Contacts.Add(contact);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                bool contactExist = _context.Contacts.Any(c => c.Id == contact.Id);
                if (contactExist)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }
    }
}
