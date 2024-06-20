using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RCVAPI4.Data;
using RCVAPI4.Models;
using RCVAPI4.Models.CartFolder;
using RCVAPI4.Models.UserFolder;

namespace RCVAPI4.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class CartController : Controller
    {
        private readonly ClothesAPIDbContext dbContext;
        public CartController(ClothesAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarts()
        {
            return Ok(await dbContext.Carts.ToListAsync());

        }

       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartWithClothe>>> GetCartUser(string userId)
        {
            var cartWithClothe = await dbContext.Carts
                .Where(t => t.cart_user == userId)
                .Join(
                    dbContext.Clothes,
                    ticket => ticket.cart_clotheid,
                    clothe => clothe.Id.ToString(), // Преобразование к строке
                    (ticket, clothe) => new CartWithClothe
                    {
                        Cart = ticket,
                        Clothe = clothe
                    })
                .ToListAsync();

            if (cartWithClothe == null || !cartWithClothe.Any())
            {
                return NotFound();
            }

            return cartWithClothe;
        }

        [HttpPost]
        public async Task<IActionResult> AddCart(AddCartRequest addCartRequest)
        {
            var cart = new Cart()
            {
                Id = Guid.NewGuid(),
                cart_clotheid = addCartRequest.cart_clotheid,
                cart_user = addCartRequest.cart_user,
                cart_price = addCartRequest.cart_price
            };
            await dbContext.Carts.AddAsync(cart);
            await dbContext.SaveChangesAsync();

            return Ok(cart);
        }
    }

}
