using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.ProductsMGT
{
    public class ProductsDeleteImage : ControllerBase
    {
        public long ProductId { get; set; }

        public async Task<ActionResult<Image>> Excute()
        {
            var _context = new TGDDContext();
            var images = _context.Images.Where(image => image.ProductId == ProductId).ToList();

            if (images.Count < 1)
            {
                return NotFound();
            }
            else
            {
                foreach(Image img in images)
                {
                    _context.Images.Remove(img);
                }
            }

            try
            {
                 await _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest("Đã xảy ra lỗi");
            } 

            return Ok();
        }
    }
}
