using FeedbackMicroservice.DBContexts;
using FeedbackMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly FeedbackContext dbcontext;

        public UserRepository(FeedbackContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return dbcontext.Users.ToList();
        }

        public User GetUserById(int Id)
        {
            return dbcontext.Users.Where(u => u.Id == Id && !u.IsDeleted && u.IsActive).FirstOrDefault();
        }
    }
}
