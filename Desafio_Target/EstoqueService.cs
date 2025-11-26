using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio_Target
{
    public class EstoqueService
    {
        private const string ESTOQUE_JSON = @"{
""estoque"":
[
{
""codigoProduto"": 101,
""descricaoProduto"": ""Caneta Azul"",
""estoque"": 150
},
{
""codigoProduto"": 102,
""descricaoProduto"": ""Caderno Universitário"",
""estoque"": 75
},
{
""codigoProduto"": 103,
""descricaoProduto"": ""Borracha Branca"",
""estoque"": 200
},
{
""codigoProduto"": 104,
""descricaoProduto"": ""Lápis Preto HB"",
""estoque"": 320
},
{
""codigoProduto"": 105,
""descricaoProduto"": ""Marcador de Texto Amarelo"",
""estoque"": 90
}
]
}";
        private List<Produto> _produtos;
        private List<Movimentacao> _movimentacoes;
        private int _proximoIdMovimentacao = 1;

        public EstoqueService()
        {
            var estoqueData = JsonSerializer.Deserialize<EstoqueData>(ESTOQUE_JSON);
            _produtos = estoqueData?.Estoque ?? new List<Produto>();
            _movimentacoes = new List<Movimentacao>();
        }

        public List<Produto> ObterEstoqueAtual()
        {
            return _produtos;
        }

        public Produto? ObterProdutoPorCodigo(int codigoProduto)
        {
            return _produtos.FirstOrDefault(p => p.CodigoProduto == codigoProduto);
        }

        public int MovimentarEstoque(int codigoProduto, int quantidade, string descricao)
        {
            var produto = ObterProdutoPorCodigo(codigoProduto);

            if (produto == null)
            {
                Console.WriteLine($"Erro: Produto com código {codigoProduto} não encontrado.");
                return -1;
            }

            // Verifica se é uma saída e se há estoque suficiente
            if (quantidade < 0 && produto.Estoque + quantidade < 0)
            {
                Console.WriteLine($"Erro: Estoque insuficiente para a saída de {Math.Abs(quantidade)} unidades do produto {produto.DescricaoProduto}. Estoque atual: {produto.Estoque}");
                return -1;
            }

            // Realiza a movimentação
            produto.Estoque += quantidade;

            // Registra a movimentação
            var movimentacao = new Movimentacao
            {
                Id = _proximoIdMovimentacao++,
                Descricao = descricao,
                CodigoProduto = codigoProduto,
                Quantidade = quantidade
            };
            _movimentacoes.Add(movimentacao);

            Console.WriteLine($"Movimentação {movimentacao.Id} registrada: {descricao}. Produto: {produto.DescricaoProduto}. Quantidade: {quantidade}. Novo estoque: {produto.Estoque}");

            return produto.Estoque;
        }
    }
}