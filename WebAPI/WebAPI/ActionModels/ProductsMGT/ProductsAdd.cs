using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOModels;
//using WebAPI.Models;

namespace WebAPI.ActionModels.ProductMGT
{
    public class ProductsAdd
    {
        public ProductDTO product { get; set; }
        //public static async Task<ActionResult<Products>> addProduct()
        //{

        //    var _context = new TGDDContext();
        //    var newProductId = _context.Products.Max(p => p.Id) + 1;
        //    var newImageId = _context.Images.Max(p => p.Id) + 1;
        //    var newDescriptId = _context.Descriptions.Max(d => d.Id) + 1;

        //    product.Id = newProductId;

        //    product.Brand = null;
        //    product.Category = null;
        //    product.OrderDetails = null;

        //    foreach (Descriptions item in product.Descriptions)
        //    {
        //        item.Id = newDescriptId;
        //        item.ProductId = newProductId;
        //    }


        //    foreach (Images item in product.Images)
        //    {
        //        item.Id = newImageId;
        //        newImageId++;

        //        item.ProductId = newProductId;
        //    }

        //    _context.Products.Add(product);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ProductsExists(product.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return CreatedAtAction("GetProducts", new { id = product.Id }, product);
        //}
    }
}
