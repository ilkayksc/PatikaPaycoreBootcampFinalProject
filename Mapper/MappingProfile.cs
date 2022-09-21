using AutoMapper;
using PatikaPaycoreBootcampFinalProject.Base;
using PatikaPaycoreBootcampFinalProject.Dto;
using PatikaPaycoreBootcampFinalProject.Model;


namespace PatikaPaycoreBootcampFinalProject.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountDto, Account>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<TokenRequest, TokenResponse>().ReverseMap();
            CreateMap<OfferDto, Offer>().ReverseMap();
            CreateMap<ColorDto, Color>().ReverseMap();
            CreateMap<BrandDto, Brand>().ReverseMap();
            CreateMap<BuyDto, Buy>().ReverseMap();
          
        }

    }
}
