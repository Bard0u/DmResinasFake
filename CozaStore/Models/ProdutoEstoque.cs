using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozaStore.Models;

[Table("ProdtoEstoque")]
public class ProdtoEstoque
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o Produto")]
    public int ProdutoId { get; set; }
    [ForeignKey("ProdutoId")]
    public Produto Produto { get; set; }

    [Required(ErrorMessage = "Informe o Tamanho")]
    public byte TamanhoId { get; set; }
    [ForeignKey("TamanhoId")]
    public Tamanho Tamanho { get; set; }

    [Required(ErrorMessage = "Informe a Cor")]
    public byte CorId { get; set; }
    [ForeignKey("CorId")]
    public Cor Cor { get; set; }

    [Display(Name = "Qtde Em Estoque")]
    [Required(ErrorMessage = "Informe a Qtde em Estoque")]
    public int QtdeEstoque { get; set; }

    [Display(Name = "preço")]
    [Column(TypeName = "decimal(8,2)")]
    [Required(ErrorMessage = "Informe o preço de venda")]
    public decimal? Preco { get; set; }

    [Display(Name = "preço com desconto")]
    [Column(TypeName = "decimal(8,2)")]
    public decimal? PrecoDesconto { get; set; }
}
