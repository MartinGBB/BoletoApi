public interface IBoletoService
{
    BoletoDto GetById(int id);
    BoletoDto Create(BoletoCreateDto boleto);
}