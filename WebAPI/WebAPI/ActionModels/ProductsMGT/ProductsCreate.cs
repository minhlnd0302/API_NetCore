using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOModels;
using WebAPI.Models;
using WebAPI.Utils;

namespace WebAPI.ActionModels.ProductsMGT
{
    public class ProductsCreate : ControllerBase
    {
        public ProductDTO productDTO { get; set; }
        public async Task<ActionResult<Product>> Excute()
        {
            AssigndataUtils AssigndataUtils = new AssigndataUtils(); 
            var _context = new TGDDContext();

            Product newProduct = await AssigndataUtils.AssignProduct(productDTO, 0); 

            _context.Products.Add(newProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                bool productExist = _context.Products.Any(p => p.Id == newProduct.Id);
                if (productExist)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetProducts", new { id = newProduct.Id }, newProduct);
        }
    }
}
