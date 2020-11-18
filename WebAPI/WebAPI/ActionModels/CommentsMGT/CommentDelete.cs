using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.CommentsMGT
{
    public class CommentDelete
    {
        public long CommentId { get; set; }
        public async Task<ActionResult<Comment>> Excute()
        {
            var _context = new TGDDContext();

            var comments = await _context.Comments.FindAsync(CommentId);
            if (comments == null)
            {
                return new NotFoundObjectResult("Bình luận không tồn tại !");
            }

            _context.Comments.Remove(comments);
            await _context.SaveChangesAsync();

            return new OkObjectResult("Xóa bình luận thành công !");
        }
    }
}
