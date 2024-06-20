namespace RCVAPI4.Models.TicketsFolder
{
    public class TicketCUpdateRequest
    {
        public string ticket_acceptUserId { get; set; }
        public string ticket_productsId { get; set; }
        public string ticket_contactNumber { get; set; }
        public DateTime ticket_createDate { get; set; }
        public DateTime ticket_deliveryDate { get; set; }
        public string ticket_deliveryAdress { get; set; }
        public string ticket_deliveryStatus { get; set; }
        public int ticket_sum { get; set; }
    }
}
