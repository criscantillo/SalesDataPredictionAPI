using SalesDataPredictionAPI.Models.Data;

namespace SalesDataPredictionAPI.Models.Repository
{
    public interface IShipperRepository
    {
        IEnumerable<Shipper> GetAsync();
        Shipper GetByIdAsync(int id);
    }
}
