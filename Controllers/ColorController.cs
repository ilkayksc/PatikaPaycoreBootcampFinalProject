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
    public class ColorController : ControllerBase
    {
        private readonly ISession session;
        private readonly IColorService _color;

        public ColorController(ISession session, IColorService _color)
        {

            this._color = _color;
            this.session = session;

        }

        [HttpGet]
        public BaseResponse<IEnumerable<ColorDto>> Get()
        {
            var color = _color.GetAll();
            return color;
        }


        [HttpGet("GetColorById")]
        public BaseResponse<ColorDto> GetColorById([FromQuery] long id)
        {
            var color = _color.GetById(id);
            return color;
        }

        [HttpPost]
        public BaseResponse<ColorDto> CreateColor([FromBody] ColorDto request)
        {
            var response = _color.Insert(request);
            return response;
        }

        [HttpPut("/UpdateColor/{id}")]
        public BaseResponse<ColorDto> UpdateColor(long id, [FromBody] ColorDto request)
        {
            var result = _color.Update(id, request);
            return result;
        }
        [HttpDelete("/DeleteColor/{id}")]
        public ActionResult DeleteColor(long id)
        {

            _color.Remove(id);

            return Ok();
        }
    }
}

