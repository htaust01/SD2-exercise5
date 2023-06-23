using System;
using System.Collections.Generic;

namespace PetStore.Data
{
	public class Order
	{
		public int OrderId { get; set; }

		public DateTime OrderDate { get; set; }

		public ICollection<Product> Products { get; set; }
	}
}

// { "Products": [ {"ProductId":1,"Price":1.00,"Name":"DogDoo","Description":"Some dog poopy"} ] }