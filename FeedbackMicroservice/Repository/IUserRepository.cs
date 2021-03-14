using FeedbackMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();

        User GetUserById(int Id);
    }
}
