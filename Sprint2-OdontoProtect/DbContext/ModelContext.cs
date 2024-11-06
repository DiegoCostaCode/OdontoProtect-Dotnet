using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sprint2_OdontoProtect.Models;


public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OdontoAtendimento> OdontoAtendimentos { get; set; }

    public virtual DbSet<OdontoCarteirinha> OdontoCarteirinhas { get; set; }

    public virtual DbSet<OdontoCidade> OdontoCidades { get; set; }

    public virtual DbSet<OdontoClinica> OdontoClinicas { get; set; }

    public virtual DbSet<OdontoClinicaDoutor> OdontoClinicaDoutors { get; set; }

    public virtual DbSet<OdontoDoutor> OdontoDoutors { get; set; }

    public virtual DbSet<OdontoEndereco> OdontoEnderecos { get; set; }

    public virtual DbSet<OdontoEstado> OdontoEstados { get; set; }

    public virtual DbSet<OdontoPaciente> OdontoPacientes { get; set; }

    public virtual DbSet<OdontoPais> OdontoPais { get; set; }

    public virtual DbSet<OdontoPlano> OdontoPlanos { get; set; }

    public virtual DbSet<OdontoProcedimento> OdontoProcedimentos { get; set; }

    public virtual DbSet<OdontoSinistro> OdontoSinistros { get; set; }

    public virtual DbSet<OdontoTipoUsuario> OdontoTipoUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=//oracle.fiap.com.br:1521/orcl;User Id=rm552648;Password=fiap24;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("RM552648")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<OdontoAtendimento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003975295");

            entity.ToTable("ODONTO_ATENDIMENTO");

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");
            entity.Property(e => e.ClinicaId)
                .HasPrecision(19)
                .HasColumnName("CLINICA_ID");
            entity.Property(e => e.Custo)
                .HasColumnType("FLOAT")
                .HasColumnName("CUSTO");
            entity.Property(e => e.DataHoraAtendimento)
                .HasPrecision(6)
                .HasColumnName("DATA_HORA_ATENDIMENTO");
            entity.Property(e => e.Descrição)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIÇÃO");
            entity.Property(e => e.PacienteId)
                .HasPrecision(19)
                .HasColumnName("PACIENTE_ID");
            entity.Property(e => e.ProcedimentoId)
                .HasPrecision(19)
                .HasColumnName("PROCEDIMENTO_ID");

            entity.HasOne(d => d.Clinica).WithMany(p => p.OdontoAtendimentos)
                .HasForeignKey(d => d.ClinicaId)
                .HasConstraintName("FKS24MMA2CV828GNSL4UTI9RI71");

            entity.HasOne(d => d.Paciente).WithMany(p => p.OdontoAtendimentos)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FKDYPJXJNWNOU7PNN6N3788B37V");

            entity.HasOne(d => d.Procedimento).WithMany(p => p.OdontoAtendimentos)
                .HasForeignKey(d => d.ProcedimentoId)
                .HasConstraintName("FKDCVHK5FS35MC05CRCIHR3JWWU");
        });

        modelBuilder.Entity<OdontoCarteirinha>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003975297");

            entity.ToTable("ODONTO_CARTEIRINHA");

            entity.HasIndex(e => e.PacienteId, "UK4CR6HIY8F7JDNNXTVY2B9W168").IsUnique();

            entity.HasIndex(e => e.PlanoId, "UKHQ8JUMD1DMRTGS3E0PE7WT1AT").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Emissao)
                .HasPrecision(6)
                .HasColumnName("EMISSAO");
            entity.Property(e => e.Numero)
                .HasPrecision(19)
                .HasColumnName("NUMERO");
            entity.Property(e => e.PacienteId)
                .HasPrecision(19)
                .HasColumnName("PACIENTE_ID");
            entity.Property(e => e.PlanoId)
                .HasPrecision(19)
                .HasColumnName("PLANO_ID");
            entity.Property(e => e.Validade)
                .HasPrecision(6)
                .HasColumnName("VALIDADE");

            entity.HasOne(d => d.Paciente).WithOne(p => p.OdontoCarteirinha)
                .HasForeignKey<OdontoCarteirinha>(d => d.PacienteId)
                .HasConstraintName("FKB9SQAL14YK5S58J4PMYG43AJR");

            entity.HasOne(d => d.Plano).WithOne(p => p.OdontoCarteirinha)
                .HasForeignKey<OdontoCarteirinha>(d => d.PlanoId)
                .HasConstraintName("FKNRL65GX10CAQUTJUN73EKEINT");
        });

        modelBuilder.Entity<OdontoCidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003975299");

            entity.ToTable("ODONTO_CIDADE");

            entity.HasIndex(e => e.Estado, "UKT1OB5SRBL49L5AM49R4SXEGFW").IsUnique();

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");
            entity.Property(e => e.Cidade)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CIDADE");
            entity.Property(e => e.Estado)
                .HasPrecision(19)
                .HasColumnName("ESTADO");

            entity.HasOne(d => d.EstadoNavigation).WithOne(p => p.OdontoCidade)
                .HasForeignKey<OdontoCidade>(d => d.Estado)
                .HasConstraintName("FKM5VC01JJDH3D9SG0C14M5PAFL");
        });

        modelBuilder.Entity<OdontoClinica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003975301");

            entity.ToTable("ODONTO_CLINICA");

            entity.HasIndex(e => e.EnderecoId, "UK8SX7FJ5YAQMIRGMU40EXNI972").IsUnique();

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CNPJ");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRICAO");
            entity.Property(e => e.EmailRepresentante)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EMAIL_REPRESENTANTE");
            entity.Property(e => e.EnderecoId)
                .HasPrecision(19)
                .HasColumnName("ENDERECO_ID");
            entity.Property(e => e.RazaoSocial)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RAZAO_SOCIAL");

            entity.HasOne(d => d.Endereco).WithOne(p => p.OdontoClinica)
                .HasForeignKey<OdontoClinica>(d => d.EnderecoId)
                .HasConstraintName("FK32O6JRTLVI7IMDGSTIOQJSNO");
        });

        modelBuilder.Entity<OdontoClinicaDoutor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003975303");

            entity.ToTable("ODONTO_CLINICA_DOUTOR");

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");
            entity.Property(e => e.ClinicaId)
                .HasPrecision(19)
                .HasColumnName("CLINICA_ID");
            entity.Property(e => e.DataFimRelacionamento)
                .HasColumnType("DATE")
                .HasColumnName("DATA_FIM_RELACIONAMENTO");
            entity.Property(e => e.DataRelacionamento)
                .HasColumnType("DATE")
                .HasColumnName("DATA_RELACIONAMENTO");
            entity.Property(e => e.DoutorId)
                .HasPrecision(19)
                .HasColumnName("DOUTOR_ID");

            entity.HasOne(d => d.Clinica).WithMany(p => p.OdontoClinicaDoutors)
                .HasForeignKey(d => d.ClinicaId)
                .HasConstraintName("FK2HWYDMKIHY9GIUFAXLBRDSJUL");

            entity.HasOne(d => d.Doutor).WithMany(p => p.OdontoClinicaDoutors)
                .HasForeignKey(d => d.DoutorId)
                .HasConstraintName("FK1QVX3FRRJTY4KPF1KMN34NV16");
        });

        modelBuilder.Entity<OdontoDoutor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003975305");

            entity.ToTable("ODONTO_DOUTOR");

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");
            entity.Property(e => e.Cpf)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.Crm)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CRM");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NOME");
        });

        modelBuilder.Entity<OdontoEndereco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003975307");

            entity.ToTable("ODONTO_ENDERECO");

            entity.HasIndex(e => e.Cidade, "UK34PRWW5E10EH0ER0A2EQFD8QH").IsUnique();

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");
            entity.Property(e => e.Cep)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CEP");
            entity.Property(e => e.Cidade)
                .HasPrecision(19)
                .HasColumnName("CIDADE");
            entity.Property(e => e.Complemento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("COMPLEMENTO");
            entity.Property(e => e.Numero)
                .HasPrecision(10)
                .HasColumnName("NUMERO");
            entity.Property(e => e.Rua)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RUA");

            entity.HasOne(d => d.CidadeNavigation).WithOne(p => p.OdontoEndereco)
                .HasForeignKey<OdontoEndereco>(d => d.Cidade)
                .HasConstraintName("FK64HSTPR7337QPGI9VEJUWKUOQ");
        });

        modelBuilder.Entity<OdontoEstado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003975310");

            entity.ToTable("ODONTO_ESTADO");

            entity.HasIndex(e => e.Pais, "UKIPGV66DHOG1NUUQ4917ANLBMD").IsUnique();

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.Pais)
                .HasPrecision(19)
                .HasColumnName("PAIS");

            entity.HasOne(d => d.PaisNavigation).WithOne(p => p.OdontoEstado)
                .HasForeignKey<OdontoEstado>(d => d.Pais)
                .HasConstraintName("FKLB42KC91SGYEDXC0Y5SQ6AGW1");
        });

        modelBuilder.Entity<OdontoPaciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003975312");

            entity.ToTable("ODONTO_PACIENTE");

            entity.HasIndex(e => e.EnderecoId, "UK2S3UDNTC153H74KGVSOUGWTX1").IsUnique();

            entity.HasIndex(e => e.Cpf, "UKFAJEJYBO6D8XLXCB78XHNNYYU").IsUnique();

            entity.HasIndex(e => e.Telefone, "UKGHH5KUGNHIS9H3KVJ1KNWLIE1").IsUnique();

            entity.HasIndex(e => e.Email, "UKJWIIEI18TO9CL80ECKXFQ82CH").IsUnique();

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");
            entity.Property(e => e.Cpf)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.DataNascimento)
                .HasPrecision(6)
                .HasColumnName("DATA_NASCIMENTO");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.EnderecoId)
                .HasPrecision(19)
                .HasColumnName("ENDERECO_ID");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NOME");
            entity.Property(e => e.Telefone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TELEFONE");

            entity.HasOne(d => d.Endereco).WithOne(p => p.OdontoPaciente)
                .HasForeignKey<OdontoPaciente>(d => d.EnderecoId)
                .HasConstraintName("FKANPCQBLIYHOOWYR1GRLOD57JD");
        });

        modelBuilder.Entity<OdontoPais>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003975315");

            entity.ToTable("ODONTO_PAIS");

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NOME");
        });

        modelBuilder.Entity<OdontoPlano>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003975318");

            entity.ToTable("ODONTO_PLANO");

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");
            entity.Property(e => e.Ativo)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("ATIVO");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRICAO");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NOME");
            entity.Property(e => e.Preco)
                .HasColumnType("FLOAT")
                .HasColumnName("PRECO");
        });

        modelBuilder.Entity<OdontoProcedimento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003975321");

            entity.ToTable("ODONTO_PROCEDIMENTO");

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRICAO");
        });

        modelBuilder.Entity<OdontoSinistro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003975323");

            entity.ToTable("ODONTO_SINISTRO");

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");
            entity.Property(e => e.AtendimentoId)
                .HasPrecision(19)
                .HasColumnName("ATENDIMENTO_ID");
            entity.Property(e => e.CustoExcedente)
                .HasColumnType("FLOAT")
                .HasColumnName("CUSTO_EXCEDENTE");
            entity.Property(e => e.DataSinistro)
                .HasColumnType("DATE")
                .HasColumnName("DATA_SINISTRO");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRICAO");

            entity.HasOne(d => d.Atendimento).WithMany(p => p.OdontoSinistros)
                .HasForeignKey(d => d.AtendimentoId)
                .HasConstraintName("FK2L55KUXW1VGHV22BWRLGV9G75");
        });

        modelBuilder.Entity<OdontoTipoUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003726121");

            entity.ToTable("ODONTO_TIPO_USUARIO");

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");
            entity.Property(e => e.Atribuicao)
                .HasPrecision(3)
                .HasColumnName("ATRIBUICAO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
