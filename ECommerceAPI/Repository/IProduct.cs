using ECommerceAPI.Models;

namespace ECommerceAPI.Repository
{
    public interface IProduct
    {
        public string SaveProduct(Product Product);
        public string UpdateProduct(int ProductId,Product Product);
        public string DeleteProduct(int ProductId);
        Product GetProduct(int ProductId);
        List<Product> GetByCategory(string Category);

        List<Product> GetAllProduct();
    }
}
