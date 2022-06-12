using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PerfumeShop.Api.Controllers;
using PerfumeShop.Api.Core;
using PerfumeShop.Api.Extensions;
using PerfumeShop.Application.Emails;
using PerfumeShop.Application.Logging;
using PerfumeShop.Application.UseCases.Commands;
using PerfumeShop.Application.UseCases.Queries;
using PerfumeShop.DataAccess;
using PerfumeShop.Implementation;
using PerfumeShop.Implementation.Emails;
using PerfumeShop.Implementation.Logging;
using PerfumeShop.Implementation.UseCases.Commands.Brands;
using PerfumeShop.Implementation.UseCases.Commands.Categories;
using PerfumeShop.Implementation.UseCases.Commands.Orders;
using PerfumeShop.Implementation.UseCases.Commands.Prices;
using PerfumeShop.Implementation.UseCases.Commands.Products;
using PerfumeShop.Implementation.UseCases.Commands.Users;
using PerfumeShop.Implementation.UseCases.Commands.Volumes;
using PerfumeShop.Implementation.UseCases.Queries;
using PerfumeShop.Implementation.UseCases.Queries.Brands;
using PerfumeShop.Implementation.UseCases.Queries.Categories;
using PerfumeShop.Implementation.UseCases.Queries.Orders;
using PerfumeShop.Implementation.UseCases.Queries.Products;
using PerfumeShop.Implementation.UseCases.Queries.Users;
using PerfumeShop.Implementation.UseCases.Queries.Volumes;
using PerfumeShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PerfumeShop.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var settings = new AppSettings();

            Configuration.Bind(settings);
            services.AddSingleton(settings);
            services.AddApplicationUser();
            services.AddJwt(settings);

            services.AddTransient<Context>(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                var conn = Configuration.GetSection("conn").Value;

                optionsBuilder.UseSqlServer(conn);

                var options = optionsBuilder.Options;

                return new Context(options);
            });
            
            
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<IGetCategoriesQuery, GetCategoriesQuery>();
            services.AddTransient<ICreateCategoryCommand, CreateCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, UpdateCategoryCommand>();
            services.AddTransient<ISoftDeleteCategoryCommand, SoftDeleteCategoryCommand>();
            services.AddTransient<IGetOneCategoryQuery, GetOneCategoryQuery>();
           
            services.AddTransient<CreateBrandValidator>();
            services.AddTransient<IUpdateBrandCommand, UpdateBrandCommand>();
            services.AddTransient<ICreateBrandCommand, CreateBrandCommand>();
            services.AddTransient<ISoftDeleteBrandCommand, SoftDeleteBrandCommand>();
            services.AddTransient<IGetBrandsQuery, GetBrandsQuery>();
            services.AddTransient<IGetOneBrandQuery, GetOneBrandQuery>();

            services.AddTransient<CreateOrderValidator>();
            services.AddTransient<ISoftDeleteOrderCommand, SoftDeleteOrderCommand>();
            services.AddTransient<IGetOrdersQuery, GetOrdersQuery>();
            services.AddTransient<ICreateOrderCommand, CreateOrderCommand>();
            services.AddTransient<IGetOneOrderQuery, GetOneOrderQuery>();

            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<ISoftDeleteUserCommand, SoftDeleteUserCommand>();
            services.AddTransient<IGetUsersQuery, GetUsersQuery>();
            services.AddTransient<IGetOneUserQuery, GetOneUsersQuery>();
            services.AddTransient<IRegisterUserCommand, RegisterUserCommand>();

            services.AddTransient<CreateVolumeValidator>();
            services.AddTransient<ICreateVolumeCommand, CreateVolumeCommand>();
            services.AddTransient<ISoftDeleteVolumeCommand, SoftDeleteVolumeCommand>();
            services.AddTransient<IGetVolumesQuery, GetVolumesQuery>();
            services.AddTransient<IGetOneVolumeQuery, GetOneVolumeQuery>();
            
            services.AddTransient<CreateProductValidator>();
            services.AddTransient<ICreateProductCommand, CreateProductCommand>();
            services.AddTransient<ISoftDeleteProductCommand, SoftDeleteProductCommand>();
            services.AddTransient<IGetProductsQuery, GetProductsQuery>();
            services.AddTransient<IGetOneProductQuery, GetOneProductQuery>();

            services.AddTransient<CreatePriceValidator>();
            services.AddTransient<ICreatePriceCommand, CreatePriceCommand>();
            services.AddTransient<ISoftDeletePriceCommand, SoftDeletePriceCommand>();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IEmailSender>(x =>
            new SmtpEmailSender(settings.EmailOptions.FromEmail,
                                settings.EmailOptions.Password,
                                settings.EmailOptions.Port,
                                settings.EmailOptions.Host));
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PerfumeShop.Api", Version = "v1" });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PerfumeShop.Api v1"));
            }

            app.UseRouting();
            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
