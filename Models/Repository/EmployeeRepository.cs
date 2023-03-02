using SalesDataPredictionAPI.Models.Data;

namespace SalesDataPredictionAPI.Models.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly SalesDataDBContext _dbContext;
        public EmployeeRepository(SalesDataDBContext dbContext) => _dbContext = dbContext;
        public IEnumerable<Employee> GetAsync()
        {
            return _dbContext.Employees.Select(e => new Employee
            {
                Empid= e.Empid,
                FullName = $"{e.Firstname} {e.Lastname}",
            }).ToList();
        }

        public Employee GetByIdAsync(int id)
        {
            return _dbContext.Employees.Select(e => new Employee
                {
                    Empid = e.Empid,
                    FullName = $"{e.Firstname} {e.Lastname}",
                })
                .Where(e => e.Empid == id).First();
        }
    }
}
