using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class OdontoClinica
{
    public long? EnderecoId { get; set; }

    public long Id { get; set; }

    public string? Cnpj { get; set; }

    public string? Descricao { get; set; }

    public string? EmailRepresentante { get; set; }

    public string? RazãoSocial { get; set; }

    public string? RazaoSocial { get; set; }

    public virtual OdontoEndereco? Endereco { get; set; }

    public virtual ICollection<OdontoAtendimento> OdontoAtendimentos { get; set; } = new List<OdontoAtendimento>();

    public virtual ICollection<OdontoClinicaDoutor> OdontoClinicaDoutors { get; set; } = new List<OdontoClinicaDoutor>();
}
