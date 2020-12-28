using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;


namespace WebAPI.ActionModels
{
    public class ProductsGetAll
    {
        public async Task<ActionResult<IEnumerable<Product>>> Excute()
        {
            var _context = new TGDDContext(); 

            var products = await _context.Products.Include(p => p.Descriptions)
                                            .Include(p => p.Images)
                                            .Include(p => p.Category)
                                            .Include(p => p.Brand)
                                            .Include(p => p.Comments)
                                            .ToListAsync();

            return products;
        }
    }
}
