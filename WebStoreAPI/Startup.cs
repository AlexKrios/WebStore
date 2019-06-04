using AutoMapper;
using DataLibrary;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using WebStoreAPI.Mapper;

namespace WebStoreAPI
{
    public class Startup
    {
        private readonly Container _container = new Container();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            AuthConfiguration(services, Configuration);
            ValidationConfiguration(services);
            services.AddMediatR();
            MapperConfiguration(services);
            SimpleInjectorConfiguration(services);
            SwaggerConfiguration(services);
            ContextConfiguration(services, Configuration);
        }

        private void AuthConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidIssuer = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
        }

        private void ValidationConfiguration(IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<Startup>();
            });
        }

        private void MapperConfiguration(IServiceCollection services)
        {
            services.AddAutoMapper();

            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            var mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
        }

        private void SimpleInjectorConfiguration(IServiceCollection services)
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            services.EnableSimpleInjectorCrossWiring(_container);
        }

        private void SwaggerConfiguration(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Web Store request", Version = "v1" });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, "WebStoreAPI.XML");
                c.IncludeXmlComments(xmlPath);
            });
        }

        private void ContextConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WebStoreContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(
                        "DefaultConnection"),
                    b => b.MigrationsAssembly("WebStoreAPI")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, WebStoreContext context)
        {
            _container.RegisterMvcControllers(app);
            _container.AutoCrossWireAspNetComponents(app);
            _container.Verify();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("AllowAllOrigins");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Store"); });

            //Db initialization
            WebStoreInitializer.Seed(context);
        }
    }
}