using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class MovimentoEstoque
{
    public long SeqMovimentoEstoque { get; set; }

    public int? CodProduto { get; set; }

    public DateTime? DatMovimentoEstoque { get; set; }

    public decimal? QtdMovimentacaoEstoque { get; set; }

    public byte? CodTipoMovimentoEstoque { get; set; }
}
