using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BoletoController : ControllerBase
{
    private readonly IBoletoService _boletoService;

    public BoletoController(IBoletoService boletoService)
    {
        _boletoService = boletoService;
    }

    [HttpGet]
    public IActionResult Boleto()
    {
        var boleto = new Boleto();
        if (boleto == null)
            return NotFound();

        return Ok(boleto);
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
        _boletoService.Create(boleto);
        return CreatedAtAction(nameof(GetBoleto), new { id = boleto.Id }, boleto);
    }
}