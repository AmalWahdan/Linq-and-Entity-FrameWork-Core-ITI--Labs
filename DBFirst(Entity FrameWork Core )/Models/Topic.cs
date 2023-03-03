using System;
using System.Collections.Generic;

namespace DBFirst.Models;

public partial class Topic
{
    public int TopId { get; set; }

    public string? TopName { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();
}
