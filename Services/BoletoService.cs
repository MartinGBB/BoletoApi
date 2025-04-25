public class BoletoService : IBoletoService
{
    private readonly AppDbContext _context;

    public BoletoService(AppDbContext context)
    {
        _context = context;
    }

    public Boleto GetById(int id)
    {
        return new Boleto();
    }

    public void Create(Boleto boleto)
    {
        _context.Add(boleto);
    }
}