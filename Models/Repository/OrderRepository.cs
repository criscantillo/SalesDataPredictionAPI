using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SalesDataPredictionAPI.Models.Data;
using System.Net;
using System.Net.Sockets;

namespace SalesDataPredictionAPI.Models.Repository
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly SalesDataDBContext _dbContext;
        public OrderRepository(SalesDataDBContext dbContext) => _dbContext = dbContext;
        public async Task<Order> CreateAsync(Order order)
        {
            await _dbContext.Set<Order>().AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<bool> UpdateAsync(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Order order)
        {
            if (order is null)
                return false;

            _dbContext.Set<Order>().Remove(order);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public IEnumerable<Order> GetAsync()
        {
            return _dbContext.Orders
                .OrderByDescending(x => x.Orderdate)
                .Take(200)
                .ToList();
        }

        public IEnumerable<Order> GetByCustomerAsync(int custId)
        {
            return _dbContext.Orders
                .Where(o => o.Custid == custId)
                .OrderByDescending(x => x.Orderdate)
                .ToList();
        }

        public Order GetByIdAsync(int id)
        {
            return _dbContext.Orders
                .Where(o => o.Orderid == id).First();
        }

        public IEnumerable<OrderPrediction> GetOrderPredictionAsync(string custName)
        {
            string SQL = @"SELECT ROW_NUMBER() OVER(ORDER BY c.companyname ASC) AS Id
                                , c.custId
                                , c.companyname CustomerName
	                            , FORMAT(LastOrderDate, 'M-d-yyyy') LastOrderDate
	                            , FORMAT(NextPredictedOrder, 'M-d-yyyy') NextPredictedOrder
	                            , AvgDays
                            FROM
                            (
	                            SELECT custid
		                            , MAX(NextDate) LastOrderDate
		                            , AVG(diffDays) AvgDays
		                            , DATEADD(DAY, AVG(diffDays), MAX(NextDate)) NextPredictedOrder
	                            FROM
	                            (
		                            SELECT orderdate
			                            , DATEDIFF(DAY, orderdate, LEAD(orderdate) OVER (ORDER BY custid, orderid ASC)) diffDays
			                            , LEAD(orderdate) OVER (ORDER BY custid, orderid ASC) NextDate
			                            , orderid
			                            , custid
		                            FROM Sales.Orders
	                            ) AS so
	                            WHERE diffDays > 0
	                            GROUP BY custid
                            ) AS so
	                            INNER JOIN Sales.Customers c ON so.custid = c.custid
                            {0}
                            ";

            if (custName != "all")
                SQL = string.Format(SQL, "WHERE c.companyname LIKE '%' + @custName + '%'");
            else
                SQL = string.Format(SQL, "");

            return _dbContext.OrderPredictions
                .FromSqlRaw(SQL, new SqlParameter("@custName", custName)).ToList();
        }
    }
}
