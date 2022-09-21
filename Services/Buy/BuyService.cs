using AutoMapper;
using NHibernate;
using PatikaPaycoreBootcampFinalProject.Model;

using ISession = NHibernate.ISession;
using PatikaPaycoreBootcampFinalProject.Context;
using PatikaPaycoreBootcampFinalProject.Dto;
using PatikaPaycoreBootcampFinalProject.Base;
using FluentNHibernate.Data;
using Serilog;

namespace PatikaPaycoreBootcampFinalProject.Services
{
    public class BuyService : BaseService<BuyDto, Buy>, IBuyService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IMapperSession<Buy> hibernateRepository;
        protected readonly IOfferService offerService;
        protected readonly IProductService productService;
        public BuyService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            hibernateRepository = new MapperSession<Buy>(session);
        }

        public override BaseResponse<BuyDto> Insert(BuyDto request)
        {
            try
            {   
                var product = productService.GetById(request.ProductId).Response;
                product.IsSold = true;
                var tempEntity = mapper.Map<BuyDto, Buy>(request);
                hibernateRepository.BeginTransaction();
                hibernateRepository.Save(tempEntity);
                hibernateRepository.Commit();
                productService.Update(product.Id,product);
                hibernateRepository.CloseTransaction();
                return new BaseResponse<BuyDto>(mapper.Map<Buy, BuyDto>(tempEntity));
            }
            catch (Exception ex)
            {
                Log.Error("BaseService.Insert", ex);
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<BuyDto>(ex.Message);
            }
        }

    }
}
