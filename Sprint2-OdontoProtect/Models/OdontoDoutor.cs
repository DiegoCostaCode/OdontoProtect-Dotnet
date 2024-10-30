using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class OdontoDoutor
{
    public long Id { get; set; }

    public string? Cpf { get; set; }

    public string? Crm { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<OdontoClinicaDoutor> OdontoClinicaDoutors { get; set; } = new List<OdontoClinicaDoutor>();
}
