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
    public class ProductsUpdate : ControllerBase
    { 
        public ProductDTO ProductDTO { get; set; }
        public long id { get; set; }

        public async Task<IActionResult> Excute()
        {
            AssigndataUtils AssigndataUtils = new AssigndataUtils(); 
            var _context = new TGDDContext();  

            Product pro = await AssigndataUtils.AssignProduct(ProductDTO, id);

            //List<Description> tmp = pro.Descriptions.ToList() ;


            //foreach(Description description in tmp)
            //{
            //    _context.Entry((Description)description) = EntityState.Modified;
            //}
             
            _context.Entry(pro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool productExist = _context.Products.Any(p=>p.Id == pro.Id);
                if (!productExist)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(200);
        }

    }
}
