using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BancoController : ControllerBase
{
    private readonly IBancoService _bancoService;

    public BancoController(IBancoService bancoService)
    {
        _bancoService = bancoService;
    }

    [HttpGet]
    public IActionResult ListarTodos()
    {
        var bancos = _bancoService.GetAll();
        return Ok(bancos);
    }

    [HttpGet("{codigo}")]
    public IActionResult BuscarPorCodigo(string codigo)
    {
        var banco = _bancoService.GetByCodigo(codigo);
        if (banco == null)
            return NotFound(new { message = "Banco não encontrado.", erro = 404 });

        return Ok(banco);
    }

    [HttpPost]
    public IActionResult Criar(BancoCreateDto banco)
    {
        try
        {
            var createdBanco = _bancoService.Create(banco);
            return CreatedAtAction(
                nameof(BuscarPorCodigo),
                new { codigo = createdBanco.Codigo },
                new { message = $"Banco criado com o ID: {createdBanco.Id}", status = 201 });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocorreu um erro interno no servidor: " + ex.Message, erro = 500 });
        }
    }
}
