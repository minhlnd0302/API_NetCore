using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.ProductsMGT
{   
    public class ProductsAutoUpdate
    { 
        public void UpdateQuantity(long ProductId, int Quantity)
        {
            var _context = new TGDDContext();
            Product product = _context.Products.Find(ProductId);

            if(product!= null)
            {
                product.Stock -= Quantity;
                product.BuyingTimes += Quantity;
            } 
            _context.Entry(product).State = EntityState.Modified;

            _context.SaveChangesAsync(); 
        } 
    }
}
