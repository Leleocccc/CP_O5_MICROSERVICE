# Sistema de Gestão de Estoque

## Sobre
Sistema para controle de produtos perecíveis e não-perecíveis, com regras de negócio, validações e relatórios.

## Regras de Negócio
- Produtos perecíveis exigem lote e validade
- Não permite movimentação negativa
- Saída só se houver estoque suficiente
- Alerta para estoque abaixo do mínimo
- Não movimenta perecível após validade

## Entidades
- Produto: SKU, Nome, Categoria, Preço, Estoque, Mínimo, Data
- Movimentação: Tipo, Quantidade, Data, SKU, Lote, Validade
- Alerta: SKU, Mensagem, Data

## Exemplos de API
- POST /produto
- POST /movimentacao
- GET /relatorio/estoque-total
- GET /relatorio/produtos-vencendo
- GET /relatorio/produtos-abaixo-minimo
- GET /relatorio/alertas-estoque-minimo

## Como Executar
1. No terminal, execute:
   dotnet run
2. Acesse os endpoints na porta informada (ex: http://localhost:5292)

## Entrega
- Código, exemplos e documentação estão no repositório.