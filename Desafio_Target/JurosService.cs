using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Target
{
    public class JurosService
    {
        private const decimal MULTA_DIARIA_PERCENTUAL = 0.025m; // 2,5% ao dia

        public decimal CalcularJuros(decimal valorOriginal, DateTime dataVencimento, DateTime dataAtual)
        {
            if (dataAtual <= dataVencimento)
            {
                return 0.00m; // Sem juros se o pagamento estiver em dia ou antecipado
            }

            // Calcula a diferença em dias
            TimeSpan diferenca = dataAtual - dataVencimento;
            // Arredonda para cima para garantir que um dia parcial conte como um dia inteiro de atraso
            int diasAtraso = (int)Math.Ceiling(diferenca.TotalDays);

            // A multa é de 2,5% ao dia
            decimal jurosDiario = valorOriginal * MULTA_DIARIA_PERCENTUAL;
            decimal jurosTotal = jurosDiario * diasAtraso;

            return jurosTotal;
        }
    }
}