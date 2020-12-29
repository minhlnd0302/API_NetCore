using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.FavoritesMGT
{
    public class FavoritesGetByCustomerId : ControllerBase
    {
        public long CustomerId { get; set; }
        public async Task<ActionResult<IList<long?>>> Excute()
        {
            var _context = new TGDDContext();


            var p = await _context.Orders.ToListAsync();
            Customer t = await _context.Customers.Where(c => c.Id == CustomerId).Include(customer => customer.Favorites).FirstOrDefaultAsync();
            List<Favorite> f = t.Favorites.ToList();
            

            //IList<Favorite> favorites = await _context.Favorites.ToListAsync();

            //IList<Favorite> favorites = null;

            var productsId = new List<long?>();

            if (f.Count < 1)
            {
                return NotFound("Không có sản phẩm yêu thích !");
            }
            else
            {
                foreach (var item in f)
                {
                    productsId.Add(item.ProductId);
                }
            }
            return productsId;
        }
    }
}
