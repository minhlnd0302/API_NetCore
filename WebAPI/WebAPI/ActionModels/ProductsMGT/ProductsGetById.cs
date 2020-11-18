using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;


namespace WebAPI.ActionModels.ProductMGT
{
    public class ProductsGetById
    {
        public long ProductId { get; set; }
        public async Task<ActionResult<Product>> Excute()
        {
            var _context = new TGDDContext();

            var product = await _context.Products.Include(p => p.Brand)
                                            .Include(p => p.Category)
                                            .Include(p => p.Descriptions)
                                            .Include(p => p.Comments)
                                            .Include(p => p.Images)
                                            .FirstOrDefaultAsync(product => product.Id == ProductId);

            if (product == null)
            {
                //return NotFound("Không tìm thấy sẳn phẩm này !");

                return new NotFoundObjectResult("Không tìm thấy sẳn phẩm này !");
            }

            return product;
        }
    }
}
