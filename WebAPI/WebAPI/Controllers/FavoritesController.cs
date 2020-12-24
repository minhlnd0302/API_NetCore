using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ActionModels.FavoritesMGT;
using WebAPI.DTOModels;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    { 
        // GET: api/Favorites/5
        [HttpGet("{CustomerId}")]
        public async Task<ActionResult<List<long?>>> GetFavorite(long CustomerId)
        {
            var favoriteGetByCustomerId = new FavoritesGetByCustomerId { CustomerId = CustomerId };
            return await favoriteGetByCustomerId.Excute();
        } 

        [HttpPost]
        public async Task<ActionResult<Favorite>> PostFavorite(Favorite favorite)
        {
            var createFavorite = new FavoritesCreate { Favorite = favorite };

            return await createFavorite.Excute();
        }

        // DELETE: api/Favorites/5
        [HttpDelete]
        public async Task<ActionResult<Favorite>> DeleteFavorite(Favorite favorite)
        {
            var favoriteDelete = new FavoritesDelete { Favorite = favorite };

            return await favoriteDelete.Excute();
        } 
    }
}
