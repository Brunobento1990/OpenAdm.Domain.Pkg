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
        ValidationEmail.ValidWithLength(email);
        ValidationString.ValidateWithLength(servidor, message: CodigoErrors.ServidorInvalido);
        ValidationString.ValidateWithLength(senha, message: CodigoErrors.SenhaInvalida);
        ValidationInt.ValidateIntNullAndZero(porta, message: CodigoErrors.PortaInvalida);

        Email = email;
        Servidor = servidor;
        Senha = senha;
        Porta = porta;
        Ativo = ativo;
    }

    public string Email { get; private set; }
    public string Servidor { get; private set; }
    public string Senha { get; private set; }
    public int Porta { get; private set; }
    public bool Ativo { get; private set; }
}
