// Configura a cultura para garantir a formatação correta de moeda
using Desafio_Target;
using System.Globalization;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

Console.WriteLine("=================================================");
Console.WriteLine("  PROJETO DESAFIO .NET - VISUAL STUDIO 2022");
Console.WriteLine("=================================================");
Console.WriteLine();

// -----------------------------------------------------------------
// DESAFIO 1: Cálculo de Comissões
// -----------------------------------------------------------------
Console.WriteLine("--- DESAFIO 1: CÁLCULO DE COMISSÕES ---");
var comissaoService = new ComissaoService();
var comissoes = comissaoService.CalcularComissoes();

foreach (var kvp in comissoes)
{
    Console.WriteLine($"Vendedor: {kvp.Key,-15} | Comissão Total: {kvp.Value:C}");
}
Console.WriteLine();

// -----------------------------------------------------------------
// DESAFIO 2: Movimentação de Estoque
// -----------------------------------------------------------------
Console.WriteLine("--- DESAFIO 2: MOVIMENTAÇÃO DE ESTOQUE ---");
var estoqueService = new EstoqueService();

Console.WriteLine("Estoque Inicial:");
foreach (var produto in estoqueService.ObterEstoqueAtual())
{
    Console.WriteLine($"- {produto.CodigoProduto} | {produto.DescricaoProduto,-25} | Estoque: {produto.Estoque}");
}
Console.WriteLine();

// Exemplos de Movimentação
Console.WriteLine("Realizando Movimentações:");
// Entrada de 50 unidades de Caneta Azul (Código 101)
estoqueService.MovimentarEstoque(101, 50, "Entrada por Compra");
// Saída de 10 unidades de Caderno Universitário (Código 102)
estoqueService.MovimentarEstoque(102, -10, "Saída por Venda");
// Tentativa de Saída de 500 unidades de Lápis Preto HB (Código 104) - Deve falhar
estoqueService.MovimentarEstoque(104, -500, "Saída por Venda Grande");
// Entrada de 20 unidades de Marcador de Texto Amarelo (Código 105)
estoqueService.MovimentarEstoque(105, 20, "Entrada por Transferência");
Console.WriteLine();

Console.WriteLine("Estoque Final:");
foreach (var produto in estoqueService.ObterEstoqueAtual())
{
    Console.WriteLine($"- {produto.CodigoProduto} | {produto.DescricaoProduto,-25} | Estoque: {produto.Estoque}");
}
Console.WriteLine();

// -----------------------------------------------------------------
// DESAFIO 3: Cálculo de Juros por Atraso
// -----------------------------------------------------------------
Console.WriteLine("--- DESAFIO 3: CÁLCULO DE JUROS POR ATRASO ---");
var jurosService = new JurosService();

decimal valorOriginal = 1000.00m;
// Usando uma data de vencimento no passado para garantir que o cálculo de juros seja demonstrado
DateTime dataVencimento = new DateTime(2025, 10, 15);
DateTime dataAtual = new DateTime(2025, 11, 25); // Data atual simulada para demonstração

Console.WriteLine($"Valor Original: {valorOriginal:C}");
Console.WriteLine($"Data de Vencimento: {dataVencimento:d}");
Console.WriteLine($"Data de Cálculo: {dataAtual:d}");

decimal juros = jurosService.CalcularJuros(valorOriginal, dataVencimento, dataAtual);

Console.WriteLine($"Juros Calculado (Multa 2,5% ao dia): {juros:C}");
Console.WriteLine($"Valor Total a Pagar: {valorOriginal + juros:C}");
Console.WriteLine();

Console.WriteLine("=================================================");
Console.WriteLine("  FIM DA EXECUÇÃO DO PROJETO");
Console.WriteLine("=================================================");