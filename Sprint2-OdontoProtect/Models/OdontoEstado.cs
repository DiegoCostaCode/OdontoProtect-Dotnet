using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class OdontoEstado
{
    public long Id { get; set; }

    public string? Estado { get; set; }

    public long? Pais { get; set; }

    public virtual OdontoCidade? OdontoCidade { get; set; }

    public virtual OdontoPais? PaisNavigation { get; set; }
}
