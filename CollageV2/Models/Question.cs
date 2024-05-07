using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemCollageV1.Models;

public partial class Question
{
    [Key]
    public int Q_Id { get; set; }

    public string QTitle { get; set; }

    public string QText { get; set; }

    public virtual ICollection<Option> Options { get; set; } = new List<Option>();
}
