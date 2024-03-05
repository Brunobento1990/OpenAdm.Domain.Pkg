using Domain.Pkg.Entities.Bases;
using System.Text.Json.Serialization;
using Domain.Pkg.Validations;
using Domain.Pkg.Errors;
using System.Text;

namespace Domain.Pkg.Entities;

public class Categoria : BaseEntity
{
    [JsonConstructor]
    public Categoria(Guid id, DateTime dataDeCriacao, DateTime dataDeAtualizacao, long numero, string descricao, string? foto, string? nomeFoto)
        : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        ValidationString.ValidateWithLength(descricao, message: CodigoErrors.CampoDescricaoNumeroMaximoDeCaracter);
        Descricao = descricao;
        Foto = foto;
        NomeFoto = nomeFoto;
    }

    public void Update(string descricao, string? foto, string? nomeFoto)
    {
        ValidationString.ValidateWithLength(descricao, message: CodigoErrors.CampoDescricaoNumeroMaximoDeCaracter);
        Descricao = descricao;
        NomeFoto = nomeFoto;
        Foto = foto;
    }

    public string Descricao { get; private set; }
    public string? Foto { get; private set; }
    public string? NomeFoto { get; private set; }
    public List<Produto> Produtos { get; set; } = new();
}
