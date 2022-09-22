using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PatikaPaycoreBootcampFinalProject.Base;
using PatikaPaycoreBootcampFinalProject.Context;
using PatikaPaycoreBootcampFinalProject.Dto;
using PatikaPaycoreBootcampFinalProject.Model;
using PatikaPaycoreBootcampFinalProject.Services;
using PatikaPaycoreBootcampFinalProject.StartUpExtension;
using ISession = NHibernate.ISession;

namespace PatikaPaycoreBootcampFinalProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BuyController : ControllerBase
    {
        private readonly ISession session;
        private readonly IBuyService buyService;
        private readonly IOfferService offerService;
        private readonly IProductService _productService;
        public BuyController(ISession session, IBuyService buyService, IOfferService offerService, IProductService productService)
        {

            this.buyService = buyService;
            this.session = session;
            this.offerService = offerService;
            this._productService = productService;
        }
        // Kabul Edilmiş olan Teklifler Listelenir.
        [HttpGet("GetAcceptedOffers")]
        public BaseResponse<IEnumerable<OfferDto>> GetAcceptedOffers()
        {
            
            var result = offerService.GetMyOffers().Response.Where(acceptedOffers => acceptedOffers.IsAccept == true);

            return new BaseResponse<IEnumerable<OfferDto>>(result);
        }
        // Satınalma işleminin gerçekleştirilmesi.
        [HttpPost]
        public BaseResponse<BuyDto> Buy([FromBody] BuyDto request)
        {
            var product = _productService.GetAll().Response.Where(res => res.Id == request.ProductId).FirstOrDefault();
            // Ürünün bir daha satılmaması için isSold alanını güncelledik.
            product.IsSold = true;
            var result = buyService.Insert(request);
            _productService.Update(product.Id, product);
            return result;
        }
        
    }
}

