using PatikaPaycoreBootcampFinalProject.Base;
using PatikaPaycoreBootcampFinalProject.Dto;
using PatikaPaycoreBootcampFinalProject.Model;

namespace PatikaPaycoreBootcampFinalProject.Services
{
    public interface IBuyService : IBaseService<BuyDto, Buy>
    {
        BaseResponse<BuyDto> Insert(BuyDto id);
    }
}
