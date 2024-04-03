using Domain.Pkg.Extensions;
using Domain.Pkg.Pdfs.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Domain.Pkg.Pdfs.Services;

public static class RelatorioPedidoService
{
    private static readonly IList<string> _colunsName = new List<string>()
    {
        "N.",
        "Data",
        "Cliente",
        "Quantidade itens",
        "Total"
    };
    private static readonly IList<int> _colunsWidt = new List<int>()
    {
        60,90,170,90,90
    };

    public static byte[] GeneratePdf(RelatorioPedidoModel relatorioPedidoModel)
    {
        void HeaderCustom(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(18).SemiBold();
            var titleStyle2 = TextStyle.Default.FontSize(10).SemiBold();

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text($"#Iscas Lune").Style(titleStyle);
                    column.Item().Text($"Relatório de pedidos por período").Style(titleStyle2);

                    column.Item().Text(text =>
                    {
                        text.Span("Data de inicial: ").SemiBold().FontSize(10);
                        text.Span(relatorioPedidoModel.DataInicial.DateTimeToString());
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Data de final: ").SemiBold().FontSize(10);
                        text.Span(relatorioPedidoModel.DataFinal.DateTimeToString());
                    });
                });

                if (!string.IsNullOrWhiteSpace(relatorioPedidoModel.Logo))
                {
                    row.ConstantItem(50).Height(50).Image(Convert.FromBase64String(relatorioPedidoModel.Logo));
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

                        foreach (var item in relatorioPedidoModel.RelatorioItensPedidoModel)
                        {
                            table
                            .Cell()
                            .Element(CellTableStyle)
                            .Text($"#{item.Numero}")
                            .FontSize(8);

                            table
                            .Cell()
                            .Element(CellTableStyle)
                            .Text(item.DataDeCadastro.DateTimeToString())
                            .FontSize(8);

                            table
                            .Cell()
                            .Element(CellTableStyle)
                            .Text(item.Cliente)
                            .FontSize(8);

                            table
                            .Cell()
                            .Element(CellTableStyle)
                            .Text(item.Quantidade.FormatMoney())
                            .FontSize(8);

                            table
                            .Cell()
                            .Element(CellTableStyle)
                            .Text(item.Total.FormatMoney())
                            .FontSize(8);
                        }

                        table.Cell();
                        table.Cell();
                        table.Cell();
                        table.Cell();

                        table
                            .Cell()
                        .Element(CellTableStyle)
                            .Text($"Total : {relatorioPedidoModel.Total.FormatMoney()}")
                        .FontSize(8);
                    });
                    page.FooterCustom();
                });
            }).GeneratePdf();

        return pdf;
    }
}
