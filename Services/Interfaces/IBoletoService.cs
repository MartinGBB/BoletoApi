public interface IBoletoService
{
    Boleto GetById(int id);
    void Create(Boleto boleto);
}