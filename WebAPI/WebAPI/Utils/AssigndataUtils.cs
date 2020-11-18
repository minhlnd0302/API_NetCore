using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.DTOModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Utils
{

    public class AssigndataUtils : DbContext
    { 
        // nếu id = 0 là thêm mới, ngược lại là chỉnh sửa
        public static Comment AssignComment(CommentDTO commentsDTO, long id)
        {
            var _context = new TGDDContext();
            var comment = new Comment();

            if (id == 0)
            {
                long newCommentId = _context.Comments.Max(p => p.Id) + 1;
            }

            // assign value from commentDTO to comments
            {
                comment.Id = id;
                comment.CustomerId = commentsDTO.CustomerId;
                comment.ProductId = commentsDTO.ProductId;
                comment.Message = commentsDTO.Message;
                comment.Date = DateTime.Now;
                comment.Ratting = commentsDTO.Ratting;
            }
            return comment;
        }

        public static Product AssignProduct(ProductDTO productsDTO, long id)
        {
            var product = new Product();

            return product;
        }
    }
}
