using System;
using System.Collections.Generic;

namespace DEMO_WPF.NET8.Models;

public partial class Request
{
    public int Id { get; set; }

    public string TechType { get; set; } = null!;

    public string TechName { get; set; } = null!;

    public string Customer { get; set; } = null!;

    public DateTime DateStart { get; set; }

    public DateTime? DateAllows { get; set; }

    public DateTime? DateEnd { get; set; }

    public string? Worker { get; set; }

    public string? Status { get; set; }

    public string? Comment { get; set; }
}
