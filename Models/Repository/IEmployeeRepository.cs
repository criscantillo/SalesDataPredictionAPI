using SalesDataPredictionAPI.Models.Data;

namespace SalesDataPredictionAPI.Models.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAsync();
        Employee GetByIdAsync(int id);
    }
}
