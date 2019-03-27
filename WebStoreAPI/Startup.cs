using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using Swashbuckle.AspNetCore.Swagger;
using WebStoreAPI.Commands;
using WebStoreAPI.Commands.Products;
using WebStoreAPI.Commands.Users;
using WebStoreAPI.Models;
using WebStoreAPI.Queries;
using WebStoreAPI.Queries.Products;
using WebStoreAPI.Queries.Users;

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
            services.AddDbContext<WebStoreContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();

            IntegrateSimpleInjector(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Web Store request", Version = "v1"});
            });
        }

        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(_container));

            _container.Register<ICommandHandler<DeleteProductCommand>, DeleteProductHandler>();
            _container.Register<ICommandHandler<PostProductCommand>, PostProductHandler>();
            _container.Register<ICommandHandler<PutProductCommand>, PutProductHandler>();

            _container.Register<ICommandHandler<DeleteUserCommand>, DeleteUserHandler>();
            _container.Register<ICommandHandler<PostUserCommand>, PostUserHandler>();
            _container.Register<ICommandHandler<PutUserCommand>, PutUserHandler>();

            _container.Register<IQueryHandler<GetAllProductsCommand, IEnumerable<Product>>, GetAllProductsHandler>();
            _container.Register<IQueryHandler<GetGroupProductsCommand, IEnumerable<Product>>, GetGroupProductsHandler>();
            _container.Register<IQueryHandler<GetSingleProductCommand, Product>, GetSingleProductHandler>();

            _container.Register<IQueryHandler<GetAllUsersCommand, IEnumerable<User>>, GetAllUsersHandler>();
            _container.Register<IQueryHandler<GetGroupUsersCommand, IEnumerable<User>>, GetGroupUsersHandler>();
            _container.Register<IQueryHandler<GetSingleUserCommand, User>, GetSingleUserHandler>();

            services.EnableSimpleInjectorCrossWiring(_container);
            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeContainer(app);
            _container.Verify();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Store");
            });
        }

        //Initialization DI container
        private void InitializeContainer(IApplicationBuilder app)
        {
            _container.RegisterMvcControllers(app);
            _container.AutoCrossWireAspNetComponents(app);
        }
    }
}
