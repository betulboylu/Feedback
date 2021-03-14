using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Models
{
    //Game model
    public class Game : BaseModel
    {
        [StringLength(250)]
        public string Name { get; set; }
    }
}
