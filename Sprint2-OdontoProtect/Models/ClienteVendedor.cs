using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class ClienteVendedor
{
    public int CodCliente { get; set; }

    public byte CodVendedor { get; set; }

    public DateTime DatInicio { get; set; }

    public DateTime? DatTermino { get; set; }
}
