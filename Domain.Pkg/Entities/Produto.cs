using Domain.Pkg.Entities.Bases;
using Domain.Pkg.Errors;
using Domain.Pkg.Validations;

namespace Domain.Pkg.Entities;

public sealed class Produto : BaseEntity
{
    public Produto(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        string descricao,
        string? especificacaoTecnica,
        byte[] foto,
        Guid categoriaId,
        string? referencia)
        : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        ValidationString.ValidateWithLength(descricao, message: CodigoErrors.CampoDescricaoNumeroMaximoDeCaracter);
        ValidationString.ValidateLength(especificacaoTecnica, 500, message: CodigoErrors.EspecificacaoTecnicaLimite);
        ValidationString.ValidateLength(referencia, message: CodigoErrors.CampoReferenciaLimite);

        Descricao = descricao;
        EspecificacaoTecnica = especificacaoTecnica;
        Foto = foto;
        CategoriaId = categoriaId;
        Referencia = referencia;
    }

    public string Descricao { get; private set; }
    public string? EspecificacaoTecnica { get; private set; }
    public byte[] Foto { get; set; }
    public List<Tamanho> Tamanhos { get; set; } = new();
    public List<Peso> Pesos { get; set; } = new();
    public Guid CategoriaId { get; private set; }
    public Categoria Categoria { get; set; } = null!;
    public List<ItensPedido> ItensPedido { get; set; } = new();
    public List<ItensTabelaDePreco> ItensTabelaDePreco { get; set; } = new();
    public string? Referencia { get; private set; }

    public void Update(
        string descricao,
        string? especificacaoTecnica,
        byte[] foto,
        Guid categoriaId,
        string? referencia)
    {
        ValidationString.ValidateWithLength(descricao, message: CodigoErrors.CampoDescricaoNumeroMaximoDeCaracter);
        ValidationString.ValidateLength(especificacaoTecnica, 500, message: CodigoErrors.EspecificacaoTecnicaLimite);
        ValidationString.ValidateLength(referencia, message: CodigoErrors.CampoReferenciaLimite);

        Descricao = descricao;
        EspecificacaoTecnica = especificacaoTecnica;
        Foto = foto;
        CategoriaId = categoriaId;
        Referencia = referencia;
    }
}
