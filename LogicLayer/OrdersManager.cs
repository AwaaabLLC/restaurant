using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
using DataAccessLayer;
using ILogicLayer;
using IDataAcessLayer;

namespace LogicLayer
{
    public class OrdersManager : IOrdersManager
    {
        private IOrdersAccessor ordersAccessor;
        public OrdersManager() 
        { 
            ordersAccessor = new OrdersAccessor();
        }
        public bool addOrder(Order order)
        {
            bool result = false;
            try
            {
                result = ordersAccessor.insertOrder(order);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public List<Order> getAllOrders()
        {
            List<Order> orders = [];
            try
            {
                orders = ordersAccessor.selectAllOrders();
            }
            catch (Exception)
            {

                throw;
            }
            return orders;  
        }
    }
}
