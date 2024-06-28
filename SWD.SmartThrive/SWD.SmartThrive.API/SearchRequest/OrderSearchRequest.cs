namespace SWD.SmartThrive.API.SearchRequest
{
    public class OrderSearchRequest
    {
        public string? PaymentMethod { get; set; }

        public int? Amount { get; set; }

        public decimal? TotalPrice { get; set; }

        public bool? Status { get; set; }
    }
}
