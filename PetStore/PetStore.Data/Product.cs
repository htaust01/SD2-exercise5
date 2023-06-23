using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public class Product
    {
        public decimal Price { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }
        public int ProductId { get; set; }
    }
}

// {"Price":1.00,"Name":"DogDoo","Quantity":9,"Description":"Some dog poopy"}
// {"Price":1.00,"Name":"DogDoo","Quantity":9,"Description":"Some dog poopy", "OrderId":1}
// {"ProductId": 2, "Name": "Dog bowl", "Description": "A thing that holds food", "Price": 8.99}
