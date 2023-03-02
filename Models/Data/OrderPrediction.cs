namespace SalesDataPredictionAPI.Models.Data
{
    public class OrderPrediction
    {
        public System.Int64 Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public DateTime? LastOrderDate { get; set; } = null!;
        public DateTime? NextPredictedOrder { get; set; } = null!;
        public int AvgDays { get; set; }
    }
}
