using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ActionModels.CommentsMGT;
using WebAPI.DTOModels;
using WebAPI.Models;
using WebAPI.Utils;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly TGDDContext _context;

        public CommentsController(TGDDContext context)
        {
            _context = context;
            AssigndataUtils._context = _context;
        }

        // get all comment
        // GET: https://minhlnd.azurewebsites.net/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            var comments = new CommentGetAll();
            return await comments.Excute();
        }


        // lấy bình luận theo Id sản phẩm
        // GET: https://minhlnd.azurewebsites.net/Comments/CommentId 
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetCommentForIdProduct(long ProductId)
        {
            var comment = new CommentGetByProduct { ProductId = ProductId };
            return await comment.Excute();
        }


        // chỉnh sửa comment
        // Put : https://minhlnd.azurewebsites.net/Comments/CommentId
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComments(long id, CommentDTO commentDTO)
        {
            var CommentUpdate = new CommentUpdate
            {
                CommentId = id,
                CommentDTO = commentDTO
            };

            return await CommentUpdate.Excute();
        }

        // POST: api/Comments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComments(Comment comment)
        {
            _context.Comments.Add(comment);
            try
            {
                
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommentsExists(comment.Id))
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


        // xóa comment
        // DELETE: https://minhlnd.azurewebsites.net/Comments/CommentId
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComments(long id)
        {
            var CommentDelete = new CommentDelete { CommentId = id };

            return await CommentDelete.Excute();
        }

        private bool CommentsExists(long id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
