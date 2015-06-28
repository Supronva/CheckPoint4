using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALClassLibrary.DAL;
using EntityModel;

namespace DALClassLibrary
{
    public class OrdersRepository : ICollection<Order>
    {
        public  readonly ICollection<Order> _orderlist = new List<Order>();

        public readonly ModelContainer _dbServiceEntities = new ModelContainer();

        public void Add(Order item)
        {
            _orderlist.Add(item);
        }

        public void Clear()
        {
           _orderlist.Clear();
        }

        public bool Contains(Order item)
        {
            return _orderlist.Contains(item);
        }

        public void CopyTo(Order[] array, int arrayIndex)
        {
            _orderlist.CopyTo(array,arrayIndex);
        }

        public int Count
        {
            get { return _orderlist.Count; }
        }

        public bool IsReadOnly
        {
            get { return _orderlist.IsReadOnly; }
        }

        public bool Remove(Order item)
        {
           return _orderlist.Remove(item);
        }

        public IEnumerator<Order> GetEnumerator()
        {
            return _orderlist.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
           return this.GetEnumerator();
        }

        public void SaveOrders()
        {
            var list = _orderlist.Select(order => order.ConvertToEntity()).ToList();
            _dbServiceEntities.Orders.AddRange(list);
            _dbServiceEntities.SaveChanges();
        }
    }
}
