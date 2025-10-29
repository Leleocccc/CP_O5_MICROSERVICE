using System;
using System.ComponentModel.DataAnnotations;

namespace cp.Models
{
    public enum TipoMovimentacao
    {
        ENTRADA,
        SAIDA
    }

    public class MovimentacaoEstoque
    {
        public int Id { get; set; }
        [Required]
        public TipoMovimentacao Tipo { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser positiva")]
        public int Quantidade { get; set; }
        public DateTime DataMovimentacao { get; set; } = DateTime.Now;
        public string SKUProduto { get; set; }
        public string? Lote { get; set; }
        public DateTime? DataValidade { get; set; }
    }
}
