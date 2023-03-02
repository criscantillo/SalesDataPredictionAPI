using SalesDataPredictionAPI.Models.Data;

namespace SalesDataPredictionAPI.Models.Repository
{
    public interface IOrderDatailRepository
    {
        IEnumerable<OrderDetail> GetAsync(int id);
        Task<OrderDetail> CreateAsync(OrderDetail orderDetail);
        Task<bool> UpdateAsync(OrderDetail orderDetail);
        Task<bool> DeleteAsync(OrderDetail orderDetail);
    }
}
