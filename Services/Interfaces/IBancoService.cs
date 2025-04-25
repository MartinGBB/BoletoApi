public interface IBancoService
{
    IEnumerable<Banco> GetAll();
    Banco GetByCodigo(string codigo);
    Banco GetById(int id);
    void Create(Banco banco);
}