using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemCollageV1.Models;

public partial class Option
{
    [Key]
    public int Op_Id { get; set; }

    public int Q_Id{ get; set; }

    public string OpText { get; set; } 

    public bool IsCorrect { get; set; }

    public virtual Question QIdNavigation { get; set; }
}
