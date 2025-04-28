using System.ComponentModel.DataAnnotations;
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
        var boleto = _context.Boletos.FirstOrDefault(b => b.Id == id);

        if (boleto == null)
            return null;

        return _mapper.Map<BoletoDto>(boleto);
    }

    public BoletoDto Create(BoletoCreateDto boletoDto)
    {
        var banco = _context.Bancos.FirstOrDefault(b => b.Id == boletoDto.BancoId);
        if (banco == null)
            throw new KeyNotFoundException("Banco não encontrado");

        var boleto = _mapper.Map<Boleto>(boletoDto);

        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(boleto);
        if (!Validator.TryValidateObject(boleto, validationContext, validationResults, true))
            throw new ValidationException("Dados inválidos: " + string.Join(", ", validationResults.Select(v => v.ErrorMessage)));

        boleto.DataVencimento = boleto.DataVencimento.ToUniversalTime();
        if (boleto.DataVencimento < DateTime.Now)
            boleto.Valor += banco.PercentualJuros;

        boleto.Banco = banco;

        _context.Boletos.Add(boleto);
        _context.SaveChanges();

        return _mapper.Map<BoletoDto>(boleto);
    }
}