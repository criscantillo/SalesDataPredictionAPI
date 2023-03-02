using Microsoft.AspNetCore.Mvc;
using SalesDataPredictionAPI.Models.Data;
using SalesDataPredictionAPI.Models.Repository;

namespace SalesDataPredictionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private IShipperRepository _shipperRepository;

        public ShipperController(IShipperRepository shipperRepository) => _shipperRepository = shipperRepository;

        [HttpGet]
        [ActionName(nameof(GetShippersAsync))]
        public IEnumerable<Shipper> GetShippersAsync()
        {
            return _shipperRepository.GetAsync();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetShipperById))]
        public ActionResult<Shipper> GetShipperById(int id)
        {
            var shipperById = _shipperRepository.GetByIdAsync(id);
            if (shipperById == null)
                return NotFound();

            return shipperById;
        }
    }
}
