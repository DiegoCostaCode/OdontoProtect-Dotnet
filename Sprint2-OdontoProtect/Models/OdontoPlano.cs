using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class OdontoPlano
{
    public long Id { get; set; }

    public bool? Ativo { get; set; }

    public string? Descricao { get; set; }

    public string? Nome { get; set; }

    public decimal? Preco { get; set; }

    public virtual OdontoCarteirinha? OdontoCarteirinha { get; set; }
}
