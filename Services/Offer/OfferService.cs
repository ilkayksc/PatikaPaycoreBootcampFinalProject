using AutoMapper;
using NHibernate;
using PatikaPaycoreBootcampFinalProject.Model;
using Microsoft.AspNetCore.Authorization;
using ISession = NHibernate.ISession;
using PatikaPaycoreBootcampFinalProject.Context;
using PatikaPaycoreBootcampFinalProject.Dto;
using PatikaPaycoreBootcampFinalProject.Base;
using FluentNHibernate.Data;
using Microsoft.IdentityModel;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Serilog;

namespace PatikaPaycoreBootcampFinalProject.Services
{
    public class OfferService : BaseService<OfferDto, Offer>, IOfferService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IMapperSession<Offer> hibernateRepository;
        protected readonly IHttpContextAccessor httpContextAccessor;
        private readonly IProductService _product;

        public OfferService(ISession session, IMapper mapper,IHttpContextAccessor httpContextAccessor,IProductService _product) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            hibernateRepository = new MapperSession<Offer>(session);
            this.httpContextAccessor = httpContextAccessor;
            this._product = _product;
        }

        public override BaseResponse<OfferDto> Insert(OfferDto insertResource)
        {
            try
            {
                var tempEntity = mapper.Map<OfferDto, Offer>(insertResource);
                tempEntity.Customer = Int64.Parse(httpContextAccessor.HttpContext.User.Identities.FirstOrDefault().Claims.ToList().FirstOrDefault().Value);
                hibernateRepository.BeginTransaction();
                hibernateRepository.Save(tempEntity);
                hibernateRepository.Commit();

                hibernateRepository.CloseTransaction();
                return new BaseResponse<OfferDto>(mapper.Map<Offer, OfferDto>(tempEntity));
            }
            catch (Exception ex)
            {
                Log.Error("OfferService.Insert", ex);
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<OfferDto>(ex.Message);
            }
        }

        public BaseResponse<IEnumerable<OfferDto>> GetMyOffers()
        {
            var authenticateUser = Int64.Parse(httpContextAccessor.HttpContext.User.Identities.FirstOrDefault().Claims.ToList().FirstOrDefault().Value);
            List<Offer> offers = hibernateRepository.Entities.Where(c => c.Customer == authenticateUser).ToList();
            var result = mapper.Map<IEnumerable<Offer>, IEnumerable<OfferDto>>(offers);
            return new BaseResponse<IEnumerable<OfferDto>>((IEnumerable<OfferDto>)result);
        }

        public BaseResponse<IEnumerable<OfferDto>> GetOffersForMyProduct()
        {
            var authenticateUser = Int64.Parse(httpContextAccessor.HttpContext.User.Identities.FirstOrDefault().Claims.ToList().FirstOrDefault().Value);

            IEnumerable<Offer> offers = hibernateRepository.Entities.ToList();

            IEnumerable<ProductDto> products = _product.GetAll().Response.Where(p => p.ProductOwner == authenticateUser);

            IEnumerable<Offer> joinedList = offers.Join(products, pro => pro.ProductId, offer => offer.Id, (offer, meta) =>offer);
            var result =  mapper.Map<IEnumerable<Offer>, IEnumerable<OfferDto>>(joinedList);


            return new BaseResponse<IEnumerable<OfferDto>>(result);
        }

    }
}
