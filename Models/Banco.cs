using System.ComponentModel.DataAnnotations.Schema;

public class Banco
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int Id { get; set; }

    [Column("Nome")]
    public string Nome { get; set; } = string.Empty;

    [Column("Codigo")]
    public string Codigo { get; set; } = string.Empty;

    [Column("PercentualJuros")]
    public decimal PercentualJuros { get; set; }
}
