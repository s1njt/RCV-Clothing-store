using RCVAPI4.Models.TicketsFolder;
using RCVAPI4.Models.ClotheFolder;
namespace RCVAPI4.Models
{
    public class TicketWithClothe
    {
        public TicketC Ticket { get; set; }
        public Clothe Clothe { get; set; }
    }
}
