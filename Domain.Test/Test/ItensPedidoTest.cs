using Domain.Pkg.Entities;
using OpenAdm.Test.Domain.Builder;
using Domain.Pkg.Exceptions;

namespace OpenAdm.Test.Domain.Test;

public class ItensPedidoTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(0)]
    public void NaoDeveCriarItemPedidoSemQuantidade(int? quantidade)
    {
        Assert.Throws<ExceptionApi>(() => ItensPedidoBuilder.Init().SemQuantidade(quantidade).Build());
    }

    [Fact]
    public void NaoDeveCriarItemPedidoSemPedidoId()
    {
        Assert.Throws<ExceptionApi>(() => ItensPedidoBuilder.Init().SemPedidoId(Guid.Empty).Build());
    }

    [Fact]
    public void NaoDeveCriarItemPedidoSemProdutoId()
    {
        Assert.Throws<ExceptionApi>(() => ItensPedidoBuilder.Init().SemProdutoId(Guid.Empty).Build());
    }

    [Fact]
    public void DeveCriarItemPedido()
    {
        var dto = ItensPedidoBuilder.Init().Build();

        var itemPedido = new ItensPedido(
            dto.Id,
            dto.DataDeCriacao,
            dto.DataDeAtualizacao,
            dto.Numero,
            dto.PesoId,
            dto.TamanhoId,
            dto.ProdutoId,
            dto.PedidoId,
            dto.ValorUnitario,
            dto.Quantidade);

        Assert.Equal(dto.Id, itemPedido.Id);
        Assert.Equal(dto.DataDeCriacao, itemPedido.DataDeCriacao);
        Assert.Equal(dto.DataDeAtualizacao, itemPedido.DataDeAtualizacao);
        Assert.Equal(dto.Numero, itemPedido.Numero);
        Assert.Equal(dto.PesoId, itemPedido.PesoId);
        Assert.Equal(dto.TamanhoId, itemPedido.TamanhoId);
        Assert.Equal(dto.ProdutoId, itemPedido.ProdutoId);
        Assert.Equal(dto.PedidoId, itemPedido.PedidoId);
        Assert.Equal(dto.ValorUnitario, itemPedido.ValorUnitario);
        Assert.Equal(dto.Quantidade, itemPedido.Quantidade);
    }
}
