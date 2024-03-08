using Domain.Pkg.Entities.Bases;

namespace Domain.Pkg.Entities;

public sealed class LojasParceiras : BaseEntity
{
    public LojasParceiras(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        string? nomeFoto,
        string? foto,
        string? instagram,
        string? facebook,
        string? endereco,
        string? contato)
        : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        NomeFoto = nomeFoto;
        Foto = foto;
        Instagram = instagram;
        Facebook = facebook;
        Endereco = endereco;
        Contato = contato;
    }

    public string? NomeFoto { get; set; }
    public string? Foto { get; set; }
    public string? Instagram { get; set; }
    public string? Facebook { get; set; }
    public string? Endereco { get; set; }
    public string? Contato { get; set; }
}
