using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class OdontoPais
{
    public long Id { get; set; }

    public string? Nome { get; set; }

    public virtual OdontoEstado? OdontoEstado { get; set; }
}
