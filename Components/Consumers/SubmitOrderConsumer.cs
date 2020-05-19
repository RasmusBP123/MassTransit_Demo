using Contracts;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Components
{
    public class SubmitOrderConsumer : IConsumer<SubmitOrder>
    {
        public async Task Consume(ConsumeContext<SubmitOrder> context)
        {

            if (context.Message.Name.Contains("Fu"))
            {
                await context.RespondAsync<OrderRejected>(new
                {
                    Reason = "It did not work"
                });
                return;
            }

            await context.Publish<OrderSubmitted>(new 
            {
                OrderId = context.Message.Id,
                TimeStamp = context.Message.Timestamp,
                Name = context.Message.Name
            });

            await context.RespondAsync<SubmittedOrderAccecpted>(new
            {
                InVar.Id,
                context.Message.Name,
                InVar.Timestamp
            });
        }
    }
}
