using System.ComponentModel.DataAnnotations;

public class BancoCreateDto
{
    [Required(ErrorMessage = "O Nome do Banco é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O Código do Banco é obrigatório.")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "O Código do Banco deve ter exatamente 3 caracteres.")]
    public string Codigo { get; set; }

    [Required(ErrorMessage = "O Percentual de Juros é obrigatório.")]
    [Range(0, 100, ErrorMessage = "O Percentual de Juros deve ser entre 0 e 100.")]
    public decimal PercentualJuros { get; set; }
}
