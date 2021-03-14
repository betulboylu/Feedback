using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Models
{
    //All models extends BaseModel to get Id , IsDeleted and CreatedDate
    public class BaseModel
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}
