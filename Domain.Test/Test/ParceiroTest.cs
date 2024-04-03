using Domain.Pkg.Entities;
using Domain.Pkg.Exceptions;
using OpenAdm.Test.Domain.Builder;

namespace OpenAdm.Test.Domain.Test;

public class ParceiroTest
{
    [Fact]
    public void DeveCriarParceiro()
    {
        var dto = new
        {
            RazaoSocial = "Empresa fake",
            NomeFantasia = "Criou Ok",
            Cnpj = "56198156165"
        };

        var parceiro = new Parceiro(
            Guid.NewGuid(), 
            DateTime.Now, 
            DateTime.Now, 
            1, 
            dto.RazaoSocial, 
            dto.NomeFantasia, 
            dto.Cnpj);

        Assert.NotNull(parceiro);
        Assert.Equal(dto.RazaoSocial, parceiro.RazaoSocial);
        Assert.Equal(dto.NomeFantasia, parceiro.NomeFantasia);
        Assert.Equal(dto.Cnpj, parceiro.Cnpj);
    }


    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void NaoDeveCriarParceiroSemCnpj(string cnpj)
    {
        Assert.Throws<ExceptionApi>(
            () => ParceiroBuilder
                    .Init()
                    .NaoDeveCriarSemCnpj(cnpj)
                    .Build());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void NaoDeveCriarParceiroSemRazaoSocial(string razaoSocial)
    {
        Assert.Throws<ExceptionApi>(
            () => ParceiroBuilder
                    .Init()
                    .NaoDeveCriarSemRazaoSocial(razaoSocial)
                    .Build());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void NaoDeveCriarParceiroSemNomeFantasia(string nomeFantasia)
    {
        Assert.Throws<ExceptionApi>(
            () => ParceiroBuilder
                    .Init()
                    .NaoDeveCriarSemNomeFantasia(nomeFantasia)
                    .Build());
    }
}
