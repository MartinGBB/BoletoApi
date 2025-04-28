using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BancoDto, Banco>();
        CreateMap<Banco, BancoDto>();

        CreateMap<BoletoDto, Boleto>();
        CreateMap<Boleto, BoletoDto>();

        CreateMap<BoletoCreateDto, Boleto>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<BancoCreateDto, Banco>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
