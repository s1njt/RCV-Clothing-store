using RCVAPI4.Models.CartFolder;
using RCVAPI4.Models.ClotheFolder;
using RCVAPI4.Models.UserFolder;

namespace RCVAPI4.Models
{
    public class CartWithClothe
    {
       public Cart Cart { get; set; }
       public Clothe Clothe { get; set; }
    }
}
