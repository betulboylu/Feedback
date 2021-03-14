using FeedbackMicroservice.DBContexts;
using FeedbackMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly FeedbackContext dbcontext;

        public SessionRepository(FeedbackContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }
        public Session GetSessionById(int Id)
        {
            return dbcontext.Sessions.Where(s=>s.Id == Id && !s.IsDeleted).FirstOrDefault();
        }
    }
}
