using FeedbackMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetFeedbacks();

        void InsertFeedBack(Feedback feedback);

        Feedback GetFeedbackBySessionAndUser(int SessionId, int UserId);
        void Save();
    }
}
