using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel;

namespace DALClassLibrary.DAL
{
    public class Order
    {
        private readonly ModelContainer _dbServiceEntities = new ModelContainer();
        
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public Product Product { get; set; }
        public Manager Manager { get; set; }
        public float Sum { get; set; }
        
        public Order(DateTime date, Client client, Product product, Manager manager, float sum)
        {
            Date = date;
            Client = client;
            Product = product;
            Manager = manager;
            Sum = sum;
        }

        public Orders ConvertToEntity()
        {
            var orders = new Orders()
            {
                manager = Manager.ConvertToEntity().id,
                client = Client.ConvertToEntity().id,
                product = Product.ConvertToEntity().id,
                sum = Sum,
                date = Date
            };
            return orders;
        }
    }
}
