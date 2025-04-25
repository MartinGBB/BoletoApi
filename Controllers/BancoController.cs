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
            return NotFound();

        return Ok(banco);
    }

    [HttpPost]
    public IActionResult Criar(BancoDto banco)
    {
        _bancoService.Create(banco);
        return CreatedAtAction(nameof(BuscarPorCodigo), new { codigo = banco.Codigo }, banco);
    }
}
