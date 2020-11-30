using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.CommentsMGT
{
    public class CommentGetByProduct : ControllerBase
    { 
        public long ProductId { get; set; }
        public async Task<ActionResult<List<Comment>>> Excute()
        {
            var _context = new TGDDContext();

            List<Comment> comments = await _context.Comments.Where(c => c.ProductId == ProductId).ToListAsync();

            if (comments.Count < 1)
            {
                return NotFound();
            }
            return comments;
        } 
    }
}
