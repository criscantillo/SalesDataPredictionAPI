using System;
using System.Collections.Generic;

namespace SalesDataPredictionAPI.Models.Data;

public partial class Category
{
    public int Categoryid { get; set; }

    public string Categoryname { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
