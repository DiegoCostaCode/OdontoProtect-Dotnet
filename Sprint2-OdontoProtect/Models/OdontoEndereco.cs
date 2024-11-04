using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class OdontoEndereco
{
    public int? Numero { get; set; }

    public long? Cidade { get; set; }

    public long Id { get; set; }

    public string? Cep { get; set; }

    public string? Complemento { get; set; }

    public string? Rua { get; set; }

    public virtual OdontoCidade? CidadeNavigation { get; set; }

    public virtual OdontoClinica? OdontoClinica { get; set; }

    public virtual OdontoPaciente? OdontoPaciente { get; set; }
}
