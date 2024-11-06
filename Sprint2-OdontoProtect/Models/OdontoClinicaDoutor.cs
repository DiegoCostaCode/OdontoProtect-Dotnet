using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class OdontoClinicaDoutor
{
    public long Id { get; set; }

    public DateTime? DataFimRelacionamento { get; set; }

    public DateTime? DataRelacionamento { get; set; }

    public long? ClinicaId { get; set; }

    public long? DoutorId { get; set; }

    public virtual OdontoClinica? Clinica { get; set; }

    public virtual OdontoDoutor? Doutor { get; set; }
}
