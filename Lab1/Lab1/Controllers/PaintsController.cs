using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Lab1.Services;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintsController : ControllerBase
    {

        private readonly AplicationDBContext _context;
        public PaintsController(AplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Paint>>> Get()
        {
            return Ok(await this._context.Gallery.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Paint>>> AddNewPaint(Paint paint)
        {

            //List<Paint> values = await this._context.Gallery.ToListAsync();
            //Console.WriteLine(values[0].Id);
            if (
                PaintsService.ValidateCode(paint.Code) ||
                PaintsService.ValidateSecondName(paint.ArtistSecondName) ||
                PaintsService.ValidatePaintName(paint.PaintName) ||
                PaintsService.ValidatePrice(paint.Price) ||
                PaintsService.ValidatePaintType(paint.PaintType)
                ) { 
                this._context.Gallery.Add(paint);
                await this._context.SaveChangesAsync();

                return Ok(await this._context.Gallery.ToListAsync());
            }
            throw new Exception("Post method error");
        }

        [HttpPut]
        public async Task<ActionResult<List<Paint>>> UpdatePaint(Paint paint)
        {
            this._context.Gallery.Update(paint);
            await this._context.SaveChangesAsync();

            return Ok(await this._context.Gallery.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Paint>>> DeletePaint(int id)
        {
            var DBpaint = await this._context.Gallery.FindAsync(id);
            if (DBpaint == null)
            {
                return BadRequest("Value is null");
            }
            this._context.Gallery.Remove(DBpaint);
            await this._context.SaveChangesAsync();
            return Ok(await this._context.Gallery.ToListAsync());
        }
    }
}
