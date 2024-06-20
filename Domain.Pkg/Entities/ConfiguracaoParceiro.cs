using Domain.Pkg.Entities.Bases;
using Domain.Pkg.Validations;

namespace Domain.Pkg.Entities;

public sealed class ConfiguracaoParceiro : BaseEntity
{
    public ConfiguracaoParceiro(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        string conexaoDb,
        string dominioSiteAdm,
        string dominioSiteEcommerce,
        bool ativo,
        Guid parceiroId,
        string? clienteMercadoPago,
        Guid xApi)
        : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        ValidationString.Validate(conexaoDb);
        ValidationString.Validate(dominioSiteAdm);
        ValidationString.Validate(dominioSiteEcommerce);

        DominioSiteEcommerce = dominioSiteEcommerce;
        DominioSiteAdm = dominioSiteAdm;
        ConexaoDb = conexaoDb;
        Ativo = ativo;
        ParceiroId = parceiroId;
        ClienteMercadoPago = clienteMercadoPago;
        XApi = xApi;
    }

    public string ConexaoDb { get; private set; }
    public string DominioSiteAdm { get; private set; }
    public string DominioSiteEcommerce { get; private set; }
    public string? ClienteMercadoPago { get; private set; }
    public Guid XApi { get; private set; }
    public bool Ativo { get; private set; }
    public Guid ParceiroId { get; private set; }
    public Parceiro Parceiro { get; set; } = null!;
}
