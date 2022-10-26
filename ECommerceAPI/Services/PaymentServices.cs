using ECommerceAPI.Models;
using ECommerceAPI.Repository;

namespace ECommerceAPI.Services
{
    public class PaymentServices
    {
        public IPayment _transaction;
        public PaymentServices(IPayment transaction)
        {
            _transaction = transaction;
        }
        public string SaveTransaction(Payment Payment)
        {
            return _transaction.SaveTransaction(Payment);
        }

        public string DeleteTransaction(int TransactionId)
        {
            return _transaction.DeleteTransaction(TransactionId);
        }
        public string UpdateTransaction(Payment Payment)
        {
            return _transaction.UpdateTransaction(Payment);
        }
        public Payment GetTransaction(int TransactionId)
        {
            return _transaction.GetTransaction(TransactionId);
        }
        public List<Payment> GetAllTransaction()
        {
            return _transaction.GetAllTransaction();
        }
    }
}
