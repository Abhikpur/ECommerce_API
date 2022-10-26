using ECommerceAPI.Models;
using ECommerceAPI.Repository;

namespace ECommerceAPI.Services
{
    public class CartServices
    {

        private ICart _cartRepository;
        public CartServices(ICart cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public string SaveCart(Cart cart)
        {
            return _cartRepository.SaveCart(cart);
        }
        public string DeleteCart(int CartId)
        {
            return _cartRepository.DeleteCart(CartId);
        }
        public string UpdateCart(Cart cart)
        {
            return _cartRepository.UpdateCart(cart);
        }
        public Cart GetCart(int CartId)
        {
            return _cartRepository.GetCart(CartId);
        }
        public List<Cart> GetAllCart()
        {
            return _cartRepository.GetAllCart();
        }

        public IEnumerable<Cart> GetCartByUserID(int UserId)
        {
            return _cartRepository.GetCartByUserID(UserId);
        }
        public int GetCartId(int UserId)
        {
            return _cartRepository.GetCartId(UserId);
        }
    }
}
