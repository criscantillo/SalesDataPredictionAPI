using Microsoft.EntityFrameworkCore;
using SalesDataPredictionAPI.Models.Data;

namespace SalesDataPredictionAPI.Models.Repository
{
    public class OrderDetailRepository : IOrderDatailRepository
    {
        protected readonly SalesDataDBContext _dbContext;
        public OrderDetailRepository(SalesDataDBContext dbContext) => _dbContext = dbContext;
        public async Task<OrderDetail> CreateAsync(OrderDetail orderDetail)
        {
            await _dbContext.Set<OrderDetail>().AddAsync(orderDetail);
            await _dbContext.SaveChangesAsync();
            return orderDetail;
        }

        public async Task<bool> UpdateAsync(OrderDetail orderDetail)
        {
            _dbContext.Entry(orderDetail).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(OrderDetail orderDetail)
        {
            if (orderDetail is null)
                return false;

            _dbContext.Set<OrderDetail>().Remove(orderDetail);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public IEnumerable<OrderDetail> GetAsync(int id)
        {
            return _dbContext.OrderDetails
                .Where(od => od.Orderid == id);
        }
    }
}
