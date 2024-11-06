using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class OdontoCidade
{
    public long Id { get; set; }

    public string? Cidade { get; set; }

    public long? Estado { get; set; }

    public virtual OdontoEstado? EstadoNavigation { get; set; }

    public virtual OdontoEndereco? OdontoEndereco { get; set; }
}
