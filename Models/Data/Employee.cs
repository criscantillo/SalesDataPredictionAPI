using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SalesDataPredictionAPI.Models.Data;

public partial class Employee
{
    public int Empid { get; set; }
    [JsonIgnore]
    public string Lastname { get; set; } = null!;
    [JsonIgnore]
    public string Firstname { get; set; } = null!;

    [NotMapped]
    public virtual string FullName { get; set; } = null!;
    [JsonIgnore]
    public string Title { get; set; } = null!;
    [JsonIgnore]
    public string Titleofcourtesy { get; set; } = null!;
    [JsonIgnore]
    public DateTime Birthdate { get; set; }
    [JsonIgnore]
    public DateTime Hiredate { get; set; }
    [JsonIgnore]
    public string Address { get; set; } = null!;
    [JsonIgnore]
    public string City { get; set; } = null!;
    [JsonIgnore]
    public string? Region { get; set; }
    [JsonIgnore]
    public string? Postalcode { get; set; }
    [JsonIgnore]
    public string Country { get; set; } = null!;
    [JsonIgnore]
    public string Phone { get; set; } = null!;
    [JsonIgnore]
    public int? Mgrid { get; set; }
    [JsonIgnore]
    public virtual ICollection<Employee> InverseMgr { get; } = new List<Employee>();
    [JsonIgnore]
    public virtual Employee? Mgr { get; set; }
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
