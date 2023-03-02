using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SalesDataPredictionAPI.Models.Data;

public partial class Shipper
{
    public int Shipperid { get; set; }

    public string Companyname { get; set; } = null!;
    [JsonIgnore]
    public string Phone { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
