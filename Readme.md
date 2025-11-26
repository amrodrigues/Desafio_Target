## 📄 README.md - Desafio Target .NET

Olá! Este repositório contém a solução para o **Projeto Desafio .NET** proposto, desenvolvido em C# com o ambiente Visual Studio 2022.

O projeto é estruturado para demonstrar a implementação de lógica de negócios em três áreas distintas: Cálculo de Comissões, Movimentação de Estoque e Cálculo de Juros por Atraso.

---

### 🚀 Estrutura do Projeto

O ponto de entrada do projeto é o arquivo principal (`Program.cs`), que inicializa os serviços e executa as demonstrações dos três desafios.

| Arquivo/Componente | Descrição |
| :--- | :--- |
| `Program.cs` | Contém a lógica de inicialização e a demonstração de uso dos serviços para cada desafio. |
| `ComissaoService.cs` | Implementa a lógica para o **Desafio 1**: Cálculo das comissões de vendedores com base em dados simulados de vendas. |
| `EstoqueService.cs` | Implementa a lógica para o **Desafio 2**: Gerenciamento e movimentação (entrada/saída) do estoque, incluindo validações. |
| `JurosService.cs` | Implementa a lógica para o **Desafio 3**: Cálculo de juros e multa por atraso com base na data de vencimento. |
| `[Classes de Modelo]` | Classes de suporte como `Produto`, `Venda`, etc., usadas para estruturar os dados. |

### 🛠️ Configuração e Execução

#### Pré-requisitos
* [.NET SDK (versão 6.0 ou superior)](https://dotnet.microsoft.com/download)
* Visual Studio 2022 ou VS Code com extensão C#

#### Como Executar

1.  **Clone o repositório:**
    ```bash
    git clone [https://docs.github.com/pt/migrations/importing-source-code/using-the-command-line-to-import-source-code/adding-locally-hosted-code-to-github](https://docs.github.com/pt/migrations/importing-source-code/using-the-command-line-to-import-source-code/adding-locally-hosted-code-to-github)
    cd Desafio-Target
    ```
2.  **Restaure as dependências:**
    ```bash
    dotnet restore
    ```
3.  **Execute o projeto:**
    ```bash
    dotnet run
    ```

### 🎯 Detalhamento dos Desafios

#### 1. Cálculo de Comissões (`ComissaoService`)

Este desafio calcula o valor total de comissão devido a cada vendedor, processando uma lista de vendas.

* **Regra de Negócio (Exemplo):** A comissão é calculada aplicando-se uma porcentagem definida ao valor de cada venda realizada pelo vendedor.

#### 2. Movimentação de Estoque (`EstoqueService`)

Este desafio simula operações de entrada e saída de produtos no estoque, mantendo a integridade dos dados.

* **Validação Crucial:** É realizada uma verificação para garantir que uma operação de **saída** (venda, perda, etc.) não resulte em um estoque negativo (impedindo que o valor final seja menor que zero).

#### 3. Cálculo de Juros por Atraso (`JurosService`)

Este desafio calcula a multa e os juros incidentes sobre um valor original que está em atraso.

* **Entradas:** Valor Original, Data de Vencimento, Data de Cálculo (atual).
* **Regra de Negócio (Exemplo):** O juro/multa é calculado com base na taxa diária de atraso aplicada ao número de dias decorridos entre a data de vencimento e a data atual.

---

### 📧 Contato

Se houver alguma dúvida ou necessidade de aprofundamento sobre a lógica implementada, sinta-se à vontade para entrar em contato.

* **Anna Maria Gomes Bittencourt Rodrigues**
* **amrodrigues1307@gmail.com**
