using Domain.Pkg.Entities.Bases;
using Domain.Pkg.Enum;

namespace Domain.Pkg.Entities;

public class Estoque : BaseEntity
{
    public Estoque(Guid id, DateTime dataDeCriacao, DateTime dataDeAtualizacao, long numero, Guid produtoId, decimal quantidade, Guid? tamanhoId, Guid? pesoId)
        : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        ProdutoId = produtoId;
        Quantidade = quantidade;
        TamanhoId = tamanhoId;
        PesoId = pesoId;
    }

    public void UpdateEstoqueAtual(decimal quantidade)
    {
        Quantidade = quantidade;
    }

    public void UpdateEstoque(decimal quantidade, TipoMovimentacaoDeProduto tipoMovimentacaoDeProduto)
    {
        if(tipoMovimentacaoDeProduto == TipoMovimentacaoDeProduto.Entrada)
        {
            Quantidade += quantidade;
        }
        else
        {
            Quantidade -= quantidade;
        }
    }

    public Guid ProdutoId { get; private set; }
    public Guid? TamanhoId { get; private set; }
    public Guid? PesoId { get; private set; }
    public decimal Quantidade { get; private set; }
}
