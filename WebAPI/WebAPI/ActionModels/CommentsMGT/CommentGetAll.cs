using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.CommentsMGT
{
    public class CommentGetAll
    {
        public async Task<ActionResult<IEnumerable<Comment>>> Excute()
        {
            var _context = new TGDDContext();
            return await _context.Comments.ToListAsync();
        }
    }
}
