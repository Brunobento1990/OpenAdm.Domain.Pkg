using Domain.Pkg.Entities;
using Domain.Pkg.Exceptions;
using OpenAdm.Test.Domain.Builder;

namespace OpenAdm.Test.Domain.Test;

public class ConfiguracaoParceiroTest
{
    [Fact]
    public void DeveCriarConfiguracaoParceiro()
    {
        var dto = new
        {
            ConexaoDb = "postgres",
            DominioSiteAdm = "https://localhost:3000",
            DominioSiteEcommerce = "https://localhost:3001",
            Ativo = true,
            ParceiroId = Guid.NewGuid()
        };

        var configuracao = new ConfiguracaoParceiro(
            Guid.NewGuid(),
            DateTime.Now,
            DateTime.Now,
            1,
            dto.ConexaoDb,
            dto.DominioSiteAdm,
            dto.DominioSiteEcommerce,
            dto.Ativo,
            dto.ParceiroId,
            null,
            Guid.NewGuid());

        Assert.Equal(dto.ConexaoDb, configuracao.ConexaoDb);
        Assert.Equal(dto.DominioSiteAdm, configuracao.DominioSiteAdm);
        Assert.Equal(dto.DominioSiteEcommerce, configuracao.DominioSiteEcommerce);
        Assert.Equal(dto.Ativo, configuracao.Ativo);
        Assert.Equal(dto.ParceiroId, configuracao.ParceiroId);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void NaoDeveCriarSemConexaoDb(string conexaoDb)
    {
        Assert.Throws<ExceptionApi>(
            () => ConfiguracaoParceiroBuilder
                    .Init()
                    .SemStringDb(conexaoDb)
                    .Build());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void NaoDeveCriarSemDominioSiteAdm(string dominio)
    {
        Assert.Throws<ExceptionApi>(
            () => ConfiguracaoParceiroBuilder
                    .Init()
                    .SemDominioSiteAdm(dominio)
                    .Build());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void NaoDeveCriarSemDominioSiteEcommerce(string dominio)
    {
        Assert.Throws<ExceptionApi>(
            () => ConfiguracaoParceiroBuilder
                    .Init()
                    .SemDominioSiteEcommerce(dominio)
                    .Build());
    }
}
