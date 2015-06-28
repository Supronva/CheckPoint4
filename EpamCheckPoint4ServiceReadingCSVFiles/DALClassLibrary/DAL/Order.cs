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
        DBServiceEntities _dbServiceEntities = new DBServiceEntities();

        public Manager IdManager { get; set; }
        public Client IdClient { get; set; }
        public Product IdProduct { get; set; }
        public double Sum { get; set; }
        public DateTime Date { get; set; }

        public Order(Manager idmanager, Client idclient, Product idproduct, double sum, DateTime date)
        {
            IdManager = idmanager;
            IdClient = idclient;
            IdProduct = idproduct;
            Sum = sum;
            Date = date;
        }

        public Orders ConvertToEntity()
        {
            if (_dbServiceEntities != null)
            {
                var entity =
                    _dbServiceEntities.Orders.FirstOrDefault(
                        x =>
                            x.idmanager == IdManager.ConvertToEntity().id && x.idclient == IdClient.ConvertToEntity().id &&
                            x.idproduct == IdProduct.ConvertToEntity().id && x.sum == Sum && x.date == Date);
                if (entity != null)
                {
                    return entity;
                }
            }
            var orders = new Orders()
            {
                idmanager = IdManager.ConvertToEntity().id,
                idclient = IdClient.ConvertToEntity().id,
                idproduct = IdProduct.ConvertToEntity().id,
                sum = Sum,
                date = Date
            };
            return orders;
        }
    }
}
