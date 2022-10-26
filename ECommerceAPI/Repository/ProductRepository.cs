using ECommerceAPI.Data;
using ECommerceAPI.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace ECommerceAPI.Repository
{
    public class ProductRepository : IProduct
    {
        private ECommerceDbContext _eCommerceDbContext;

        public ProductRepository(ECommerceDbContext eCommerceDbContext)
        {
            _eCommerceDbContext = eCommerceDbContext;
        }
        public string SaveProduct(Product Product)
        {
            try
            {
                _eCommerceDbContext.Product.Add(Product);
                _eCommerceDbContext.SaveChanges();
                
            }
            catch (Exception)
            {
                throw;
            }
            return "Saved";
        }
        public string UpdateProduct(int ProductId,Product Product)
        {
            if (ProductId != Product.ProductId)
            {
                return "Bad Request";
            }
            try
            {
                _eCommerceDbContext.Entry(Product).State = EntityState.Modified;
                _eCommerceDbContext.SaveChanges();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(ProductId))
                {
                    return "NotFound";
                }
                else
                {
                    throw;
                }
            }
            return "Updated";
        }
        private bool ProductExists(int ProductId)
        {
            return _eCommerceDbContext.Product.Any(e => e.ProductId == ProductId);
        }

        public string DeleteProduct(int ProductId)
        {
           
            try
            {
                string msg = "";
                Product delete = _eCommerceDbContext.Product.Find(ProductId);
                if (delete != null)
                {
                    _eCommerceDbContext.Product.Remove(delete);
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
        public Product GetProduct(int ProductId)
        {
            try
            {
                Product product = _eCommerceDbContext.Product.Find(ProductId);
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Product> GetByCategory(string Category)
        {
            try
            {
                List<Product> product = _eCommerceDbContext.Product.Where(x=>x.Category==Category).ToList();
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Product> GetAllProduct()
        {
            try
            {
                List<Product> product = _eCommerceDbContext.Product.ToList();
                return product;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
