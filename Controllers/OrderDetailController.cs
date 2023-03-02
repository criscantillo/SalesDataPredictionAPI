using Microsoft.AspNetCore.Mvc;
using SalesDataPredictionAPI.Models.Data;
using SalesDataPredictionAPI.Models.Repository;

namespace SalesDataPredictionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : Controller
    {
        private IOrderDatailRepository _orderDetailRepository;

        public OrderDetailController(IOrderDatailRepository orderDetailRepository) 
            => _orderDetailRepository = orderDetailRepository;

        [HttpGet("{id}")]
        [ActionName(nameof(GetOrdersDetailAsync))]
        public IEnumerable<OrderDetail> GetOrdersDetailAsync(int id)
        {
            return _orderDetailRepository.GetAsync(id);
        }

        [HttpPost]
        [ActionName(nameof(CreateOrderDetailAsync))]
        public async Task<ActionResult<OrderDetail>> CreateOrderDetailAsync(OrderDetail orderDetail)
        {
            await _orderDetailRepository.CreateAsync(orderDetail);
            return orderDetail;
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateOrderDetial))]
        public async Task<ActionResult> UpdateOrderDetial(int id, OrderDetail orderDetail)
        {
            if (id != orderDetail.Orderid)
                return BadRequest();

            await _orderDetailRepository.UpdateAsync(orderDetail);
            return NoContent();
        }
    }
}
