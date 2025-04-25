public interface IBoletoService
{
    Boleto GetById(int id);
    Boleto Create(Boleto boleto);
}