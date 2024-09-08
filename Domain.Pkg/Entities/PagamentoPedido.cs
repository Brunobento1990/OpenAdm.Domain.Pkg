using Domain.Pkg.Entities.Bases;

namespace Domain.Pkg.Entities;

public sealed class PagamentoPedido : BaseEntity
{
    public PagamentoPedido(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        string? qrCodePix,
        string? qrCodePixBase64,
        string? linkPagamento,
        long mercadoPagoId,
        bool pago,
        DateTime? dataExpiracaoPix)
            : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        QrCodePix = qrCodePix;
        QrCodePixBase64 = qrCodePixBase64;
        LinkPagamento = linkPagamento;
        MercadoPagoId = mercadoPagoId;
        Pago = pago;
        DataExpiracaoPix = dataExpiracaoPix;
    }

    public string? QrCodePix { get; private set; }
    public string? QrCodePixBase64 { get; private set; }
    public string? LinkPagamento { get; private set; }
    public long MercadoPagoId { get; private set; }
    public bool Pago { get; private set; }
    public DateTime? DataExpiracaoPix { get; private set; }
    public Pedido? Pedido { get; set; } = null!;

    public void UpdatePagamento()
    {
        if (!Pago) Pago = true;
    }
}
