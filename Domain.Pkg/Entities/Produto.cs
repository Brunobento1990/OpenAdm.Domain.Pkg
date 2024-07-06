﻿using Domain.Pkg.Entities.Bases;
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
        Guid categoriaId,
        string? referencia,
        string? urlFoto,
        string? nomeFoto,
        decimal? peso)
        : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        ValidationString.ValidateWithLength(descricao, message: CodigoErrors.CampoDescricaoNumeroMaximoDeCaracter);
        ValidationString.ValidateLength(especificacaoTecnica, 500, message: CodigoErrors.EspecificacaoTecnicaLimite);
        ValidationString.ValidateLength(referencia, message: CodigoErrors.CampoReferenciaLimite);

        Descricao = descricao;
        EspecificacaoTecnica = especificacaoTecnica;
        CategoriaId = categoriaId;
        Referencia = referencia;
        UrlFoto = urlFoto;
        NomeFoto = nomeFoto;
        Peso = peso;
    }

    public string Descricao { get; private set; }
    public string? EspecificacaoTecnica { get; private set; }
    public List<Tamanho> Tamanhos { get; set; } = new();
    public List<Peso> Pesos { get; set; } = new();
    public Guid CategoriaId { get; private set; }
    public Categoria Categoria { get; set; } = null!;
    public List<ItensPedido> ItensPedido { get; set; } = new();
    public List<ItensTabelaDePreco> ItensTabelaDePreco { get; set; } = new();
    public string? Referencia { get; private set; }
    public string? UrlFoto { get; private set; }
    public string? NomeFoto { get; private set; }
    public decimal? Peso { get; private set; }

    public void Update(
        string descricao,
        string? especificacaoTecnica,
        Guid categoriaId,
        string? referencia,
        string? urlFoto,
        string? nomeFoto,
        decimal? peso)
    {
        ValidationString.ValidateWithLength(descricao, message: CodigoErrors.CampoDescricaoNumeroMaximoDeCaracter);
        ValidationString.ValidateLength(especificacaoTecnica, 500, message: CodigoErrors.EspecificacaoTecnicaLimite);
        ValidationString.ValidateLength(referencia, message: CodigoErrors.CampoReferenciaLimite);

        Peso = peso;
        UrlFoto = urlFoto;
        Descricao = descricao;
        EspecificacaoTecnica = especificacaoTecnica;
        CategoriaId = categoriaId;
        Referencia = referencia;
        NomeFoto = nomeFoto;
    }
}
