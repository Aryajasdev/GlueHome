using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GlueHome.Domain.DeliveryServices;
using GlueHome.Model.Delivery;
using GlueHome.Model.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GlueHome.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        private readonly ILogger<DeliveryController> _logger;

        public DeliveryController(IDeliveryService deliveryService, ILogger<DeliveryController> logger)
        {
            _deliveryService = deliveryService;
            _logger = logger;
        }

        // GET: api/Delivery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryView>>> GetDeliveries()
        {
            var deliveries = await _deliveryService.GetDeliveries();
            _logger.LogInformation("Delivery received from database");
            return Ok(deliveries);
        }

        // GET: api/Delivery/5
        [HttpGet("{id}")]        
        public async Task<ActionResult<DeliveryView>> GetDelivery(int id)
        {
            var delivery = await _deliveryService.GetDelivery(id);
            _logger.LogInformation($"Delivery received from database for {id}");

            if (delivery == null)
            {
                return NotFound();
            }

            return delivery;
        }

        // POST: api/Delivery      
        [HttpPost]
        public async Task<ActionResult<DeliveryView>> PostDelivery(Delivery delivery)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Delivery sent bad request {delivery.Id}");
                return BadRequest();
            }

            _logger.LogInformation($"Delivery inserted from database for {delivery.Id}");
            await _deliveryService.InsertDelivery(delivery);

            return await GetDelivery(delivery.Id);
        }

        // DELETE: api/Delivery/5      
        [HttpPut("{id}")]
        public async Task<ActionResult<DeliveryView>> UpdateDelivery(int id, int status)
        {
            var delivery = await _deliveryService.UpdateDelivery(id, (DeliveryStatus)status);
            _logger.LogInformation($"Delivery {delivery.Id} updated with {Enum.GetName(typeof(DeliveryStatus), status)}");
            return await GetDelivery(delivery.Id);
        }
    }
}
