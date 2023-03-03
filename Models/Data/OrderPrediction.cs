namespace SalesDataPredictionAPI.Models.Data
{
    public class OrderPrediction
    {
        public System.Int64 Id { get; set; }
        public int CustId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? LastOrderDate { get; set; } = null!;
        public string? NextPredictedOrder { get; set; } = null!;
        public int AvgDays { get; set; }
    }
}
