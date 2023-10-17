using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozaStore.Models;
    [Table("CarrinhoProduto")]
public class CarrinhoProduto
{
    [Key, Column(Order = 1)]
    public int CarrinhoId { get; set; }
    [ForeignKey("CarrinhoId")]
    public Carrinho Carrinho { get; set; }

    [Key, Column(Order = 2)]
    public int ProdutoEstoqueId { get; set; }
    [ForeignKey("ProdutoEstoqueId")]
    public ProdtoEstoque ProdtoEstoque { get; set; }

    [Display(Name = "Qtde ")]
    [Required(ErrorMessage = "Informe a Qtde ")]
    public int Qtde { get; set; } = 1;

    [Display(Name = "preço")]
    [Column(TypeName = "decimal(8,2)")]
    [Required(ErrorMessage = "Informe o preço de venda")]
    public decimal Preco { get; set; }

    [Display(Name = "preço com desconto")]
    [Column(TypeName = "decimal(8,2)")]
    public decimal PrecoDesconto { get; set; }
}
