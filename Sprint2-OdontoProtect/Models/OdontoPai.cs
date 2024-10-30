using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class OdontoPai
{
    public byte? Nome { get; set; }

    public long IdPais { get; set; }

    public virtual OdontoEstado? OdontoEstado { get; set; }
}
