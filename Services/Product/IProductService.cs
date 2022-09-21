using PatikaPaycoreBootcampFinalProject.Base;
using PatikaPaycoreBootcampFinalProject.Dto;
using PatikaPaycoreBootcampFinalProject.Model;

namespace PatikaPaycoreBootcampFinalProject.Services
{
    public interface IProductService : IBaseService<ProductDto, Product>
    {
        BaseResponse<IEnumerable<ProductDto>> GetOfferableProducts();
    }
}
