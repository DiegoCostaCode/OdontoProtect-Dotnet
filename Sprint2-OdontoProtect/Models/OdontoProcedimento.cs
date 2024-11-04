using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class OdontoProcedimento
{
    public long Id { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<OdontoAtendimento> OdontoAtendimentos { get; set; } = new List<OdontoAtendimento>();
}
