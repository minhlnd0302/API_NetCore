using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.FavoritesMGT
{
    public class FavoritesDelete : ControllerBase
    {
        public Favorite Favorite { get; set; }
        public async Task<ActionResult<Favorite>> Excute()
        {
            var _context = new TGDDContext();
            var favorite = new Favorite();

            List<Favorite> favorites = await _context.Favorites.Where(f=>f.ProductId == Favorite.ProductId).ToListAsync();
            
            foreach(Favorite f in favorites)
            {
                if(f.CustomerId == Favorite.CustomerId)
                {
                    favorite = f;
                    break;
                }
            }
            
            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();

            return favorite;
        }
    }
}
