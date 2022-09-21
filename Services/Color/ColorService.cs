using AutoMapper;
using NHibernate;
using PatikaPaycoreBootcampFinalProject.Model;

using ISession = NHibernate.ISession;
using PatikaPaycoreBootcampFinalProject.Context;
using PatikaPaycoreBootcampFinalProject.Dto;

namespace PatikaPaycoreBootcampFinalProject.Services
{
    public class ColorService : BaseService<ColorDto, Color>, IColorService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IMapperSession<Color> hibernateRepository;

        public ColorService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            hibernateRepository = new MapperSession<Color>(session);
        }



    }
}
