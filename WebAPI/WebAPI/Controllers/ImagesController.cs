using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ActionModels.FilesMGT;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly TGDDContext _context;

        public ImagesController(TGDDContext context)
        {
            _context = context;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            return await _context.Images.ToListAsync();
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(long id)
        {
            var image = await _context.Images.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }

        // PUT: api/Images/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImage(long id, Image image)
        {
            if (id != image.Id)
            {
                return BadRequest();
            }

            _context.Entry(image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Images
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<List<Uri>>> PostImage(List<IFormFile> files)
        { 
            List<Uri> urls = new List<Uri>(); 

            foreach(IFormFile formFile in files)
            {
                var fileUpload = new FilesUpload(formFile);

                Uri tmpUrl = await fileUpload.Excute();

                urls.Add(tmpUrl); 
            }

            return urls;
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Image>> DeleteImage(long id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return image;
        }

        private bool ImageExists(long id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}
