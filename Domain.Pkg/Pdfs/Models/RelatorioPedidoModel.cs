namespace Domain.Pkg.Pdfs.Models;

public sealed class RelatorioPedidoModel
{
    public RelatorioPedidoModel(
        DateTime dataInicial, 
        DateTime dataFinal, 
        string? logo, 
        decimal total)
    {
        DataInicial = dataInicial;
        DataFinal = dataFinal;
        Logo = logo;
        Total = total;
    }
    public DateTime DataInicial { get; private set; }
    public DateTime DataFinal { get; private set; }
    public string? Logo { get; private set; }
    public decimal Total { get; private set; }
    public IList<RelatorioItensPedidoModel> RelatorioItensPedidoModel { get; set; } = new List<RelatorioItensPedidoModel>();
}
