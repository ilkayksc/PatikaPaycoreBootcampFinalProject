using AutoMapper;
using NHibernate;
using PatikaPaycoreBootcampFinalProject.Model;

using ISession = NHibernate.ISession;
using PatikaPaycoreBootcampFinalProject.Context;
using PatikaPaycoreBootcampFinalProject.Dto;

namespace PatikaPaycoreBootcampFinalProject.Services
{
    public class CategoryService : BaseService<CategoryDto, Category>, ICategoryService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IMapperSession<Category> hibernateRepository;

        public CategoryService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            hibernateRepository = new MapperSession<Category>(session);
        }



    }
}
