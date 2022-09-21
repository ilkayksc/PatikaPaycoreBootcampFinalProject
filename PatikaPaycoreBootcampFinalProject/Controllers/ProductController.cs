using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatikaPaycoreBootcampFinalProject.Context;
using PatikaPaycoreBootcampFinalProject.Model;
using System.Security.Cryptography;
using PatikaPaycoreBootcampFinalProject.StartUpExtension;
using PatikaPaycoreBootcampFinalProject.Services;
using AutoMapper;
using NHibernate;
using ISession = NHibernate.ISession;
using PatikaPaycoreBootcampFinalProject.Base;
using PatikaPaycoreBootcampFinalProject.Dto;
using Microsoft.AspNetCore.Authorization;

namespace PatikaPaycoreBootcampFinalProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductContoller : ControllerBase
    {
        private readonly ISession session;

        private readonly IProductService _product;
        private readonly ICategoryService _category;

        public ProductContoller(ISession session, IProductService _product, ICategoryService _category)
        {
            this.session = session;
            this._category = _category;
            this._product = _product;
        }

        [HttpGet("GetAllProduct")]
        public BaseResponse<IEnumerable<ProductDto>> GetAll()
        {
            var products = _product.GetAll();
            return products;
        }
        [HttpGet("GetOfferableProducts")]
        public BaseResponse<IEnumerable<ProductDto>> GetOfferable()
        {
            var products = _product.GetOfferableProducts();
            return products; 
        }
  
        [HttpPost("AddNewProduct")]
        public BaseResponse<ProductDto> Post([FromBody] ProductDto request)
        {  
            var result = _product.Insert(request);
            return result;
        }
    }
}

