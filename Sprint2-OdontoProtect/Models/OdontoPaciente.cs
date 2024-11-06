using System;
using System.Collections.Generic;

namespace Sprint2_OdontoProtect.Models;

public partial class OdontoPaciente
{
    public long Id { get; set; }

    public string? Cpf { get; set; }

    public DateTime? DataNascimento { get; set; }

    public string? Email { get; set; }

    public string? Nome { get; set; }

    public string? Telefone { get; set; }

    public long? EnderecoId { get; set; }

    public virtual OdontoEndereco? Endereco { get; set; }

    public virtual ICollection<OdontoAtendimento> OdontoAtendimentos { get; set; } = new List<OdontoAtendimento>();

    public virtual OdontoCarteirinha? OdontoCarteirinha { get; set; }
}
