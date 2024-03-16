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

    public void ProcessarItensPedido(IList<ItensPedidoModel> itensPedidoModels)
    {
        if (itensPedidoModels.Count == 0)
            throw new ExceptionApi(CodigoErrors.PedidoSemItens);

        ItensPedido = itensPedidoModels
            .Select(x => 
                new ItensPedido(
                    Guid.NewGuid(),
                    DataDeCriacao,
                    DataDeAtualizacao,
                    0,
                    x.PesoId,
                    x.TamanhoId,
                    x.ProdutoId,
                    Id,
                    x.ValorUnitario,
                    x.Quantidade))
            .ToList();  
    }
}
