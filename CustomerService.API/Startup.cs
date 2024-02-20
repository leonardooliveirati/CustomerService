using AutoMapper;
using CustomerService.API.Models;
using CustomerService.Domain.Dto;
using CustomerService.Domain.Entities;
using CustomerService.Domain.Interfaces;
using CustomerService.Infra.Data;
using CustomerService.Infra.Data.Repository;
using CustomerService.Service.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CustomerService.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Credit Approval API v1");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {         
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Credit Approval API", Version = "v1" });
            });

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IBaseRepository<ClientEntity>, BaseRepository<ClientEntity>>();
            services.AddScoped<IBaseService<ClientEntity>, BaseService<ClientEntity>>();      


            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<CreateClientModel, ClientEntity>();
                config.CreateMap<UpdateClientModel, ClientEntity>();
                config.CreateMap<ClientEntity, ClientModel>();
            }).CreateMapper());
        }
    }
}
