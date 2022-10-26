using ECommerceAPI.Models;

namespace ECommerceAPI.Repository
{
    public interface IAddress
    {
        public string SaveAddress(AddressTbl AdressTbl);
        public string UpdateAddress(AddressTbl AddressTbl);
        public string DeleteAddress(int AddressId);
        AddressTbl GetAddress(int AddressId);

        AddressTbl GetUserAddress(int UserId);
        List<AddressTbl> GetAllAddress();
    }
}
