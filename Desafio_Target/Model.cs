using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Desafio_Target
{
    // Modelos para o Desafio 1: Cálculo de Comissões
    public class Venda
    {
        [JsonPropertyName("vendedor")]
        public string Vendedor { get; set; }

        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }
    }

    public class VendasData
    {
        [JsonPropertyName("vendas")]
        public List<Venda> Vendas { get; set; }
    }

    // Modelos para o Desafio 2: Movimentação de Estoque
    public class Produto
    {
        [JsonPropertyName("codigoProduto")]
        public int CodigoProduto { get; set; }

        [JsonPropertyName("descricaoProduto")]
        public string DescricaoProduto { get; set; }

        [JsonPropertyName("estoque")]
        public int Estoque { get; set; }
    }

    public class EstoqueData
    {
        [JsonPropertyName("estoque")]
        public List<Produto> Estoque { get; set; }
    }

    public class Movimentacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int CodigoProduto { get; set; }
        public int Quantidade { get; set; } // Positivo para entrada, negativo para saída
        public DateTime DataHora { get; set; } = DateTime.Now;
    }
}


