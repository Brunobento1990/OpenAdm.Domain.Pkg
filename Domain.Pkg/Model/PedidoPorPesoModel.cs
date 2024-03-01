using Domain.Pkg.Validations;

namespace Domain.Pkg.Model;

public class PedidoPorPesoModel
{
    public PedidoPorPesoModel(Guid produtoId, Guid pesoId, decimal quantidade)
    {
        ValidationGuid.ValidGuidNullAndEmpty(produtoId);
        ValidationGuid.ValidGuidNullAndEmpty(pesoId);
        ValidationDecimal.ValidDecimalNullAndZero(quantidade);

        ProdutoId = produtoId;
        PesoId = pesoId;
        Quantidade = quantidade;
    }

    public Guid ProdutoId { get; private set; }
    public Guid PesoId { get; private set; }
    public decimal Quantidade { get; private set; }
}
