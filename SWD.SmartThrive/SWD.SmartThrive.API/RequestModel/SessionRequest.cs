using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SmartThrive.API.RequestModel
{
    public class SessionRequest : BaseRequest
    {
        public Guid CourseId { get; set; }

        public string SessionName { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? LearnDate { get; set; }
    }
}
