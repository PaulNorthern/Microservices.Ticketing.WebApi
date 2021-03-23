using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MassTransit;
using Shared.Models;

namespace Ticketing.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly IBus _bus;
        public TicketController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                ticket.BookedOn = DateTime.Now;
                //  name our Queue as ticketQueue
                Uri uri = new Uri("rabbitmq://localhost/ticketQueue");
                //  an endpoint to which we can send the shared model object.
                var endPoint = await _bus.GetSendEndpoint(uri);
                //  push the message to the queue
                await endPoint.Send(ticket);
                return Ok();
            }
            return BadRequest();
        }
    }
}
