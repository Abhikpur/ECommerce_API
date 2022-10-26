using ECommerceAPI.Data;
using ECommerceAPI.Models;

namespace ECommerceAPI.Repository
{
    public class AddressRepository : IAddress
    {
        private ECommerceDbContext _ecommerceDbContext;

        public AddressRepository(ECommerceDbContext ecommerceDbContext)
        {
            _ecommerceDbContext = ecommerceDbContext;
        }
        public string DeleteAddress(int AddressId)
        {
            try
            {
                string msg = "";
                AddressTbl delete = _ecommerceDbContext.AddressTbl.Find(AddressId);//storing the details of the Product in the obj 
                if (delete != null)
                {
                    _ecommerceDbContext.AddressTbl.Remove(delete);
                    _ecommerceDbContext.SaveChanges();
                    msg = "Deleted";
                }
                return msg;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AddressTbl GetAddress(int AddressId)
        {
            try
            {
                AddressTbl Address = _ecommerceDbContext.AddressTbl.Find(AddressId);
                return Address;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AddressTbl GetUserAddress(int UserId)
        {
            try
            {
                AddressTbl Address = _ecommerceDbContext.AddressTbl.Find(UserId);
                return Address;
            }
            catch (Exception)
            {
                throw;
            }   
        }

        public List<AddressTbl> GetAllAddress()
        {
            try
            {
                List<AddressTbl> Address = _ecommerceDbContext.AddressTbl.ToList();
                return Address;
            }
            catch (Exception)
            {
                throw;
            }  
        }

        public string SaveAddress(AddressTbl AddressT)
        {
            try
            {
                _ecommerceDbContext.AddressTbl.Add(AddressT);
                _ecommerceDbContext.SaveChanges();
                return "Saved";
            }
            catch (Exception)
            {
                throw;
            }  
        }

        public string UpdateAddress(AddressTbl AddressT)
        {
            try
            {
                _ecommerceDbContext.Entry(AddressT).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _ecommerceDbContext.SaveChanges();
                return "Updated";
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
