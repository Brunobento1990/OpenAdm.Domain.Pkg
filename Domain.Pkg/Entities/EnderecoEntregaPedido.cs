﻿using Domain.Pkg.Entities.Bases;

namespace Domain.Pkg.Entities;

public sealed class EnderecoEntregaPedido : BaseEntity
{
    public EnderecoEntregaPedido(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        string cep,
        decimal frete,
        string logradouro,
        string? complemento,
        string bairro,
        string localidade,
        string uf,
        string numeroEntrega,
        string tipoFrete)
            : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        Cep = cep;
        Frete = frete;
        Logradouro = logradouro;
        Complemento = complemento;
        Bairro = bairro;
        Localidade = localidade;
        Uf = uf;
        NumeroEntrega = numeroEntrega;
        TipoFrete = tipoFrete;
    }

    public string Cep { get; private set; }
    public decimal Frete { get; private set; }
    public string Logradouro { get; private set; }
    public string NumeroEntrega { get; private set; }
    public string? Complemento { get; private set; }
    public string Bairro { get; private set; }
    public string Localidade { get; private set; }
    public string Uf { get; private set; }
    public string TipoFrete { get; private set; }
    public Pedido Pedido { get; set; } = null!;
}
