using SalesDataPredictionAPI.Models.Data;

namespace SalesDataPredictionAPI.Models.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAsync();
        Product GetByIdAsync(int id);
    }
}
