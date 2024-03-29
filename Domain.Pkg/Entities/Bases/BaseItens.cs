﻿namespace Domain.Pkg.Entities.Bases;

public abstract class BaseItens : BaseEntity
{
    protected BaseItens(Guid id, DateTime dataDeCriacao, DateTime dataDeAtualizacao, long numero, Guid produtoId)
        : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        ProdutoId = produtoId;
    }

    public Guid ProdutoId { get; protected set; }
    public Produto Produto { get; set; } = null!;
}
