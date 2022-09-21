using PatikaPaycoreBootcampFinalProject.Base;
using PatikaPaycoreBootcampFinalProject.Dto;
using PatikaPaycoreBootcampFinalProject.Model;

namespace PatikaPaycoreBootcampFinalProject.Services
{
    public interface IOfferService : IBaseService<OfferDto, Offer>
    {
        BaseResponse<OfferDto> Insert(OfferDto insertResource);
        BaseResponse<IEnumerable<OfferDto>> GetMyOffers();
        BaseResponse<IEnumerable<OfferDto>> GetOffersForMyProduct();
    }
}
