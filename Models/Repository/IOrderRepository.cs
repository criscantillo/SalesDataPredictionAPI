using SalesDataPredictionAPI.Models.Data;
using System.Net.Sockets;

namespace SalesDataPredictionAPI.Models.Repository
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
        Task<bool> UpdateAsync(Order order);
        Task<bool> DeleteAsync(Order order);
        IEnumerable<Order> GetAsync();
        IEnumerable<Order> GetByCustomerAsync(int custId);
        Order GetByIdAsync(int id);
        IEnumerable<OrderPrediction> GetOrderPredictionAsync(string custName = "*");
    }
}
