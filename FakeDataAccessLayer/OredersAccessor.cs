using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
using IDataAcessLayer;

namespace FakeDataAccessLayer
{
    public class OredersAccessor : IOrdersAccessor
    {
        public bool insertOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> selectAllOrders()
        {
            throw new NotImplementedException();
        }
    }
}
