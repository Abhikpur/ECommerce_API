using ECommerceAPI.Models;
using ECommerceAPI.Repository;

namespace ECommerceAPI.Services
{
    public class ProductServices
    {
        public IProduct _ProductRepository;

        public ProductServices(IProduct Product)
        {
            _ProductRepository = Product;
        }

        public string SaveProduct(Product Product)
        {
            return _ProductRepository.SaveProduct(Product);
        }
        public string DeleteProduct(int ProductId)
        {
            return _ProductRepository.DeleteProduct(ProductId);
        }
        public string UpdateProduct(int id,Product Product)
        {
            return _ProductRepository.UpdateProduct(id,Product);
        }
        public Product GetProduct(int ProductId)
        {
            return _ProductRepository.GetProduct(ProductId);
        }
        public List<Product> GetAllProduct()
        {
            return _ProductRepository.GetAllProduct();
        }
        public List<Product> GetByCategory(string Category)
        {
            return _ProductRepository.GetByCategory(Category);
        }
    }
}
