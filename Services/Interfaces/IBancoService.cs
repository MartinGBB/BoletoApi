public interface IBancoService
{
    IEnumerable<BancoDto> GetAll();
    BancoDto GetByCodigo(string codigo);
    BancoDto GetById(int id);
    BancoDto Create(BancoCreateDto banco);
}