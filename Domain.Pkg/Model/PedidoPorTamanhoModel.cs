using Domain.Pkg.Validations;

namespace Domain.Pkg.Model;

public class PedidoPorTamanhoModel
{
    public PedidoPorTamanhoModel(Guid produtoId, Guid tamanhoId, decimal quantidade)
    {
        ValidationGuid.ValidGuidNullAndEmpty(produtoId);
        ValidationGuid.ValidGuidNullAndEmpty(tamanhoId);
        ValidationDecimal.ValidDecimalNullAndZero(quantidade);

        ProdutoId = produtoId;
        TamanhoId = tamanhoId;
        Quantidade = quantidade;
    }

    public Guid ProdutoId { get; private set; }
    public Guid TamanhoId { get; private set; }
    public decimal Quantidade { get; private set; }
}
