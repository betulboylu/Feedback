using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Models
{
    //Sessions for each game
    public class Session :BaseModel
    {
        public int GameId { get; set; }

    }
}
