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
using Hangfire;
using PatikaPaycoreBootcampFinalProject.HangFire;
using System.Net;
using ConfigurationManager = System.Configuration;
namespace PatikaPaycoreBootcampFinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISession session;
        private readonly IAccountService _account;
        private readonly ITokenService tokenService;

        public AccountController(ISession session,IAccountService _account,ITokenService tokenService) 
        {
            this.session = session;
            
            this._account = _account;

            this.tokenService = tokenService;
        }

        [HttpPost("/Register")]
        public BaseResponse<AccountDto> Register([FromBody] AccountDto request)
        {
            AccountDto account = _account.GetAll().Response.Where(res =>res.Email == request.Email).FirstOrDefault();

            if (account != null)
            {
                return new BaseResponse<AccountDto>(message:"Bu bilgilere ait kullanıcı mevcuttur.");
            }
            request.Password = MD5CipherExtension.MD5Encryption(request.Password);

            var result = _account.Insert(request);

            BackgroundJob.Schedule(() => JobDelayed.Run("ilkay.ksc2@gmail.com",$"sayın {result.Response.Name}  {result.Response.Surname} hoşgeldiniz.", "Hoşgeldiniz"), TimeSpan.FromSeconds(2));

            return result;
        }
        [HttpPost("/Login")]
        public BaseResponse<TokenResponse> Login([FromBody] TokenRequest user)
        {   
            user.Password = MD5CipherExtension.MD5Encryption(user.Password);
          
            var account = _account.GetAll().Response.Where(account => account.Email == user.Email && account.Password == user.Password).FirstOrDefault();
            if (account == null)
            {
                return new BaseResponse<TokenResponse>(message: "Lütfen Bilgilerinizi Kontrol Ediniz.");
            }
            else
            {
                var response = tokenService.GenerateToken(user);
                return response;
            }

        }
    }
}

