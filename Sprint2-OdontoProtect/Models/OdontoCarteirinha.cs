using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class OdontoCarteirinha
{
    public DateTime? Emissao { get; set; }

    public long? Numero { get; set; }

    public long? PacienteId { get; set; }

    public long? PlanoId { get; set; }

    public DateTime? Validade { get; set; }

    public Guid Id { get; set; }

    public virtual OdontoPaciente? Paciente { get; set; }

    public virtual OdontoPlano? Plano { get; set; }
}
