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
using Hangfire;
using PatikaPaycoreBootcampFinalProject.HangFire;

namespace PatikaPaycoreBootcampFinalProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly ISession session;

        private readonly IProductService _product;
        private readonly ICategoryService _category;
        private readonly IOfferService offerService;
        private readonly IAccountService accountService;
        public OfferController(ISession session, IProductService _product, ICategoryService _category, IOfferService purchaseService,IAccountService accountService)
        {
            this.session = session;
            this._category = _category;
            this._product = _product;
            this.offerService = purchaseService;
            this.accountService = accountService;
        }

        [HttpGet("GetMyOffers")]
        public BaseResponse<IEnumerable<OfferDto>> Get()
        {   
            var purchases = offerService.GetMyOffers();
            return purchases;
        }

        [HttpPost("NewOffer")]
        public BaseResponse<OfferDto> NewOffer([FromBody] OfferDto request)
        {   
            var product = _product.GetOfferableProducts().Response.Where(product => product.Id == request.ProductId ).FirstOrDefault();
            if (product is null)
            {
                return new BaseResponse<OfferDto>(message: "bu ürüne teklif veremezsiniz.");
            }

           
            var result = offerService.Insert(request);
            var accountInfo = accountService.GetById(result.Response.Customer).Response;
            BackgroundJob.Schedule(() => JobDelayed.Run("ilkay.ksc2@gmail.com", $"sayın  {accountInfo.Name} {accountInfo.Surname} Teklifiniz Alınmıştır.", "Teklifiniz Alınmıştır."), TimeSpan.FromSeconds(2));


            return result;
        }
        [HttpGet("GetOfferForMyProduct")]
        public BaseResponse<IEnumerable<OfferDto>> GetOffersForMyProduct()
        {
            var result = offerService.GetOffersForMyProduct();
            return result;
        }
        [HttpGet("AcceptOffer")]
        public BaseResponse<OfferDto> AcceptOffer(long id)
        {
            var offer = offerService.GetById(id);
            offer.Response.IsAccept = true;
            var response = offerService.Update(id,offer.Response);

            var accountInfo = accountService.GetById(response.Response.Customer).Response;
            BackgroundJob.Schedule(() => JobDelayed.Run("ilkay.ksc2@gmail.com", $"sayın  {accountInfo.Name} {accountInfo.Surname} Teklifiniz Kabul Edilmiştir.Ürünü Satın Alabilirsiniz.", "Teklifiniz Kabul Edilmiştir."), TimeSpan.FromSeconds(2));

            return response;
        }

        [HttpGet("RejectOffer")]
        public BaseResponse<OfferDto> RejectOffer(long id)
        {
            var offer = offerService.GetById(id);
            offer.Response.IsAccept = false;
            var response = offerService.Update(id, offer.Response);
            var accountInfo = accountService.GetById(response.Response.Customer).Response;
            BackgroundJob.Schedule(() => JobDelayed.Run("ilkay.ksc2@gmail.com", $"sayın  {accountInfo.Name} {accountInfo.Surname} Teklifiniz Ürün Sahibi Tarafından Reddedilmiştir.", "Teklifiniz Reddildi."), TimeSpan.FromSeconds(2));

            return response;
        }
    }
}

