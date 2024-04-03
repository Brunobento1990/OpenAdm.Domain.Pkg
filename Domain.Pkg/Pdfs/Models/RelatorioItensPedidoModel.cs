namespace Domain.Pkg.Pdfs.Models;

public sealed class RelatorioItensPedidoModel
{
    public RelatorioItensPedidoModel(
        long numero,
        string cliente,
        decimal quantidade,
        decimal total,
        DateTime dataDeCadastro)
    {
        Numero = numero;
        Cliente = cliente;
        Quantidade = quantidade;
        Total = total;
        DataDeCadastro = dataDeCadastro;
    }

    public long Numero { get; private set; }
    public string Cliente { get; private set; }
    public decimal Quantidade { get; private set; }
    public decimal Total { get; private set; }
    public DateTime DataDeCadastro { get; private set; }
}
