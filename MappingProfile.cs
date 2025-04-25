using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BancoDto, Banco>();
        CreateMap<Banco, BancoDto>();

        CreateMap<BoletoDto, Boleto>();
        CreateMap<Boleto, BoletoDto>();
    }
}
