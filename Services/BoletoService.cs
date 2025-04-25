using Microsoft.EntityFrameworkCore;

public class BoletoService : IBoletoService
{
    private readonly AppDbContext _context;

    public BoletoService(AppDbContext context)
    {
        _context = context;
    }

    public Boleto GetById(int id)
    {
        return _context.Boletos.Find(id);
    }



    public Boleto Create(Boleto boleto)
    {
        var banco = _context.Bancos.Find(boleto.BancoId);

        if (banco == null)
            throw new KeyNotFoundException("Banco não encontrado");

        if (boleto.DataVencimento < DateTime.Now)
            boleto.Valor += banco.PercentualJuros;

        boleto.Banco = banco;
        _context.Boletos.Add(boleto);
        _context.SaveChanges();

        return boleto;
    }
}