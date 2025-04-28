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
            return NotFound(new { message = "Boleto não encontrado.", status = 404 });

        return Ok(boleto);
    }

    [HttpPost]
    public IActionResult Criar(BoletoCreateDto boleto)
    {
        try
        {
            var createdBoleto = _boletoService.Create(boleto);
            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = createdBoleto.Id },
                new { message = $"Boleto criado com o ID: {createdBoleto.Id}", status = 201 }
            );
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message, status = 404 });
        }
        catch (Exception e)
        {
            return StatusCode(500, new { message = "Ocorreu um erro interno no servidor: " + e.Message, status = 500 });
        }
    }

}