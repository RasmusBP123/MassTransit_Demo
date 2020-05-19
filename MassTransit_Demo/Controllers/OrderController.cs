using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace MassTransit_Demo.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IRequestClient<SubmitOrder> _orderRequestClient;

        public OrderController(IRequestClient<SubmitOrder> orderRequestClient)
        {
            _orderRequestClient = orderRequestClient;
        }

        [HttpPost()]
        public async Task<IActionResult> PostOrder(Guid id)
        {
            var (accepted, failed) = await _orderRequestClient.GetResponse<SubmittedOrderAccecpted, OrderRejected>(new 
            {
                Id = new Guid("A4E2B0EA-B04E-4AB7-AE75-35C3DC1EC157"),
                Name = "Donald Duck",
                InVar.Timestamp,
            });

            if (accepted.IsCompletedSuccessfully)
            {
                var response = await accepted;
                return Ok(response.Message);
            }
            else
            {
                var response = await failed;
                return BadRequest(response.Message);
            }
        }
    }
}