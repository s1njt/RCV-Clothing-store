using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RCVAPI4.Data;
using RCVAPI4.Models.ClotheFolder;

namespace RCVAPI4.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CLothesController : Controller
    {
        private readonly ClothesAPIDbContext dbContext;
        public CLothesController(ClothesAPIDbContext dbContext) 
        { 
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetClothes()
        {
           return Ok(await dbContext.Clothes.ToListAsync());
            
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetClothe([FromRoute] Guid id)
        {
            var clothe = await dbContext.Clothes.FindAsync(id);

            if(clothe == null)
            {
                return NotFound();
            }
            return Ok(clothe);
        }

        [HttpPost]
        public async Task<IActionResult> AddClothe(AddClotheRequest addClotheRequest)
        {
            var clothe = new Clothe()
            {
                Id = Guid.NewGuid(),
                clothe_name = addClotheRequest.clothe_name,
                clothe_price = addClotheRequest.clothe_price,
                clothe_size = addClotheRequest.clothe_size,
                clothe_description = addClotheRequest.clothe_description,
                clothe_image = addClotheRequest.clothe_image,
                clothe_color = addClotheRequest.clothe_color,
                clothe_textile = addClotheRequest.clothe_textile,
                clothe_type = addClotheRequest.clothe_type

            };
           await dbContext.Clothes.AddAsync(clothe);
            await dbContext.SaveChangesAsync();

            return Ok(clothe);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateClothe([FromRoute] Guid id, UpdateClotheRequest updateClotheRequest)
        {
            var clothe = await dbContext.Clothes.FindAsync(id);
            if(clothe != null)
            {
                clothe.clothe_name = updateClotheRequest.clothe_name;
                clothe.clothe_price = updateClotheRequest.clothe_price;
                clothe.clothe_size = updateClotheRequest.clothe_size;
                clothe.clothe_description = updateClotheRequest.clothe_description;
                clothe.clothe_image = updateClotheRequest.clothe_image;
                clothe.clothe_color = updateClotheRequest.clothe_color;
                clothe.clothe_textile = updateClotheRequest.clothe_textile;
                clothe.clothe_type = updateClotheRequest.clothe_type;
                await dbContext.SaveChangesAsync();

                return Ok(clothe );
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCLothe([FromRoute] Guid id)
        {
           var clothe = await dbContext.Clothes.FindAsync(id);
            if (clothe != null) 
            {
                dbContext.Remove(clothe);
                await dbContext.SaveChangesAsync();
                return Ok(clothe);
            }
            return NotFound();
        }
    }
}
