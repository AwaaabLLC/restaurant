using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;

namespace IDataAcessLayer
{
    public interface IOrdersAccessor
    {
        bool insertOrder(Order order);
        List<Order> selectAllOrders();
    }
}
