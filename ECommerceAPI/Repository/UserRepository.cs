using ECommerceAPI.Data;
using ECommerceAPI.Models;

using Microsoft.EntityFrameworkCore;

using System.Data.Entity;

using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace ECommerceAPI.Repository
{
    public class UserRepository : IUser
    {
        private ECommerceDbContext _eCommerceDbContext;


        //UserRepository Constructor
        public UserRepository(ECommerceDbContext eCommerceDbContext)
        {
            _eCommerceDbContext = eCommerceDbContext;
        }

        //Display AllUserDetails
        public List<UserDetails> GetAllUserDetails()
        {
            try 
            {
                List<UserDetails> UserList = _eCommerceDbContext.UserDetails.ToList();
                return UserList;
            }
            catch(Exception)
            {
                throw;                    
            }           
        }

        //Display UserDetails using ID
        public UserDetails GetUserDetailsbyId(int UserId)
        {
            try
            {
                UserDetails UserList = _eCommerceDbContext.UserDetails.Find(UserId);
                return UserList;
            }
            catch (Exception)
            {
                throw;
            }           
        }

        //Disply UserDetails using Email also used for Login Function
        public UserDetails GetUserDetailsbyEmail(string Email)
        {
            try
            {
                UserDetails user = null;
                user = _eCommerceDbContext.UserDetails.FirstOrDefault(e => e.EmailId == Email);
                return user;
            }
            catch (Exception)
            {
                throw;
            }         
        }

        //SaveDetails Function
        public string AddUserDetails(UserDetails userDetails)
        {
            try
            {
                _eCommerceDbContext.UserDetails.Add(userDetails);
                _eCommerceDbContext.SaveChanges();
                return "SAVED!";
            }
            catch (Exception)
            {
                throw;
            }           
        }

        //UpdateDetails function
        public string EditUserDetails(int userId,UserDetails userDetails)
        {
            if (userId != userDetails.UserId)
            {
                return "Bad Request";
            }
            try
            {
                _eCommerceDbContext.Entry(userDetails).State = EntityState.Modified;
                _eCommerceDbContext.SaveChanges();
               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(userId))
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
        private bool UserExists(int UserId)
        {
            return _eCommerceDbContext.UserDetails.Any(e => e.UserId == UserId);
        }

        //DeleteDetails Function
        public string DeleteUserDetails(int UserId)
        {
            try
            {
                string message = "";
                UserDetails DeleteUser = _eCommerceDbContext.UserDetails.Find(UserId);
                if (DeleteUser != null)
                {
                    _eCommerceDbContext.UserDetails.Remove(DeleteUser);
                    _eCommerceDbContext.SaveChanges();
                    message = "DELETED!";
                    return message;
                }
                return "Details Not Found";
            }
            catch (Exception)
            {
                throw;
            }           
        }
    }
}
