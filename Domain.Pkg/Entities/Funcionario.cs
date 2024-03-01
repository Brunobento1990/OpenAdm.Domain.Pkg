using Domain.Pkg.Entities.Bases;
using Domain.Pkg.Errors;
using Domain.Pkg.Validations;

namespace Domain.Pkg.Entities;

public sealed class Funcionario : BaseEntity
{
    public Funcionario(Guid id, DateTime dataDeCriacao, DateTime dataDeAtualizacao, long numero, string email, string senha, string nome, string? telefone, byte[]? avatar)
        : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        ValidationEmail.ValidWithLength(email);
        ValidationString.ValidateWithLength(nome, 255, CodigoErrors.ErrorNomeInvalido);
        ValidationString.ValidateWithLength(senha, 1000, CodigoErrors.ErrorNomeInvalido);
        ValidationString.ValidateTelefone(telefone);

        Email = email;
        Senha = senha;
        Nome = nome;
        Telefone = telefone;
        Avatar = avatar;
    }

    public string Email { get; private set; }
    public string Senha { get; private set; }
    public string Nome { get; private set; }
    public string? Telefone { get; private set; }
    public byte[]? Avatar { get; private set; }
}
