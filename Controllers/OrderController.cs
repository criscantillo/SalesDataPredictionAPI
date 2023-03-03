using Microsoft.AspNetCore.Mvc;
using SalesDataPredictionAPI.Models.Repository;
using SalesDataPredictionAPI.Models.Data;

namespace SalesDataPredictionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository) => _orderRepository = orderRepository;

        [HttpGet("{custName}/{predict}")]
        [ActionName(nameof(GetOrdersPredictionsAsync))]
        public IEnumerable<OrderPrediction> GetOrdersPredictionsAsync(string custName, string predict)
        {
            return _orderRepository.GetOrderPredictionAsync(custName);
        }

        [HttpGet("{custId}")]
        [ActionName(nameof(GetOrdersByCustomerAsync))]
        public IEnumerable<Order> GetOrdersByCustomerAsync(int custId)
        {
            return _orderRepository.GetByCustomerAsync(custId);
        }

        [HttpGet]
        [ActionName(nameof(GetOrdersAsync))]
        public IEnumerable<Order> GetOrdersAsync()
        {
            return _orderRepository.GetAsync();
        }

        [HttpPost]
        [ActionName(nameof(CreateOrderAsync))]
        public async Task<ActionResult<Order>> CreateOrderAsync(Order order)
        {
            await _orderRepository.CreateAsync(order);
            return order;
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateOrder))]
        public async Task<ActionResult> UpdateOrder(int id, Order order)
        {
            if (id != order.Orderid)
                return BadRequest();

            await _orderRepository.UpdateAsync(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteOrder))]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = _orderRepository.GetByIdAsync(id);
            if (order == null)
                return NotFound();

            await _orderRepository.DeleteAsync(order);
            return NoContent();
        }
    }
}
