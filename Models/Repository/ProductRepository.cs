using SalesDataPredictionAPI.Models.Data;

namespace SalesDataPredictionAPI.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected readonly SalesDataDBContext _dbContext;
        public ProductRepository(SalesDataDBContext dbContext) => _dbContext = dbContext;
        public IEnumerable<Product> GetAsync()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetByIdAsync(int id)
        {
            return _dbContext.Products.Where(s => s.Productid == id).First();
        }
    }
}
