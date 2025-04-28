using System.ComponentModel.DataAnnotations;

public class BoletoCreateDto
{
    [Required(ErrorMessage = "O Nome do Pagador é obrigatório.")]
    public string NomePagador { get; set; } = string.Empty;

    [Required(ErrorMessage = "O CPF/CNPJ do Pagador é obrigatório.")]
    public string CpfCnpjPagador { get; set; } = string.Empty;

    [Required(ErrorMessage = "O Nome do Beneficiário é obrigatório.")]
    public string NomeBeneficiario { get; set; } = string.Empty;

    [Required(ErrorMessage = "O CPF/CNPJ do Beneficiário é obrigatório.")]
    public string CpfCnpjBeneficiario { get; set; } = string.Empty;

    [Required(ErrorMessage = "O valor é obrigatório.")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "A Data de Vencimento é obrigatória.")]
    public DateTime DataVencimento { get; set; }

    [Required(ErrorMessage = "A Observação é obrigatória.")]
    public string Observacao { get; set; } = string.Empty;

    [Required(ErrorMessage = "O ID do Banco é obrigatório.")]
    public int BancoId { get; set; }
}