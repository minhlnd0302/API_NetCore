using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.ContactsMGT
{
    public class ContactGetAll
    {
        public async Task<ActionResult<IEnumerable<Contact>>> Excute()
        {
            var _context = new TGDDContext();
            return await _context.Contacts.ToListAsync();
        }
    }
}
