using Domain.Pkg.Entities.Bases;
using Domain.Pkg.Errors;
using Domain.Pkg.Validations;

namespace Domain.Pkg.Entities;

public sealed class TabelaDePreco : BaseEntity
{
    public TabelaDePreco(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        string descricao,
        bool ativaEcommerce)
            : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        ValidationString.ValidateWithLength(descricao, message: CodigoErrors.DescricaoTabelaDePrecoInvalida);
        Descricao = descricao;
        AtivaEcommerce = ativaEcommerce;
    }

    public string Descricao { get; private set; }
    public bool AtivaEcommerce { get; private set; }
    public List<ItensTabelaDePreco> ItensTabelaDePreco { get; set; } = new();

    public void Update(string descricao, bool ativaEcommerce)
    {
        ValidationString.ValidateWithLength(descricao, message: CodigoErrors.DescricaoTabelaDePrecoInvalida);
        Descricao = descricao;
        AtivaEcommerce = ativaEcommerce;
    }
}
