using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RCVAPI4.Data;
using RCVAPI4.Models.ClotheFolder;
using RCVAPI4.Models.UserFolder;

namespace RCVAPI4.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly ClothesAPIDbContext dbContext;
        public UserController(ClothesAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await dbContext.Users.ToListAsync());

        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest addUserRequest)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                user_name = addUserRequest.user_name,
                user_surname = addUserRequest.user_surname,
                user_city = addUserRequest.user_city,
                user_nickname = addUserRequest.user_nickname,
                user_password = addUserRequest.user_password,
                user_email = addUserRequest.user_email,
                user_phone = addUserRequest.user_phone,

            };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UpdateUserRequest updateUserRequest)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user != null)
            {
                user.user_name = updateUserRequest.user_name;
                user.user_surname = updateUserRequest.user_surname;
                user.user_city = updateUserRequest.user_city;
                user.user_nickname = updateUserRequest.user_nickname;
                user.user_password = updateUserRequest.user_password;
                user.user_email = updateUserRequest.user_email;
                user.user_phone = updateUserRequest.user_phone;

                await dbContext.SaveChangesAsync();

                return Ok(user);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCLothe([FromRoute] Guid id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user != null)
            {
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Authenticate([FromBody] User user)
        {
            var useremail = user.user_email.ToString();
            var password = user.user_password.ToString();

            var existingUser = dbContext.Users.FirstOrDefault(u => u.user_email == useremail && u.user_password == password);

            if (existingUser != null)
            {
                return Ok(new { Message = "Authenticated successfully" });
            }
            else
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetUserByEmailAndPassword(string email, string password)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(u => u.user_email == email && u.user_password == password);

            if (existingUser != null)
            {
                return Ok(existingUser);
            }
            else
            {
                return NotFound();
            }
        }
    }
    
}
