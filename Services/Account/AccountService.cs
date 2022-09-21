using AutoMapper;
using NHibernate;
using PatikaPaycoreBootcampFinalProject.Model;

using ISession = NHibernate.ISession;
using PatikaPaycoreBootcampFinalProject.Context;
using PatikaPaycoreBootcampFinalProject.Dto;

namespace PatikaPaycoreBootcampFinalProject.Services
{
    public class AccountService : BaseService<AccountDto, Account>, IAccountService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IMapperSession<Account> hibernateRepository;

        public AccountService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            hibernateRepository = new MapperSession<Account>(session);
        }



    }
}
