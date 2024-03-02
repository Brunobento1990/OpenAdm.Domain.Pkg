using Domain.Pkg.Entities.Bases;
using Domain.Pkg.Validations;

namespace Domain.Pkg.Entities;

public sealed class ItensTabelaDePreco : BaseItens
{
    public ItensTabelaDePreco(Guid id, DateTime dataDeCriacao, DateTime dataDeAtualizacao, long numero, Guid produtoId, decimal valorUnitario, Guid tabelaDePrecoId, Guid? tamanhoId, Guid? pesoId) : base(id, dataDeCriacao, dataDeAtualizacao, numero, produtoId)
    {
        ValidationDecimal.ValidDecimalNullAndZero(valorUnitario);
        ValorUnitario = valorUnitario;
        TabelaDePrecoId = tabelaDePrecoId;
        TamanhoId = tamanhoId;
        PesoId = pesoId;
    }

    public void Update(decimal valorUnitario, Guid? tamanhoId, Guid? pesoId, Guid produtoId)
    {
        ValidationDecimal.ValidDecimalNullAndZero(valorUnitario);
        ValorUnitario = valorUnitario;
        TamanhoId = tamanhoId;
        PesoId = pesoId;
        ProdutoId = produtoId;
    }

    public decimal ValorUnitario { get; private set; }
    public Guid TabelaDePrecoId { get; private set; }
    public TabelaDePreco TabelaDePreco { get; set; } = null!;
    public Guid? TamanhoId { get; private set; }
    public Guid? PesoId { get; private set; }
}
