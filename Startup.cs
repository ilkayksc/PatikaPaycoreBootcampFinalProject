using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatikaPaycoreBootcampFinalProject.Model;
using PatikaPaycoreBootcampFinalProject.StartUpExtension;
using System.Net;

namespace PatikaPaycoreBootcampFinalProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static JwtConfig JwtConfig { get; private set; }
       

        public void ConfigureServices(IServiceCollection services)
        {


            //hangfire 
            services.AddHangfire(configuration => configuration
               .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
               .UseSimpleAssemblyNameTypeSerializer()
               .UseRecommendedSerializerSettings()
               .UsePostgreSqlStorage(Configuration.GetConnectionString("PostgreSqlConnection"), new PostgreSqlStorageOptions
               {
                   TransactionSynchronisationTimeout = TimeSpan.FromMinutes(5),
                   InvisibilityTimeout = TimeSpan.FromMinutes(5),
                   QueuePollInterval = TimeSpan.FromMinutes(5),
               }));
            services.AddHangfireServer();
            // hibernate
            var connStr = Configuration.GetConnectionString("PostgreSqlConnection");
            services.AddNHibernatePosgreSql(connStr);
            services.AddHttpContextAccessor();

            // Configure JWT Bearer
            JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));


            // service
            services.AddServices();
            services.AddJwtBearerAuthentication();
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddCustomizeSwagger();
            services.AddSingleton<IConfiguration>(Configuration);
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
            }


            
            app.UseHttpsRedirection();


            // add auth 
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseHangfireDashboard();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
