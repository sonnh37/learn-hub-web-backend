﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SmartThrive.API.RequestModel
{
    public class OrderRequest
    {
        public Guid? PackageId { get; set; }
        public string? PaymentMethod { get; set; }
        public int? Amount { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        [Required]
        public DateTime? LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
