using System;
using System.Collections.Generic;

namespace DBFirst.Models;

public partial class Sale
{
    public int? ProductId { get; set; }

    public string? SalesmanName { get; set; }

    public int? Quantity { get; set; }
}
