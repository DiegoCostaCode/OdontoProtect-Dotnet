using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class OdontoAtendimento
{
    public decimal? Custo { get; set; }

    public long? ClinicaId { get; set; }

    public DateTime? DataHoraAtendimento { get; set; }

    public long Id { get; set; }

    public long? PacienteId { get; set; }

    public long? ProcedimentoId { get; set; }

    public string? Descrição { get; set; }

    public virtual OdontoClinica? Clinica { get; set; }

    public virtual ICollection<OdontoSinistro> OdontoSinistros { get; set; } = new List<OdontoSinistro>();

    public virtual OdontoPaciente? Paciente { get; set; }

    public virtual OdontoProcedimento? Procedimento { get; set; }
}
