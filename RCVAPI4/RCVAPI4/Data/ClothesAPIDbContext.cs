using Microsoft.EntityFrameworkCore;
using RCVAPI4.Models.CartFolder;
using RCVAPI4.Models.ClotheFolder;
using RCVAPI4.Models.TicketsFolder;
using RCVAPI4.Models.UserFolder;

namespace RCVAPI4.Data
{
    public class ClothesAPIDbContext : DbContext
    {
        public ClothesAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Clothe> Clothes {  get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TicketC> TicketsT { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
