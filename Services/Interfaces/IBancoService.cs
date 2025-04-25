public interface IBancoService
{
    IEnumerable<Banco> GetAll();
    Banco GetByCodigo(string codigo);
    void Create(Banco banco);
}