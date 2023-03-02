using System.Text.Json.Serialization;

namespace SalesDataPredictionAPI.Models.Data;

public partial class OrderDetail
{
    public int Orderid { get; set; }

    public int Productid { get; set; }

    public decimal Unitprice { get; set; }

    public short Qty { get; set; }

    public decimal Discount { get; set; }
    [JsonIgnore]
    public virtual Order? Order { get; set; } = null!;
    [JsonIgnore]
    public virtual Product? Product { get; set; } = null!;
}
