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

    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ISession session;
        private readonly IBrandService _brand;

        public BrandController(ISession session, IBrandService _brand)
        {

            this._brand = _brand;
            this.session = session;

        }

        [HttpGet]
        public BaseResponse<IEnumerable<BrandDto>> Get()
        {
            var result = _brand.GetAll();
            return result;
        }


        [HttpGet("GetBrandById")]
        public BaseResponse<BrandDto> GetBrandById([FromQuery] long id)
        {
            var result = _brand.GetById(id);
            return result;
        }

        [HttpPost]
        public BaseResponse<BrandDto> CreateBrand([FromBody] BrandDto request)
        {
            var result = _brand.Insert(request);
            return result;
        }

        [HttpPut("/UpdateBrand/{id}")]
        public BaseResponse<BrandDto> UpdateBrand(long id, [FromBody] BrandDto request)
        {
            var result = _brand.Update(id, request);
            return result;
        }
        [HttpDelete("/DeleteBrand/{id}")]
        public ActionResult DeleteBrand(long id)
        {

            _brand.Remove(id);

            return Ok();
        }
    }
}

