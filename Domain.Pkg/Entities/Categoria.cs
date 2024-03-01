using Domain.Pkg.Entities.Bases;
using System.Text.Json.Serialization;
using Domain.Pkg.Validations;
using Domain.Pkg.Errors;
using System.Text;

namespace Domain.Pkg.Entities;

public class Categoria : BaseEntity
{
    [JsonConstructor]
    public Categoria(Guid id, DateTime dataDeCriacao, DateTime dataDeAtualizacao, long numero, string descricao, byte[]? foto)
        : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        ValidationString.ValidateWithLength(descricao, message: CodigoErrors.CampoDescricaoNumeroMaximoDeCaracter);
        Descricao = descricao;
        Foto = foto;
    }

    public void Update(string descricao, string? foto)
    {
        ValidationString.ValidateWithLength(descricao, message: CodigoErrors.CampoDescricaoNumeroMaximoDeCaracter);
        Descricao = descricao;
        Foto = !string.IsNullOrWhiteSpace(foto) ? Encoding.UTF8.GetBytes(foto) : null;
    }

    public string Descricao { get; private set; }
    public byte[]? Foto { get; private set; }
    public List<Produto> Produtos { get; set; } = new();
}
