using Domain.Pkg.Entities.Bases;
using Domain.Pkg.Errors;
using Domain.Pkg.Validations;

namespace Domain.Pkg.Entities;

public sealed class ConfiguracaoDeEmail : BaseEntity
{
    public ConfiguracaoDeEmail(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        string email,
        string servidor,
        string senha,
        int porta,
        bool ativo)
            : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        Email = email;
        Servidor = servidor;
        Senha = senha;
        Porta = porta;
        Ativo = ativo;

        Validate();
    }

    private void Validate()
    {
        ValidationEmail.ValidWithLength(Email);
        ValidationString.ValidateWithLength(Servidor, message: CodigoErrors.ServidorInvalido);
        ValidationString.ValidateWithLength(Senha, message: CodigoErrors.SenhaInvalida);
        ValidationInt.ValidateIntNullAndZero(Porta, message: CodigoErrors.PortaInvalida);
    }

    public void Update(string email, string servidor, string senha, int porta, bool ativo)
    {
        Email = email;
        Servidor = servidor;
        Senha = senha;
        Porta = porta;
        Ativo = ativo;

        Validate();
    }

    public string Email { get; private set; }
    public string Servidor { get; private set; }
    public string Senha { get; private set; }
    public int Porta { get; private set; }
    public bool Ativo { get; private set; }
}
