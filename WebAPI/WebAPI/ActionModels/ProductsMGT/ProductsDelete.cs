using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.ProductsMGT
{
    public class ProductsDelete : ControllerBase
    {
        public long ProductId { get; set; }
        public async Task<ActionResult<Product>> Excute()
        {
            var _context = new TGDDContext(); 
            var products = await _context.Products.FindAsync(ProductId);
            if (products == null)
            {
                return NotFound("Không tìm thấy sản phẩm !");
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return Ok("Xóa sản phẩm thành công !");
        }
    }
}
