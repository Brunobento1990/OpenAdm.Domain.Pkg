using Domain.Pkg.Entities.Bases;

namespace Domain.Pkg.Entities;

public class Estoque : BaseEntity
{
    public Estoque(Guid id, DateTime dataDeCriacao, DateTime dataDeAtualizacao, long numero, Guid produtoId, decimal quantidade)
        : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        ProdutoId = produtoId;
        Quantidade = quantidade;
    }

    public Guid ProdutoId { get; private set; }
    public decimal Quantidade { get; private set; }
}
