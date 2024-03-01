using Domain.Pkg.Entities.Bases;
using System.Text.Json.Serialization;
using System.Text;

namespace Domain.Pkg.Entities;

public sealed class Banner : BaseEntity
{
    [JsonConstructor]
    public Banner(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        byte[] foto,
        bool ativo)
        : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        Foto = foto;
        Ativo = ativo;
    }

    public byte[] Foto { get; private set; }
    public bool Ativo { get; private set; }

    public void Update(string foto, bool? ativo)
    {
        Foto = Encoding.UTF8.GetBytes(foto);
        Ativo = ativo != null ? ativo.Value : Ativo;
    }
}
