using System;
namespace PetStore.Data
{
	public interface IOrderRepository
	{
		void AddOrder(Order order);
		Order GetOrder(int orderId);
		public List<Order> GetAllOrders();

    }
}

