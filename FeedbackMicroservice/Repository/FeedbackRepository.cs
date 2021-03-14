using FeedbackMicroservice.DBContexts;
using FeedbackMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public class FeedbackRepository :IFeedbackRepository
    {
        private readonly FeedbackContext dbcontext;

        public FeedbackRepository(FeedbackContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }
        public IEnumerable<Feedback> GetFeedbacks()
        {
            return dbcontext.Feedbacks.ToList();
        }

        public void InsertFeedBack(Feedback feedback)
        {
            dbcontext.Feedbacks.Add(feedback);
            Save();
        }

        public Feedback GetFeedbackBySessionAndUser(int SessionId, int UserId)
        {
           return dbcontext.Feedbacks.Where(f => f.SessionId == SessionId && f.UserId == UserId && !f.IsDeleted).FirstOrDefault();
        }

        public void Save()
        {
            dbcontext.SaveChanges();
        }

    }
}
