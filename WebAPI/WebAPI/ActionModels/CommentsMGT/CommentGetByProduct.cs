using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.CommentsMGT
{
    public class CommentGetByProduct
    { 
        public long ProductId { get; set; }
        public async Task<ActionResult<Comment>> Excute()
        {
            var _context = new TGDDContext();

            var comment = await _context.Comments.FindAsync(ProductId);

            if (comment == null)
            {
                return new NotFoundResult();
            }
            return comment;
        } 
    }
}
