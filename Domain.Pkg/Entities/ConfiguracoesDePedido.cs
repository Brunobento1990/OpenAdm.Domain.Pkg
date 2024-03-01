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
        bool ativo)
            : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        ValidationEmail.ValidWithLength(emailDeEnvio);
        EmailDeEnvio = emailDeEnvio;
        Ativo = ativo;
    }

    public string EmailDeEnvio { get; private set; }
    public bool Ativo { get; private set; }
}
