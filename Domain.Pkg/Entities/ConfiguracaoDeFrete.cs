﻿using Domain.Pkg.Entities.Bases;

namespace Domain.Pkg.Entities;

public sealed class ConfiguracaoDeFrete : BaseEntity
{
    public ConfiguracaoDeFrete(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        string cepOrigem,
        string alturaEmbalagem,
        string larguraEmbalagem,
        string comprimentoEmbalagem)
            : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        CepOrigem = cepOrigem;
        AlturaEmbalagem = alturaEmbalagem;
        LarguraEmbalagem = larguraEmbalagem;
        ComprimentoEmbalagem = comprimentoEmbalagem;
    }

    public string CepOrigem { get; private set; }
    public string AlturaEmbalagem { get; private set; }
    public string LarguraEmbalagem { get; private set; }
    public string ComprimentoEmbalagem { get; private set; }
}