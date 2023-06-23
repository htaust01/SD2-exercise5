using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
	public class OrderRepository : IOrderRepository
	{
		private readonly ProductContext _dbContext;

		public OrderRepository()
		{
			_dbContext = new ProductContext();
		}

		public void AddOrder(Order order)
		{
			_dbContext.Orders.Add(order);
			_dbContext.SaveChanges();
		}

		public Order GetOrder(int orderId)
		{
			return _dbContext.Orders.Include(x => x.Products).SingleOrDefault(x => x.OrderId == orderId);
		}

        public List<Order> GetAllOrders()
        {
            return _dbContext.Orders.ToList();
        }
    }
}

