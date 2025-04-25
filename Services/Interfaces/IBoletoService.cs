public interface IBoletoService
{
    BoletoDto GetById(int id);
    BoletoDto Create(BoletoDto boleto);
}