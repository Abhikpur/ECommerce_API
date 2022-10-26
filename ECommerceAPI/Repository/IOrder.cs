using ECommerceAPI.Models;

namespace ECommerceAPI.Repository
{
    public interface IOrder
    {
        public string SaveOrderDetails(Order orderDetails);
        public string UpdateOrderDetails(Order orderDetails);
        public string DeleteOrderDetails(int OrderId);
        Order GetOrderDetails(int OrderId);
        List<Order> GetAllOrderDetails();
    }
}
