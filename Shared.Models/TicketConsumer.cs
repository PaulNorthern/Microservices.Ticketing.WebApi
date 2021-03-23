using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MassTransit;

namespace Shared.Models
{
    public class TicketConsumer : IConsumer<Ticket>
    {
        public async Task Consume(ConsumeContext<Ticket> context)
        {
            var data = context.Message;
            //Validate the Ticket Data
            //Store to Database
            //Notify the user via Email / SMS
        }
    }
}
