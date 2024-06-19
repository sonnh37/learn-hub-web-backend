using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SmartThrive.API.RequestModel
{
    public class PackageRequest : BaseRequest
    {
        public Guid? StudentId { get; set; }

        public string PackageName { get; set; }

        public DateTime? StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }

        public int? QuantityCourse { get; set; }

        public decimal TotalPrice { get; set; }

        public bool? IsActive { get; set; }
    }
}
