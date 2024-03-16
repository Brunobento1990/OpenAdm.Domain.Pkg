using Domain.Pkg.Entities.Bases;

namespace Domain.Pkg.Entities;

public sealed class TopUsuarios : BaseEntity
{
    public TopUsuarios(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        decimal totalCompra,
        int totalPedidos,
        Guid usuarioId,
        string usuario)
            : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        TotalCompra = totalCompra;
        TotalPedidos = totalPedidos;
        UsuarioId = usuarioId;
        Usuario = usuario;
    }

    public void Update(decimal totalCompra, int totalPedidos)
    {
        TotalCompra += totalCompra;
        TotalPedidos += totalPedidos;
    }

    public decimal TotalCompra { get; private set; }
    public int TotalPedidos { get; private set; }
    public Guid UsuarioId { get; private set; }
    public string Usuario { get; private set; }
}
