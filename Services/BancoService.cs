public class BancoService : IBancoService
{
    private readonly AppDbContext _context;

    public BancoService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Banco> GetAll() => _context.Bancos.ToList();

    public Banco GetByCodigo(string codigo)
    {
        return new Banco();
    }

    public Banco GetById(int id)
    {
        return new Banco();
    }

    public void Create(Banco banco)
    {
        _context.Bancos.Add(banco);
    }
}