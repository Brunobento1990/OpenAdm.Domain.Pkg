﻿using Domain.Pkg.Entities.Bases;

namespace Domain.Pkg.Entities;

public sealed class LojasParceiras : BaseEntity
{
    public LojasParceiras(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        string nome,
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
        Nome = nome;
    }

    public string? NomeFoto { get; private set; }
    public string Nome { get; private set; }
    public string? Foto { get; private set; }
    public string? Instagram { get; private set; }
    public string? Facebook { get; private set; }   
    public string? Endereco { get; private set; }   
    public string? Contato { get; private set; }

    public void Update(string nome, string? nomeFoto, string? foto, string? instagram, string? facebook, string? endereco, string? contato)
    {
        Nome = nome;
        NomeFoto = nomeFoto;
        Foto = foto;
        Instagram = instagram;
        Facebook = facebook;
        Endereco = endereco;
        Contato = contato;
    }
}
