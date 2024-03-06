namespace Domain.Pkg.Interfaces;

public interface ICalcularValorUnitarioPedido
{
    decimal GetValorUnitarioByTamanhoId(Guid produtoId, Guid? tamanhoId);
    decimal GetValorUnitarioByPesoId(Guid produtoId, Guid? pesoId);
}
