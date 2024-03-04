using Domain.Pkg.Entities.Bases;
using Domain.Pkg.Enum;

namespace Domain.Pkg.Entities;

public class MovimentacaoDeProduto : BaseEntity
{
    public MovimentacaoDeProduto(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        decimal quantidadeMovimentada,
        TipoMovimentacaoDeProduto tipoMovimentacaoDeProduto)
        : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        QuantidadeMovimentada = quantidadeMovimentada;
        TipoMovimentacaoDeProduto = tipoMovimentacaoDeProduto;
    }

    public decimal QuantidadeMovimentada { get; private set; }
    public TipoMovimentacaoDeProduto TipoMovimentacaoDeProduto { get; private set; }
}
