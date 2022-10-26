using ECommerceAPI.Data;
using ECommerceAPI.Models;

namespace ECommerceAPI.Repository
{
    public class CartRepository:ICart
    {
        private ECommerceDbContext _eCommerceDbContext;
        public CartRepository(ECommerceDbContext eCommerceDbContext)
        {
            _eCommerceDbContext = eCommerceDbContext;
        }
        public string DeleteCart(int CartId)
        {
            try
            {
                string msg = "";
                Cart deleteCart = _eCommerceDbContext.Cart.Find(CartId);
                if (deleteCart != null)
                {
                    _eCommerceDbContext.Cart.Remove(deleteCart);
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

        public List<Cart> GetAllCart()
        {
            try
            {
                List<Cart> carts = _eCommerceDbContext.Cart.ToList();
                return carts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cart GetCart(int CartId)
        {
            try
            {
                Cart carts = _eCommerceDbContext.Cart.Find(CartId);
                return carts;
            }
            catch (Exception)
            {
                throw;
            }          
        }

        public string SaveCart(Cart cart)
        {
            try
            {
                _eCommerceDbContext.Cart.Add(cart);
                _eCommerceDbContext.SaveChanges();
                return "Saved"; ;
            }
            catch (Exception)
            {
                throw;
            }         
        }

        public string UpdateCart(Cart cart)
        {
            try
            {
                _eCommerceDbContext.Entry(cart).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _eCommerceDbContext.SaveChanges();
                return "Updated";
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public IEnumerable<Cart> GetCartByUserID(int UserId)
        {
            try
            {
                var cart = _eCommerceDbContext.Cart.Where(a => a.UserId == UserId).ToList();
                return cart;
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public int GetCartId(int UserId)
        {
            try
            {
                Cart cart = _eCommerceDbContext.Cart.FirstOrDefault(q => q.UserId == UserId);
                int CartId = cart.CartId;
                return CartId;
            }
            catch (Exception)
            {
                throw;
            }          
        }
    }
}
