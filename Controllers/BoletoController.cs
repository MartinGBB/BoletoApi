using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BoletoController : ControllerBase
{
    private readonly IBoletoService _boletoService;

    public BoletoController(IBoletoService boletoService, IBancoService bancoService)
    {
        _boletoService = boletoService;
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var boleto = _boletoService.GetById(id);
        if (boleto == null)
            return NotFound();

        return Ok(boleto);
    }

    [HttpPost]
    public IActionResult Criar(BoletoDto boleto)
    {
        try
        {
            var createdBoleto = _boletoService.Create(boleto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = createdBoleto.Id }, "BancoId: " + createdBoleto.Id);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}