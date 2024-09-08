using Domain.Pkg.Entities.Bases;
using Domain.Pkg.Enum;

namespace Domain.Pkg.Entities;

public sealed class OrdemDeProducao : BaseEntity
{
    public OrdemDeProducao(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        StatusOrdemDeProducao status,
        DateTime? dataIniciada,
        DateTime? dataFinalizada,
        decimal? custoEstimado,
        decimal? custoReal,
        decimal? quantidadePlanejada,
        decimal? quantidadeProduzida)
            : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        Status = status;
        DataIniciada = dataIniciada;
        DataFinalizada = dataFinalizada;
        CustoEstimado = custoEstimado;
        CustoReal = custoReal;
        QuantidadePlanejada = quantidadePlanejada;
        QuantidadeProduzida = quantidadeProduzida;
    }

    public StatusOrdemDeProducao Status { get; private set; }
    public DateTime? DataIniciada { get; private set; }
    public DateTime? DataFinalizada { get; private set; }
    public decimal? CustoEstimado { get; private set; }
    public decimal? CustoReal { get; private set; }
    public decimal? QuantidadePlanejada { get; private set; }
    public decimal? QuantidadeProduzida { get; private set; }
    public IList<Pedido> Pedidos { get; set; } = [];

    public decimal CalcularEficiência()
    {
        if (!QuantidadePlanejada.HasValue || !QuantidadeProduzida.HasValue)
        {
            return 0;
        }
        return (decimal)QuantidadeProduzida.Value / QuantidadePlanejada.Value * 100;
    }

    public decimal CalcularVariaçãoCusto()
    {
        if(!CustoReal.HasValue || !CustoEstimado.HasValue)
        {
            return 0;
        }

        return CustoReal.Value - CustoEstimado.Value;
    }
}
