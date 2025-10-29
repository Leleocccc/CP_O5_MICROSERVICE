using cp.Models;
using cp.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace cp.Services
{
    public class MovimentacaoException : Exception
    {
        public MovimentacaoException(string message) : base(message) { }
    }

    public class MovimentacaoService
    {
        private readonly EstoqueDbContext _context;
        public MovimentacaoService(EstoqueDbContext context)
        {
            _context = context;
        }

        public void RegistrarMovimentacao(MovimentacaoEstoque mov)
        {
            if (mov.Quantidade <= 0)
                throw new MovimentacaoException("Quantidade deve ser positiva.");

            var produto = _context.Produtos.FirstOrDefault(p => p.SKU == mov.SKUProduto);
            if (produto == null)
                throw new MovimentacaoException("Produto não encontrado.");

            if (produto.Categoria == CategoriaProduto.PERECIVEL)
            {
                if (string.IsNullOrWhiteSpace(mov.Lote) || mov.DataValidade == null)
                    throw new MovimentacaoException("Perecíveis exigem lote e data de validade.");
                if (mov.DataValidade <= DateTime.Now)
                    throw new MovimentacaoException("Data de validade inválida ou já vencida.");
                if (mov.DataMovimentacao > mov.DataValidade)
                    throw new MovimentacaoException("Não é permitido movimentar produto perecível após a data de validade.");
            }

            if (mov.Tipo == TipoMovimentacao.SAIDA)
            {
                if (produto.QuantidadeAtual < mov.Quantidade)
                    throw new MovimentacaoException("Estoque insuficiente para saída.");
                produto.QuantidadeAtual -= mov.Quantidade;
            }
            else
            {
                produto.QuantidadeAtual += mov.Quantidade;
            }

            _context.Movimentacoes.Add(mov);
            _context.SaveChanges();
        }
    }
}