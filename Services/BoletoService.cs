using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class BoletoService : IBoletoService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BoletoService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public BoletoDto GetById(int id)
    {
        var boleto = _context.Boletos
            .Include(b => b.Banco)
            .FirstOrDefault(b => b.Id == id);

        if (boleto == null)
            return null;

        return _mapper.Map<BoletoDto>(boleto);
    }

    public BoletoDto Create(BoletoDto boletoDto)
    {
        var banco = _context.Bancos.Find(boletoDto.BancoId);
        if (banco == null)
            throw new KeyNotFoundException("Banco não encontrado");

        var boleto = _mapper.Map<Boleto>(boletoDto);

        if (boleto.DataVencimento < DateTime.Now)
            boleto.Valor += banco.PercentualJuros;

        boleto.Banco = banco;

        _context.Boletos.Add(boleto);
        _context.SaveChanges();

        return _mapper.Map<BoletoDto>(boleto);
    }
}