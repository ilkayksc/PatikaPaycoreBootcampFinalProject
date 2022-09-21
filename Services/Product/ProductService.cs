using AutoMapper;
using NHibernate;
using PatikaPaycoreBootcampFinalProject.Model;

using ISession = NHibernate.ISession;
using PatikaPaycoreBootcampFinalProject.Context;
using PatikaPaycoreBootcampFinalProject.Dto;
using PatikaPaycoreBootcampFinalProject.Base;

namespace PatikaPaycoreBootcampFinalProject.Services
{
    public class ProductService : BaseService<ProductDto, Product>, IProductService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IMapperSession<Product> hibernateRepository;
        protected readonly ICategoryService categoryService;
        protected readonly IHttpContextAccessor httpContextAccessor;
        public ProductService(ISession session, IMapper mapper,ICategoryService categoryService, IHttpContextAccessor httpContextAccessor) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            hibernateRepository = new MapperSession<Product>(session);
            this.categoryService = categoryService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public override BaseResponse<ProductDto> Insert(ProductDto insertResource)
        {
            CategoryDto categoryCheck = categoryService.GetById(insertResource.CategoryId).Response;
            insertResource.ProductOwner = Int64.Parse(httpContextAccessor.HttpContext.User.Identities.FirstOrDefault().Claims.ToList().FirstOrDefault().Value);
            if (categoryCheck is null || insertResource.CategoryId == 0)
            {
                return new BaseResponse<ProductDto>(message: "Lütfen Kategori Bilgisini Kontrol Ediniz.");
            }
            
            return base.Insert(insertResource);
        }

        public BaseResponse<IEnumerable<ProductDto>> GetOfferableProducts()
        {
            var authenticateUser = Int64.Parse(httpContextAccessor.HttpContext.User.Identities.FirstOrDefault().Claims.ToList().FirstOrDefault().Value);
            var products = GetAll().Response.Where(products=>products.IsOfferable == true && products.ProductOwner != authenticateUser).ToList();
            return  new BaseResponse<IEnumerable<ProductDto>>(products); 
        }


    }
}
