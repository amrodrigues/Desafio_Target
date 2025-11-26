using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio_Target
{
    public class ComissaoService
    {
        private const string VENDAS_JSON = @"{
""vendas"": [
{ ""vendedor"": ""João Silva"", ""valor"": 1200.50 },
{ ""vendedor"": ""João Silva"", ""valor"": 950.75 },
{ ""vendedor"": ""João Silva"", ""valor"": 1800.00 },
{ ""vendedor"": ""João Silva"", ""valor"": 1400.30 },
{ ""vendedor"": ""João Silva"", ""valor"": 1100.90 },
{ ""vendedor"": ""João Silva"", ""valor"": 1550.00 },
{ ""vendedor"": ""João Silva"", ""valor"": 1700.80 },
{ ""vendedor"": ""João Silva"", ""valor"": 250.30 },
{ ""vendedor"": ""João Silva"", ""valor"": 480.75 },
{ ""vendedor"": ""João Silva"", ""valor"": 320.40 },

{ ""vendedor"": ""Maria Souza"", ""valor"": 2100.40 },
{ ""vendedor"": ""Maria Souza"", ""valor"": 1350.60 },
{ ""vendedor"": ""Maria Souza"", ""valor"": 950.20 },
{ ""vendedor"": ""Maria Souza"", ""valor"": 1600.75 },
{ ""vendedor"": ""Maria Souza"", ""valor"": 1750.00 },
{ ""vendedor"": ""Maria Souza"", ""valor"": 1450.90 },
{ ""vendedor"": ""Maria Souza"", ""valor"": 400.50 },
{ ""vendedor"": ""Maria Souza"", ""valor"": 180.20 },
{ ""vendedor"": ""Maria Souza"", ""valor"": 90.75 },

{ ""vendedor"": ""Carlos Oliveira"", ""valor"": 800.50 },
{ ""vendedor"": ""Carlos Oliveira"", ""valor"": 1200.00 },

{ ""vendedor"": ""Carlos Oliveira"", ""valor"": 1950.30 },
{ ""vendedor"": ""Carlos Oliveira"", ""valor"": 1750.80 },
{ ""vendedor"": ""Carlos Oliveira"", ""valor"": 1300.60 },
{ ""vendedor"": ""Carlos Oliveira"", ""valor"": 300.40 },
{ ""vendedor"": ""Carlos Oliveira"", ""valor"": 500.00 },
{ ""vendedor"": ""Carlos Oliveira"", ""valor"": 125.75 },

{ ""vendedor"": ""Ana Lima"", ""valor"": 1000.00 },
{ ""vendedor"": ""Ana Lima"", ""valor"": 1100.50 },
{ ""vendedor"": ""Ana Lima"", ""valor"": 1250.75 },
{ ""vendedor"": ""Ana Lima"", ""valor"": 1400.20 },
{ ""vendedor"": ""Ana Lima"", ""valor"": 1550.90 },
{ ""vendedor"": ""Ana Lima"", ""valor"": 1650.00 },
{ ""vendedor"": ""Ana Lima"", ""valor"": 75.30 },
{ ""vendedor"": ""Ana Lima"", ""valor"": 420.90 },
{ ""vendedor"": ""Ana Lima"", ""valor"": 315.40 }
]
}";

        public Dictionary<string, decimal> CalcularComissoes()
        {
            var vendasData = JsonSerializer.Deserialize<VendasData>(VENDAS_JSON);
            var comissoesPorVendedor = new Dictionary<string, decimal>();

            if (vendasData?.Vendas == null)
            {
                return comissoesPorVendedor;
            }

            foreach (var venda in vendasData.Vendas)
            {
                decimal comissao = CalcularComissaoVenda(venda.Valor);

                if (comissoesPorVendedor.ContainsKey(venda.Vendedor))
                {
                    comissoesPorVendedor[venda.Vendedor] += comissao;
                }
                else
                {
                    comissoesPorVendedor.Add(venda.Vendedor, comissao);
                }
            }

            return comissoesPorVendedor;
        }

        private decimal CalcularComissaoVenda(decimal valorVenda)
        {
            if (valorVenda < 100.00m)
            {
                return 0.00m; // Não gera comissão
            }
            else if (valorVenda < 500.00m)
            {
                return valorVenda * 0.01m; // 1% de comissão
            }
            else
            {
                return valorVenda * 0.05m; // 5% de comissão
            }
        }
    }
}