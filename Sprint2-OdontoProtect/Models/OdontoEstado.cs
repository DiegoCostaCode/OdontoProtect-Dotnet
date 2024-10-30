using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class OdontoEstado
{
    public byte? Estado { get; set; }

    public long IdEstado { get; set; }

    public long? Pais { get; set; }

    public virtual OdontoCidade? OdontoCidade { get; set; }

    public virtual OdontoPai? PaisNavigation { get; set; }
}
