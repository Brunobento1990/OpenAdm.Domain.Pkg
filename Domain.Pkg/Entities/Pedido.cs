using Domain.Pkg.Entities.Bases;
using Domain.Pkg.Enum;
using Domain.Pkg.Errors;
using Domain.Pkg.Exceptions;
using Domain.Pkg.Model;
using Domain.Pkg.Validations;

namespace Domain.Pkg.Entities;

public sealed class Pedido : BaseEntity
{
    public Pedido(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        StatusPedido statusPedido,
        Guid usuarioId)
            : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        ValidationGuid.ValidGuidNullAndEmpty(usuarioId);
        StatusPedido = statusPedido;
        UsuarioId = usuarioId;
    }

    public StatusPedido StatusPedido { get; private set; }
    public Guid UsuarioId { get; private set; }
    public Usuario Usuario { get; set; } = null!;
    public decimal ValorTotal { get { return ItensPedido.Sum(x => x.ValorTotal); } }
    public IList<ItensPedido> ItensPedido { get; set; } = new List<ItensPedido>();

    public void UpdateStatus(StatusPedido statusPedido)
    {
        if (StatusPedido == StatusPedido.Entregue)
            throw new ExceptionApi(CodigoErrors.StatusDoPedidoEntregue);

        StatusPedido = statusPedido;
    }

    public void ProcessarItensPedido(
        IList<PedidoPorPesoModel> pedidoPorPesoModels,
        IList<PedidoPorTamanhoModel> pedidoPorTamanhoModels)
    {
        if (pedidoPorPesoModels.Count == 0 && pedidoPorTamanhoModels.Count == 0)
            throw new ExceptionApi(CodigoErrors.PedidoSemItens);

        foreach (var pedidoPorTamanhoModel in pedidoPorTamanhoModels)
        {

            ItensPedido.Add(new ItensPedido(
                id: Guid.NewGuid(),
                dataDeCriacao: DataDeCriacao,
                dataDeAtualizacao: DataDeAtualizacao,
                numero: 0,
                pesoId: null,
                tamanhoId: pedidoPorTamanhoModel.TamanhoId,
                produtoId: pedidoPorTamanhoModel.ProdutoId,
                pedidoId: Id,
                pedidoPorTamanhoModel.ValorUnitario,
                quantidade: pedidoPorTamanhoModel.Quantidade));
        };

        foreach (var pedidoPorPesoModel in pedidoPorPesoModels)
        {

            ItensPedido.Add(new ItensPedido(
                id: Guid.NewGuid(),
                dataDeCriacao: DataDeCriacao,
                dataDeAtualizacao: DataDeAtualizacao,
                numero: 0,
                pesoId: pedidoPorPesoModel.PesoId,
                tamanhoId: null,
                produtoId: pedidoPorPesoModel.ProdutoId,
                pedidoId: Id,
                pedidoPorPesoModel.ValorUnitario,
                quantidade: pedidoPorPesoModel.Quantidade));
        };
    }
}
