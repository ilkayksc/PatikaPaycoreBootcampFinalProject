using AutoMapper;
using NHibernate;
using PatikaPaycoreBootcampFinalProject.Model;
using ISession = NHibernate.ISession;
using PatikaPaycoreBootcampFinalProject.Context;
using PatikaPaycoreBootcampFinalProject.Dto;

namespace PatikaPaycoreBootcampFinalProject.Services
{
    public class BrandService : BaseService<BrandDto, Brand>, IBrandService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IMapperSession<Brand> hibernateRepository;

        public BrandService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            hibernateRepository = new MapperSession<Brand>(session);
        }



    }
}
