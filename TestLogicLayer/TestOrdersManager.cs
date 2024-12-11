using ILogicLayer;
using LogicLayer;
using IDataAcessLayer;
using FakeDataAccessLayer;
using DataObjectLayer;
namespace TestLogicLayer 
{
    public class TestOrdersManager
    {
        private static IOrdersAccessor ordersAccessor = new OrdersAccessor();
        private IOrdersManager ordersManager = new OrdersManager(ordersAccessor);
        [Fact]
        public void TestAddOrder()
        {
            Order order = new();
            order.ProductName = "Test";
            order.CustomerName = "Test";
            order.TableNumber = 1;
            Assert.True(ordersManager.addOrder(order));
        }
        [Fact]
        public void TestGetAllOrders()
        {
            Assert.Equal(5,ordersManager.getAllOrders().Count);
        }
    }
}

