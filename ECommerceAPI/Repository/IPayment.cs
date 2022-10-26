using ECommerceAPI.Models;

namespace ECommerceAPI.Repository
{
    public interface IPayment
    {
        public string SaveTransaction(Payment Payment);

        public string UpdateTransaction(Payment Payment);
        public string DeleteTransaction(int TransactionId);
        Payment GetTransaction(int TransactionId);
        List<Payment> GetAllTransaction();
    }
}
