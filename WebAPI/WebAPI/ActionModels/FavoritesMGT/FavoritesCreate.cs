using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.FavoritesMGT
{
    public class FavoritesCreate : ControllerBase
    {
        public Favorite Favorite { get; set; }
        public async Task<ActionResult<Favorite>> Excute()
        {
            var _context = new TGDDContext();

            var newFavoriteId = _context.Favorites.Max(c => c.Id) + 1;

            Favorite.Id = newFavoriteId;

            _context.Favorites.Add(Favorite);  

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                var favoriteExist = _context.Favorites.Any(f => f.Id == Favorite.Id);
                if (favoriteExist)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFavorite", new { id = Favorite.Id }, Favorite);
        }
    }
}
