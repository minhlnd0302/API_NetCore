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
        // get all comment
        // GET: https://minhlnd.azurewebsites.net/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            var comments = new CommentGetAll();
            return await comments.Excute();
        }

        [HttpGet("test")]
        public async Task<ActionResult<Customer>> test()
        {
            var _context = new TGDDContext(); 
            var p = _context.Customers.Where(p => p.Id == 1).FirstOrDefault();

            //string p = _context.Customers.Where(p => p.Id == 1).Select(p => p.Password).ToString();


            return p;
        }



        // lấy bình luận theo Id sản phẩm
        // GET: https://minhlnd.azurewebsites.net/Comments/CommentId 
        [HttpGet("{ProductId}")]
        public async Task<ActionResult<List<Comment>>> GetCommentFromProductId(long ProductId)
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

        // add comment
        // POST: https://minhlnd.azurewebsites.net/Comments 
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComments(CommentDTO commentDTO)
        {
            var create = new CommentCreate { commentDTO = commentDTO };
            return await create.Excute();
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
    }
}
