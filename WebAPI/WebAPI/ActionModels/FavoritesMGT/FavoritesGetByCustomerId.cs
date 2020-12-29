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



            List<Favorite> favorites = await _context.Favorites.Where(f => f.CustomerId == CustomerId).ToListAsync();

            //IList<Favorite> favorites = await _context.Favorites.ToListAsync();

            //IList<Favorite> favorites = null;

            var productsId = new List<long?>();

            if (favorites.Count < 1)
            {
                return NotFound("Không có sản phẩm yêu thích !");
            }
            else
            {
                foreach (var item in favorites)
                {
                    productsId.Add(item.ProductId);
                }
            }
            return productsId;
        }
    }
}
