using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Boleto")]
public class Boleto
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O Nome do Pagador é obrigatório.")]
    [Column("NomePagador")]
    public string NomePagador { get; set; } = string.Empty;

    [Required(ErrorMessage = "O CPF/CNPJ do Pagador é obrigatório.")]
    [Column("CpfCnpjPagador")]
    public string CpfCnpjPagador { get; set; } = string.Empty;

    [Required(ErrorMessage = "O Nome do Beneficiário é obrigatório.")]
    [Column("NomeBeneficiario")]
    public string NomeBeneficiario { get; set; } = string.Empty;

    [Required(ErrorMessage = "O CPF/CNPJ do Beneficiário é obrigatório.")]
    [Column("CpfCnpjBeneficiario")]
    public string CpfCnpjBeneficiario { get; set; } = string.Empty;

    [Required(ErrorMessage = "O valor é obrigatório.")]
    [Column("Valor")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "A Data de Vencimento é obrigatória.")]
    [Column("DataVencimento")]
    public DateTime DataVencimento { get; set; }

    [Required(ErrorMessage = "A Observação é obrigatória.")]
    [Column("Observacao")]
    public string Observacao { get; set; } = string.Empty;

    [Required(ErrorMessage = "O ID do Banco é obrigatório.")]
    [Column("BancoId")]
    public int BancoId { get; set; }

    public Banco Banco { get; set; }
}