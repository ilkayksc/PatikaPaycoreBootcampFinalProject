using System;
using System.Collections;
using System.Collections.Generic;
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
    public class CategoryController : ControllerBase
    {
        private readonly ISession session;
        private readonly ICategoryService _category;

        public CategoryController(ISession session, ICategoryService _category)
        {
          
            this._category = _category;
            this.session = session;
          
        }

        [HttpGet]
        public BaseResponse<IEnumerable<CategoryDto>> Get()
        {
            var categories = _category.GetAll();
            return categories;
        }

        
        [HttpGet("GetCategoryById")]
        public BaseResponse<CategoryDto> GetCategoryById([FromQuery] long id)
        {   
            var category = _category.GetById(id);
            return category;
        }

        [HttpPost]
        public BaseResponse<CategoryDto> CreateCategory([FromBody] CategoryDto request)
        {
            var response = _category.Insert(request);
            return response;
        }

        [HttpPut("/UpdateCategory/{id}")]
        public BaseResponse<CategoryDto> UpdateCategory(long id, [FromBody] CategoryDto request)
        {   
            var result = _category.Update(id,request);
            return result;
        }
        [HttpDelete("/DeleteCategory/{id}")]
        public ActionResult DeleteCategory(long id)
        {
            
            _category.Remove(id);
            
            return Ok();
        }
    }
}

