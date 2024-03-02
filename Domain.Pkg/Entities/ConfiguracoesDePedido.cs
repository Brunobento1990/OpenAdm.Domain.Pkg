using Domain.Pkg.Entities.Bases;
using Domain.Pkg.Validations;

namespace Domain.Pkg.Entities;

public class ConfiguracoesDePedido : BaseEntity
{
    public ConfiguracoesDePedido(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        string emailDeEnvio,
        byte[]? logo,
        bool ativo)
            : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        ValidationEmail.ValidWithLength(emailDeEnvio);
        EmailDeEnvio = emailDeEnvio;
        Ativo = ativo;
        Logo = logo;
    }

    public void Update(string emailDeEnvio, bool ativo, byte[]? logo)
    {
        ValidationEmail.ValidWithLength(emailDeEnvio);
        EmailDeEnvio = emailDeEnvio;
        Ativo = ativo;
        Logo = logo;
    }

    public string EmailDeEnvio { get; private set; }
    public bool Ativo { get; private set; }
    public byte[]? Logo { get; set; }
}
