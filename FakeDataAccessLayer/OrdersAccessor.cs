using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
using IDataAcessLayer;

namespace FakeDataAccessLayer
{
    public class OrdersAccessor : IOrdersAccessor
    {
        private List<Order> orders = [];

        public OrdersAccessor() 
        {
            addFiveSamplesOrders();
        }

        private void addFiveSamplesOrders()
        {
            for (int i = 1; i < 6; i++)
            {
                Order order = new();
                order.ProductName = "prod" + i;
                order.CustomerName = "customer" + i;
                order.TableNumber = i;
                orders.Add(order);
            }
            
        }

        public bool insertOrder(Order order)
        {
            int prev = orders.Count;
            orders.Add(order);
            return orders.Count - prev == 1;
        }

        public List<Order> selectAllOrders()
        {
            return orders;
        }
    }
}
