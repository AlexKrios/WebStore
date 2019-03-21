using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using Swashbuckle.AspNetCore.Swagger;
using WebStoreAPI.Commands;
using WebStoreAPI.Models;
using WebStoreAPI.Queries;

namespace WebStoreAPI
{
    public class Startup
    {
        private readonly Container container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string con = "Server=SHIMCHUKEVICHA\\WEBSTORESERVER;Database=webstoredb;User Id=a.shimchukevich;Password=KPhD8D3r";
            services.AddDbContext<WebStoreContext>(options => options.UseSqlServer(con));
            services.AddMvc();

            IntegrateSimpleInjector(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Web Store request", Version = "v1"});
            });
        }

        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(container));

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeContainer(app);
            container.Verify();

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
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            //Commamd and Querie services for Product
            container.Register<ICommandService<Product>, CommandServiceProduct>();
            container.Register<IQueriesService<Product>, QueriesServiceProduct>();

            //Commamd and Querie services for User
            container.Register<ICommandService<User>, CommandServiceUser>();
            container.Register<IQueriesService<User>, QueriesServiceUser>();

            container.AutoCrossWireAspNetComponents(app);
        }
    }
}
