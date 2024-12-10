using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
namespace ILogicLayer
{
    public interface IOrdersManager
    {
        bool addOrder(Order order);
        List<Order> getAllOrders();
    }
}
