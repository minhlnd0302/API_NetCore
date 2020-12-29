using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOModels;
using WebAPI.Models;
using WebAPI.Utils;

namespace WebAPI.ActionModels.CommentsMGT
{
    public class CommentCreate : ControllerBase
    {
        public CommentDTO commentDTO { get; set; }
        public async Task<ActionResult<Comment>> Excute()
        {

            AssigndataUtils AssigndataUtils = new AssigndataUtils();
            var _context = new TGDDContext();


            var comment = AssigndataUtils.AssignComment(commentDTO, 0);
            _context.Comments.Add(comment);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                bool commentExist = _context.Comments.Any(e => e.Id == comment.Id);
                if (commentExist)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetComments", new { id = comment.Id }, comment);

        }
    }
}
