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
            if (!ModelState.IsValid)
            {
                var firstError = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault();
                if (firstError != null)
                {
                    var errorMessage = $"O campo {firstError.Exception?.Source ?? firstError.ErrorMessage}";
                    return BadRequest(new
                    {
                        type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                        title = "One or more validation errors occurred.",
                        status = 400,
                        traceId = HttpContext.TraceIdentifier,
                        errors = new { firstError.ErrorMessage }
                    });
                }
                return BadRequest("Dados inválidos.");
            }

            var createdBoleto = _boletoService.Create(boleto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = createdBoleto.Id }, createdBoleto);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro inesperado: " + ex.Message);
        }
    }

}