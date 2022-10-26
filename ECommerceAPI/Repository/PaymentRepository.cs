using ECommerceAPI.Data;
using ECommerceAPI.Models;
using System.Data.Entity;

namespace ECommerceAPI.Repository
{
    public class PaymentRepository:IPayment
    {
        private ECommerceDbContext _eCommerceDbContext;

        public PaymentRepository(ECommerceDbContext CommerceDbContext)
        {
            _eCommerceDbContext = CommerceDbContext;
        }
        public string SaveTransaction(Payment Payment)
        {
            try
            {
                _eCommerceDbContext.Payment.Add(Payment);
                _eCommerceDbContext.SaveChanges();
                return "Saved";
            }
            catch(Exception)
            {
                throw;
            }
            
        }
        public string UpdateTransaction(Payment Payment)
        {
            try
            {
                _eCommerceDbContext.Entry(Payment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _eCommerceDbContext.SaveChanges();
                return "Updated";
            }
            catch(Exception)
            {
                throw;
            }          
        }
        public string DeleteTransaction(int TransactionId)
        {
            try
            {
                string msg = "";
                Payment deleteTransaction = _eCommerceDbContext.Payment.Find(TransactionId);
                if (deleteTransaction != null)
                {
                    _eCommerceDbContext.Payment.Remove(deleteTransaction);
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
        public Payment GetTransaction(int TransactionId)
        {
            try
            {
                Payment transaction = _eCommerceDbContext.Payment.Find(TransactionId);
                return transaction;
            }
            catch (Exception)
            {
                throw;
            }         
        }

        public List<Payment> GetAllTransaction()
        {
            try
            {
                List<Payment> transactions = _eCommerceDbContext.Payment.ToList();
                return transactions;
            }
            catch (Exception)
            {
                throw;
            }          
        }
        
    }
}
