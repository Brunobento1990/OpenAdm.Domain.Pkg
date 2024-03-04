using Domain.Pkg.Entities;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Domain.Pkg.Pdfs.Services;

public class PedidoPdfService
{
    private static readonly IList<string> _colunsName = new List<string>()
        {
            "REF",
            "Descrição",
            "Tamanho/Peso",
            "Quantidade",
            "Valor unitário",
            "Total"
        };
    private static readonly IList<int> _colunsWidt = new List<int>()
        {
            60,150,80,70,90,50
        };

    public static byte[] GeneratePdfAsync(Pedido pedido, string? logo = null)
    {
        void HeaderCustom(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(18).SemiBold();
            var titleStyle2 = TextStyle.Default.FontSize(10).SemiBold();
            var titleStyleName = TextStyle.Default.FontSize(10);

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text($"#Iscas Lune").Style(titleStyle);

                    column.Item().Text(text =>
                    {
                        text.Span("Data de emissão: ").SemiBold().FontSize(14);
                        text.Span(pedido.DataDeCriacao.ToString("dd/MM/yyyy"));
                    });

                    column.Item().PaddingTop(10).Text(text =>
                    {
                        text.Span("Cliente: ").Style(titleStyle2);
                        text.Span(pedido.Usuario.Nome).Style(titleStyleName);
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Email: ").Style(titleStyle2);
                        text.Span(pedido.Usuario.Email).Style(titleStyleName);
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Telefone: ").Style(titleStyle2);
                        text.Span(pedido.Usuario.Telefone).Style(titleStyleName);
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("CNPJ: ").Style(titleStyle2);
                        text.Span(pedido.Usuario.Cnpj).Style(titleStyleName);
                    });
                    column.Item().PaddingTop(10).Text(text =>
                    {
                        text.Span("Número: ").Style(titleStyle2);
                        text.Span(pedido.Numero.ToString()).Style(titleStyleName);
                    });
                });

                if (!string.IsNullOrWhiteSpace(logo))
                {
                    row.ConstantItem(50).Height(50).Image(Convert.FromBase64String(logo));
                }

            });
        }

        static IContainer CellStyleHeaderTable(IContainer container)
        {
            return container
                .DefaultTextStyle(x => x.SemiBold())
                .PaddingVertical(5)
                .BorderBottom(1)
                .BorderColor(Colors.Black);
        }

        static IContainer CellTableStyle(IContainer container)
        {
            return container
                .BorderBottom(1)
                .BorderColor(Colors.Grey.Lighten2)
                .PaddingVertical(5);
        }


        var pdf = Document
            .Create(container =>
            {
                container.Page(page =>
                {
                    page.Configurar();
                    page.Header().Element(HeaderCustom);
                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            foreach (var columnsWidth in _colunsWidt)
                            {
                                columns.ConstantColumn(columnsWidth);
                            }
                        });

                        table.Header(header =>
                        {
                            foreach (var columnsName in _colunsName)
                            {
                                header
                                    .Cell()
                                    .Element(CellStyleHeaderTable)
                                    .Text(columnsName)
                                    .FontSize(10);
                            }
                        });

                        pedido.ItensPedido = [.. pedido.ItensPedido.OrderBy(x => x.Numero)];
                        var itemsPedidosGroup = pedido.ItensPedido.GroupBy(x => x.ProdutoId);

                        foreach (var itensGroup in itemsPedidosGroup)
                        {
                            foreach (var item in itensGroup)
                            {
                                table
                                .Cell()
                                .Element(CellTableStyle)
                                .Text(item.Produto.Referencia)
                                .FontSize(8);

                                table
                                .Cell()
                                .Element(CellTableStyle)
                                .Text(item.Produto.Descricao)
                                .FontSize(8);

                                table
                                .Cell()
                                .Element(CellTableStyle)
                                .Text(item.Tamanho?.Descricao ?? item.Peso?.Descricao)
                                .FontSize(8);

                                table
                                .Cell()
                                .Element(CellTableStyle)
                                .Text(item.Quantidade.ToString().Replace(".", ","))
                                .FontSize(8);

                                table
                                .Cell()
                                .Element(CellTableStyle)
                                .Text(item.ValorUnitario.ToString().Replace(".", ","))
                                .FontSize(8);

                                table
                                .Cell()
                                .Element(CellTableStyle)
                                .Text(item.ValorTotal.ToString().Replace(".", ","))
                                .FontSize(8);
                            }
                        }

                        table.Cell();
                        table.Cell();
                        table.Cell();
                        table.Cell();
                        table.Cell();

                        table
                            .Cell()
                            .Element(CellTableStyle)
                            .Text($"Total : {pedido.ValorTotal.ToString().Replace(".", ",")}")
                            .FontSize(8);


                        var tamamhosItens = pedido
                            .ItensPedido
                            .OrderBy(x => x.Tamanho?.Numero)
                            .Where(x => x.Tamanho != null)
                            .Select(x => x.Tamanho)
                            .ToList()
                            .GroupBy(x => x?.Id);

                        var pesosItens = pedido
                            .ItensPedido
                            .OrderBy(x => x.Peso?.Numero)
                            .Where(x => x.Peso != null)
                            .Select(x => x.Peso)
                            .ToList()
                            .GroupBy(x => x?.Id);


                        if (tamamhosItens.Any())
                        {
                            table
                            .Cell()
                            .Element(CellStyleHeaderTable)
                            .Text($"Tamanhos")
                            .FontSize(10);
                        }

                        var count = 0;

                        foreach (var tamanhoGroup in tamamhosItens)
                        {

                            if (count > 0)
                            {
                                table.Cell();
                            }

                            table.Cell();
                            table.Cell();
                            table.Cell();
                            table.Cell();
                            table.Cell();
                            var itemPedido = pedido
                                .ItensPedido
                                .FirstOrDefault(x => x.TamanhoId == tamanhoGroup.Key);

                            var totalQuantidade = pedido
                                .ItensPedido
                                .Where(x => x.TamanhoId == tamanhoGroup.Key)
                                .ToList()
                                .Sum(x => x.Quantidade);

                            table
                                .Cell()
                                .Element(CellTableStyle)
                                .Text($"{itemPedido?.Tamanho?.Descricao} : {totalQuantidade.ToString().Replace(".", ",")}")
                                .FontSize(8);
                            table.Cell();
                            table.Cell();
                            table.Cell();
                            table.Cell();
                            table.Cell();

                            count++;
                        }

                        if (pesosItens.Any())
                        {
                            table
                            .Cell()
                            .Element(CellStyleHeaderTable)
                            .Text($"Pesos")
                            .FontSize(10);
                        }

                        count = 0;

                        foreach (var pedoGroup in pesosItens)
                        {
                            if (count > 0)
                            {
                                table.Cell();
                            }

                            table.Cell();
                            table.Cell();
                            table.Cell();
                            table.Cell();
                            table.Cell();
                            var itemPedido = pedido
                                .ItensPedido
                                .FirstOrDefault(x => x.PesoId == pedoGroup.Key);

                            var totalQuantidade = pedido
                                .ItensPedido
                                .Where(x => x.PesoId == pedoGroup.Key)
                                .ToList()
                                .Sum(x => x.Quantidade);

                            table
                                .Cell()
                                .Element(CellTableStyle)
                                .Text($"{itemPedido?.Peso?.Descricao} : {totalQuantidade.ToString().Replace(".", ",")}")
                                .FontSize(8);

                            count++;
                        }
                    });
                    page.FooterCustom();
                });
            }).GeneratePdf();

        return pdf;
    }
}
