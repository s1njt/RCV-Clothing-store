using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerRCV.Model
{
    public class Ticket
    {
        public Guid Id { get; set; }
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
