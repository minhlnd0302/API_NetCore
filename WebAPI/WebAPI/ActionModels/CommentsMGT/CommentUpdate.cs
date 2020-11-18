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
    public class CommentUpdate
    { 
        public long CommentId { get; set; }
        public CommentDTO CommentDTO { get; set; }
        public async Task<IActionResult> Excute()
        {
            //if (id != comments.Id)
            //{
            //    return BadRequest();
            //}
            var _context = new TGDDContext();

            Comment comment = AssigndataUtils.AssignComment(CommentDTO, CommentId);

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExist(CommentId))
                {
                    return new NotFoundObjectResult("Không tìm thấy comment!");
                }
                else
                {
                    throw;
                }
            }
            return new OkObjectResult("Chỉnh sửa thành công !");
        }

        private bool CommentExist(long id)
        {
            var _context = new TGDDContext();
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
