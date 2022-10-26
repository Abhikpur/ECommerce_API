using ECommerceAPI.Models;
using ECommerceAPI.Repository;

namespace ECommerceAPI.Services
{
    public class AddressServices
    {
        private IAddress _AddressRepository;
        public AddressServices(IAddress AddressRepository)
        {
            _AddressRepository = AddressRepository;
        }
        public string SaveAddress(AddressTbl AddressT)
        {
            return _AddressRepository.SaveAddress(AddressT);
        }
        public string DeleteAddress(int AddressId)
        {
            return _AddressRepository.DeleteAddress(AddressId);
        }
        public string UpdateAddress(AddressTbl AddressT)
        {
            return _AddressRepository.UpdateAddress(AddressT);
        }
        public AddressTbl GetAddress(int AddressId)
        {
            return _AddressRepository.GetAddress(AddressId);
        }
        public AddressTbl GetUserAddress(int UserId)
        {
            return _AddressRepository.GetAddress(UserId);
        }
        public List<AddressTbl> GetAllAddress()
        {
            return _AddressRepository.GetAllAddress();
        }
    }
}
