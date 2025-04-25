using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BoletoController : ControllerBase
{
    private readonly IBoletoService _boletoService;
    private readonly IBancoService _bancoService;

    public BoletoController(IBoletoService boletoService, IBancoService bancoService)
    {
        _boletoService = boletoService;
        _bancoService = bancoService;
    }

    [HttpGet("{id}")]
    public IActionResult GetBoleto(int id)
    {
        var boleto = _boletoService.GetById(id);
        if (boleto == null)
            return NotFound();

        return Ok(boleto);
    }

    [HttpPost]
    public IActionResult CreateBoleto(Boleto boleto)
    {
        var banco = _bancoService.GetById(boleto.BancoId);
        if (banco == null || banco.Id == 0)
            return NotFound("Banco não encontrado.");

        _boletoService.Create(boleto);
        return CreatedAtAction(nameof(GetBoleto), new { id = boleto.Id }, boleto);
    }
}