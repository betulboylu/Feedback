using FeedbackMicroservice.Models;
using FeedbackMicroservice.Repository;
using FeedbackMicroservice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace FeedbackMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository feedbackRepository;
        private readonly IUserRepository userRepository;
        private readonly ISessionRepository sessionRepository;
        private readonly IStringLocalizer<SharedResources> localizer;

        public FeedbackController(IFeedbackRepository _feedback, IUserRepository _user, ISessionRepository _session, IStringLocalizer<SharedResources> lLocal)
        {
            feedbackRepository = _feedback;
            userRepository = _user;
            sessionRepository = _session;
            localizer = lLocal;
        }

        // GET: api/Feedback?Filter=max
        /// <summary>
        /// Lists last 15 feedbacks and allows filtering by Rate.
        /// </summary>
        /// <param name="Filter">A string value received from QueryString to filter the records.</param>
        /// <returns>Feedback list</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string Filter)
        {
            if(Filter =="max")
                return new OkObjectResult(feedbackRepository.GetFeedbacks().OrderByDescending(a => a.Rate).Take(15));
            else
                return new OkObjectResult(feedbackRepository.GetFeedbacks().OrderBy(a => a.Rate).Take(15));

        }

        // POST api/Feedback/1
        /// <summary>
        /// Records a single feedback of a User for a SessionId.
        /// </summary>
        /// <param name="feed">Feed object received from request body, holds Rate(int),Comment(string)</param>
        /// <param name="SessionId">An int value received from URL, holds game session Id.</param>
        /// <param name="UserId">An int value received from request header, holds game player's Id.</param>
        /// <returns>Feedback</returns>
        [Route("{SessionId}")]
        [HttpPost]
        public IActionResult Post([FromBody] Feedback Feed, int SessionId, [FromHeader(Name = "Ubi-UserId")] int UserId)
        {

            if (Feed == null || string.IsNullOrEmpty(SessionId.ToString()) || string.IsNullOrEmpty(UserId.ToString()))
                return new BadRequestObjectResult(localizer["MissingParameter"].Value);

            else if (userRepository.GetUserById(UserId) == null)
                return new BadRequestObjectResult(localizer["InvalidUser"].Value);

            else if (sessionRepository.GetSessionById(SessionId) == null)
                return new BadRequestObjectResult(localizer["InvalidSession"].Value);

            else if (feedbackRepository.GetFeedbackBySessionAndUser(SessionId, UserId) != null)
                return new BadRequestObjectResult(localizer["FeedbackExist"].Value);

            else if (!Enumerable.Range(1, 5).Contains(Feed.Rate))
                return new BadRequestObjectResult(localizer["InvalidRate"].Value);

            else if (SessionId.GetType() != typeof(int))
                return new BadRequestResult();

            else if (UserId.GetType() != typeof(int))
                return new BadRequestResult();

            else
            {
                using (var scope = new TransactionScope())
                {
                    Feed.SessionId = SessionId;
                    Feed.UserId = UserId;
                    feedbackRepository.InsertFeedBack(Feed);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = Feed.Id }, Feed);
                }
            }
        }

    }
}
