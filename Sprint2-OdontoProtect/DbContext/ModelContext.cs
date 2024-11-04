using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sprint2_OdontoProtect.Models;

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

    public virtual DbSet<OdontoPai> OdontoPais { get; set; }

    public virtual DbSet<OdontoPlano> OdontoPlanos { get; set; }

    public virtual DbSet<OdontoProcedimento> OdontoProcedimentos { get; set; }

    public virtual DbSet<OdontoSinistro> OdontoSinistros { get; set; }

    public virtual DbSet<OdontoTipoUsuario> OdontoTipoUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseOracle("Name=FiapOracleConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("RM552648")
            .UseCollation("USING_NLS_COMP");


        modelBuilder.Entity<OdontoAtendimento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003844941");

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
            entity.HasKey(e => e.Id).HasName("SYS_C003844943");

            entity.ToTable("ODONTO_CARTEIRINHA");

            entity.HasIndex(e => e.PacienteId, "SYS_C003844944").IsUnique();

            entity.HasIndex(e => e.PlanoId, "SYS_C003844945").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("SYS_C003844947");

            entity.ToTable("ODONTO_CIDADE");

            entity.HasIndex(e => e.Estado, "SYS_C003844948").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("SYS_C003844950");

            entity.ToTable("ODONTO_CLINICA");

            entity.HasIndex(e => e.EnderecoId, "SYS_C003844951").IsUnique();

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
            entity.Property(e => e.RazãoSocial)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RAZÃO_SOCIAL");

            entity.HasOne(d => d.Endereco).WithOne(p => p.OdontoClinica)
                .HasForeignKey<OdontoClinica>(d => d.EnderecoId)
                .HasConstraintName("FK32O6JRTLVI7IMDGSTIOQJSNO");
        });

        modelBuilder.Entity<OdontoClinicaDoutor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003844953");

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
            entity.HasKey(e => e.Id).HasName("SYS_C003844955");

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
            entity.HasKey(e => e.Id).HasName("SYS_C003844957");

            entity.ToTable("ODONTO_ENDERECO");

            entity.HasIndex(e => e.Cidade, "SYS_C003844958").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("SYS_C003844961");

            entity.ToTable("ODONTO_ESTADO");

            entity.HasIndex(e => e.Pais, "SYS_C003844962").IsUnique();

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasPrecision(3)
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
            entity.HasKey(e => e.Id).HasName("SYS_C003844964");

            entity.ToTable("ODONTO_PACIENTE");

            entity.HasIndex(e => e.EnderecoId, "SYS_C003844965").IsUnique();

            entity.HasIndex(e => e.Cpf, "SYS_C003844966").IsUnique();

            entity.HasIndex(e => e.Email, "SYS_C003844967").IsUnique();

            entity.HasIndex(e => e.Telefone, "SYS_C003844968").IsUnique();

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

        modelBuilder.Entity<OdontoPai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003844971");

            entity.ToTable("ODONTO_PAIS");

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");
            entity.Property(e => e.Nome)
                .HasPrecision(3)
                .HasColumnName("NOME");
        });

        modelBuilder.Entity<OdontoPlano>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C003844974");

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
            entity.HasKey(e => e.Id).HasName("SYS_C003844977");

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
            entity.HasKey(e => e.Id).HasName("SYS_C003844979");

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
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
