using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.ContactsMGT
{
    public class ContactsUpdateReply : ControllerBase
    {
        public long ContactId { get; set; }
        public async Task<IActionResult> Excute()
        {
            var _context = new TGDDContext();
            var contact = await _context.Contacts.FindAsync(ContactId); 
            contact.IsReply = true;

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool contactExist = _context.Contacts.Any(c => c.Id == ContactId);
                if (!contactExist)
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
    }
}
