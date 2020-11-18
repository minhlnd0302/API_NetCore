﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPI.DTOModels;
using WebAPI.Models;
using WebAPI.ActionModels;
using WebAPI.ActionModels.ProductMGT;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private TGDDContext _context;

        public ProductsController(TGDDContext context)
        {
            _context = context;
        }

        // GET: get all Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var product = new ProductsGetAll();

            return await product.Excute();
        }

        [HttpGet("test")]
        public async Task<ActionResult<JsonArrayAttribute>> Products()
        {
            var products = _context.Products.Include(p => p.Images).ThenInclude(i => i.Url)
                                            .Include(p => p.Descriptions)
                                            .Include(p => p.Category).ThenInclude(c => c.Name)
                                            .Include(p => p.Brand).ThenInclude(b => b.Name);




            var tmp = await products.ToListAsync();

            //return JsonConvert.DeserializeObject(tmp);

            return Ok(tmp);
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

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        // edit/update product
        [Authorize(Roles = "0")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(long id, ProductDTO product)
        {
            //if (id != products.Id)
            //{
            //    return BadRequest();
            //}
            var pro = new Product();



            _context.Entry(pro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        // add product
        [Authorize(Roles = "0")]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProducts(Product product)
        {
            var newProductId = _context.Products.Max(p => p.Id) + 1;
            var newImageId = _context.Images.Max(p => p.Id) + 1;
            var newDescriptId = _context.Descriptions.Max(d => d.Id) + 1;

            product.Id = newProductId;

            product.Brand = null;
            product.Category = null;
            product.OrderDetails = null;

            foreach (Description item in product.Descriptions)
            {
                item.Id = newDescriptId;
                item.ProductId = newProductId;
            }


            foreach (Image item in product.Images)
            {
                item.Id = newImageId;
                newImageId++;

                item.ProductId = newProductId;
            }

            _context.Products.Add(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductsExists(product.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetProducts", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [Authorize(Roles = "0")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProducts(long id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool ProductsExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}