using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using PatikaPaycoreBootcampFinalProject.Services;
using PatikaPaycoreBootcampFinalProject.Mapper;
using System;
using PatikaPaycoreBootcampFinalProject.Dto;
using PatikaPaycoreBootcampFinalProject.Model;


namespace PatikaPaycoreBootcampFinalProject.StartUpExtension
{
    
    public static class ExtensionService
    {

        public static void AddServices(this IServiceCollection services)
        {   
            // services 
            services.AddScoped<IAccountService,AccountService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IBuyService, BuyService>();
            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
            
        }
    }
}
