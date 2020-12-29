using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPI.DTOModels;
using WebAPI.Models;
using WebAPI.ActionModels;
using WebAPI.ActionModels.ProductMGT;
using System.IO;
using Azure.Storage.Blobs;
using Azure.Storage;
using WebAPI.ActionModels.ProductsMGT;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private TGDDContext _context;

        public ProductsController(TGDDContext context)
        {
            //string tmp = SecurityUtils.CreateMD5("testtest");

            _context = context;
        }

        // GET: get all Products
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var product = new ProductsGetAll();

            return await product.Excute();
        } 

         

        // lay thông tin product = Id
        [HttpGet("{ProductId}")]
        public async Task<ActionResult<Product>> GetProduct(long ProductId)
        {
            //var product = await _context.Products.Include(p => p.Brand)
            //                                .Include(p => p.Category)
            //                                .Include(p => p.Descriptions)
            //                                .Include(p => p.Comments)
            //                                .Include(p=>p.Images)
            //                                .FirstOrDefaultAsync(product => product.Id == idProduct);

            //if (product == null)
            //{
            //    return NotFound("Không tìm thấy sẳn phẩm này !");
            //}

            //return product;
            var tmp = new ProductsGetById();
            tmp.ProductId = ProductId;

            return await tmp.Excute();
        }

   
        // edit/update product
        [Authorize(Roles = "0")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(long id,ProductDTO product)
        {
            ProductsUpdate productsUpdate = new ProductsUpdate { id = id, ProductDTO = product };

            return await productsUpdate.Excute();

        }

     

        // add product
        [Authorize(Roles = "0")]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProducts(ProductDTO productDTO)
        {
            ProductsCreate productsCreate = new ProductsCreate { productDTO = productDTO };
            return await productsCreate.Excute();
        }

        // DELETE: api/Products/5
        [Authorize(Roles = "0")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProducts(long id)
        {
            ProductsDelete productsDelete = new ProductsDelete { ProductId = id };

            return await productsDelete.Excute();
        }

        private bool ProductsExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
