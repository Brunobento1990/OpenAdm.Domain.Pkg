﻿using Domain.Pkg.Entities.Bases;
using Domain.Pkg.Errors;
using Domain.Pkg.Validations;

namespace Domain.Pkg.Entities;

public sealed class Usuario : BaseEntity
{
    public Usuario(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        string email,
        string senha,
        string nome,
        string? telefone,
        string? cnpj)
            : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        ValidationEmail.ValidWithLength(email);
        ValidationString.ValidateWithLength(nome, message: CodigoErrors.NomeInvalido);
        ValidationString.ValidateTelefone(telefone);
        ValidationString.Validate(senha, CodigoErrors.SenhaInvalida);
        Email = email;
        Senha = senha;
        Nome = nome;
        Telefone = telefone;
        Cnpj = cnpj;
    }

    public string Email { get; private set; }
    public string Senha { get; private set; }
    public string Nome { get; private set; }
    public string? Telefone { get; private set; }
    public string? Cnpj { get; set; }

    public void UpdateSenha(string senha)
    {
        Senha = senha;
    }

    public void Update(string email, string nome, string? telefone, string? cnpj)
    {
        Cnpj = cnpj;
        Email = email;
        Nome = nome;
        Telefone = telefone;
    }
}
