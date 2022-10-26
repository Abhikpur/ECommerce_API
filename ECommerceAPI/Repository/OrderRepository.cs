using ECommerceAPI.Data;
using ECommerceAPI.Models;

namespace ECommerceAPI.Repository
{
    public class OrderRepository: IOrder
    {
        private ECommerceDbContext _eCommerceDbContext;
        public OrderRepository(ECommerceDbContext eCommerceDbContext)
        {
            _eCommerceDbContext = eCommerceDbContext;
        }
        public string DeleteOrderDetails(int OrderId)
        {
            try
            {
                string msg = "";
                Order deleteOrder = _eCommerceDbContext.Order.Find(OrderId);
                if (deleteOrder != null)
                {
                    _eCommerceDbContext.Order.Remove(deleteOrder);
                    _eCommerceDbContext.SaveChanges();
                    msg = "Deleted";
                }
                return msg;
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public List<Order> GetAllOrderDetails()
        {
            try
            {
                List<Order> order = _eCommerceDbContext.Order.ToList();
                return order;
            }
            catch(Exception)
            {
                throw;
            }           
        }

        public Order GetOrderDetails(int OrderId)
        {
            try
            {
                Order order = _eCommerceDbContext.Order.Find(OrderId);
                return order;
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public string SaveOrderDetails(Order orderDetails)
        {
            try
            {
                _eCommerceDbContext.Order.Add(orderDetails);
                _eCommerceDbContext.SaveChanges();
                return "Saved";
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public string UpdateOrderDetails(Order orderDetails)
        {
            try
            {
                _eCommerceDbContext.Entry(orderDetails).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _eCommerceDbContext.SaveChanges();
                return "Updated";
            }
            catch (Exception)
            {
                throw;
            }          
        }
    }
}
