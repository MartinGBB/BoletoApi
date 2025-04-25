using System.ComponentModel.DataAnnotations.Schema;

[Table("Boleto")]
public class Boleto
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int Id { get; set; }

    [Column("NomePagador")]
    public string NomePagador { get; set; } = string.Empty;

    [Column("CpfCnpjPagador")]
    public string CpfCnpjPagador { get; set; } = string.Empty;

    [Column("NomeBeneficiario")]
    public string NomeBeneficiario { get; set; } = string.Empty;

    [Column("CpfCnpjBeneficiario")]
    public string CpfCnpjBeneficiario { get; set; } = string.Empty;

    [Column("Valor")]
    public decimal Valor { get; set; }

    [Column("DataVencimento")]
    public DateTime DataVencimento { get; set; }

    [Column("Observacao")]
    public string Observacao { get; set; } = string.Empty;

    [Column("BancoId")]
    public int BancoId { get; set; }

    public Banco Banco { get; set; }
}
