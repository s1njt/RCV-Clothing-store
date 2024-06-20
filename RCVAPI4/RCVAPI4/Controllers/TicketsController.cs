using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RCVAPI4.Data;
using RCVAPI4.Models.TicketsFolder;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;
using RCVAPI4.Models;
using RCVAPI4.Models.ClotheFolder;

namespace RCVAPI4.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TicketsController : Controller
    {
        private readonly ClothesAPIDbContext dbContext;
        public TicketsController(ClothesAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            return Ok(await dbContext.TicketsT.ToListAsync());

        }
        [HttpPost]
        public async Task<IActionResult> AddTicket(TicketCAddRequest addTicketRequest)
        {
            var ticket = new TicketC()
            {
                Id = Guid.NewGuid(),
                ticket_acceptUserId = addTicketRequest.ticket_acceptUserId,
                ticket_productsId = addTicketRequest.ticket_productsId,
                ticket_contactNumber = addTicketRequest.ticket_contactNumber,
                ticket_createDate = addTicketRequest.ticket_createDate,
                ticket_deliveryDate = addTicketRequest.ticket_deliveryDate,
                ticket_deliveryAdress = addTicketRequest.ticket_deliveryAdress,
                ticket_deliveryStatus = addTicketRequest.ticket_deliveryStatus,
                ticket_sum = addTicketRequest.ticket_sum

            };
            await dbContext.TicketsT.AddAsync(ticket);
            await dbContext.SaveChangesAsync();

            return Ok(ticket);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTicket([FromRoute] Guid id, TicketCUpdateRequest updateTicketRequest)
        {
            var ticket = await dbContext.TicketsT.FindAsync(id);
            if (ticket != null)
            {
                ticket.ticket_acceptUserId = updateTicketRequest.ticket_acceptUserId;
                ticket.ticket_productsId = updateTicketRequest.ticket_productsId;
                ticket.ticket_contactNumber = updateTicketRequest.ticket_contactNumber;
                ticket.ticket_createDate = updateTicketRequest.ticket_createDate;
                ticket.ticket_deliveryDate = updateTicketRequest.ticket_deliveryDate;
                ticket.ticket_deliveryAdress = updateTicketRequest.ticket_deliveryAdress;
                ticket.ticket_deliveryStatus = updateTicketRequest.ticket_deliveryStatus;
                ticket.ticket_sum = updateTicketRequest.ticket_sum;

                await dbContext.SaveChangesAsync();

                return Ok(ticket);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] Guid id)
        {
            var ticket = await dbContext.TicketsT.FindAsync(id);
            if (ticket != null)
            {
                dbContext.Remove(ticket);
                await dbContext.SaveChangesAsync();
                return Ok(ticket);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketWithClothe>>> GetTicketsWithClotheForUser(string userId)
        {
            var ticketsWithClothe = await dbContext.TicketsT
                .Where(t => t.ticket_acceptUserId == userId)
                .Join(
                    dbContext.Clothes,
                    ticket => ticket.ticket_productsId,
                    clothe => clothe.Id.ToString(), // Преобразование к строке
                    (ticket, clothe) => new TicketWithClothe
                    {
                        Ticket = ticket,
                        Clothe = clothe
                    })
                .ToListAsync();

            if (ticketsWithClothe == null || !ticketsWithClothe.Any())
            {
                return NotFound();
            }

            return ticketsWithClothe;
        }
    }
}
