using SalesDataPredictionAPI.Models.Data;

namespace SalesDataPredictionAPI.Models.Repository
{
    public class ShipperRepository : IShipperRepository
    {
        protected readonly SalesDataDBContext _dbContext;
        public ShipperRepository(SalesDataDBContext dbContext) => _dbContext = dbContext;
        public IEnumerable<Shipper> GetAsync()
        {
            return _dbContext.Shippers.ToList();
        }

        public Shipper GetByIdAsync(int id)
        {
            return _dbContext.Shippers.Where(s => s.Shipperid == id).First();
        }
    }
}
