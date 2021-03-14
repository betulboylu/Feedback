using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Models
{
    //User feedbacks on each game session
    public class Feedback:BaseModel
    {
        [Required(ErrorMessage = "The SessionId is required.")]
        public int SessionId { get; set; }

        [Required(ErrorMessage = "The Ubi-UserId is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The Rate field is required.")]
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Rate { get; set; }

        public string Comment { get; set; }
    }
}
