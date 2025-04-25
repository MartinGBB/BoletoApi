using AutoMapper;

public class BancoService : IBancoService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;


    public BancoService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<BancoDto> GetAll()
    {
        var bancos = _context.Bancos.ToList();
        return _mapper.Map<IEnumerable<BancoDto>>(bancos);
    }


    public BancoDto GetByCodigo(string codigo)
    {
        var banco = _context.Bancos.FirstOrDefault(b => b.Codigo == codigo);
        return _mapper.Map<BancoDto>(banco);
    }

    public BancoDto GetById(int id)
    {
        var banco = _context.Bancos.FirstOrDefault(b => b.Id == id);
        return _mapper.Map<BancoDto>(banco);
    }


    public void Create(BancoDto bancoDto)
    {
        var banco = _mapper.Map<Banco>(bancoDto);

        _context.Bancos.Add(banco);
        _context.SaveChanges();
    }
}