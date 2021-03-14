using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Models
{
    //Game users
    public class User : BaseModel
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
