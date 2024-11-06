using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class OdontoSinistro
{
    public long Id { get; set; }

    public decimal? CustoExcedente { get; set; }

    public DateTime? DataSinistro { get; set; }

    public string? Descricao { get; set; }

    public long? AtendimentoId { get; set; }

    public virtual OdontoAtendimento? Atendimento { get; set; }
}
