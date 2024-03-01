using Domain.Pkg.Entities.Bases;
using Domain.Pkg.Errors;
using Domain.Pkg.Validations;

namespace Domain.Pkg.Entities;

public sealed class Peso : BaseEntity
{
    public Peso(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        string descricao)
        : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        ValidationString.ValidateWithLength(descricao, message: CodigoErrors.CampoDescricaoNumeroMaximoDeCaracter);
        Descricao = descricao;
    }

    public void Update(string descricao)
    {
        ValidationString.ValidateWithLength(descricao, message: CodigoErrors.CampoDescricaoNumeroMaximoDeCaracter);
        Descricao = descricao;
    }

    public string Descricao { get; private set; }
    public List<ItensPedido> ItensPedido { get; set; } = new();
    public List<Produto> Produtos { get; set; } = new();
}
