public interface IBancoService
{
    IEnumerable<BancoDto> GetAll();
    BancoDto GetByCodigo(string codigo);
    BancoDto GetById(int id);
    void Create(BancoDto banco);
}