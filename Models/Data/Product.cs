using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SalesDataPredictionAPI.Models.Data;

public partial class Product
{
    public int Productid { get; set; }

    public string Productname { get; set; } = null!;
    [JsonIgnore]
    public int Supplierid { get; set; }
    [JsonIgnore]
    public int Categoryid { get; set; }
    [JsonIgnore]
    public decimal Unitprice { get; set; }
    [JsonIgnore]
    public bool Discontinued { get; set; }
    [JsonIgnore]
    public virtual Category Category { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
    [JsonIgnore]
    public virtual Supplier Supplier { get; set; } = null!;
}
