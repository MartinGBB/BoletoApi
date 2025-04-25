public class Boleto
{
    public int Id { get; set; }
    public string NomePagador { get; set; } = string.Empty;
    public string CpfCnpjPagador { get; set; } = string.Empty;
    public string NomeBeneficiario { get; set; } = string.Empty;
    public string CpfCnpjBeneficiario { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime DataVencimento { get; set; }
    public string Observacao { get; set; } = string.Empty;
    public int BancoId { get; set; }
}