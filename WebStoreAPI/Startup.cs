using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using WebStoreAPI.Commands;
using WebStoreAPI.Models;
using WebStoreAPI.Queries;

namespace WebStoreAPI
{
    public class Startup
    {
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

            //Commamd service for Product and User
            services.AddTransient<ICommandService<Product>, CommandServiceProduct>();
            services.AddTransient<ICommandService<User>, CommandServiceUser>();

            //Querie service for Product and User
            services.AddTransient<IQueriesService<Product>, QueriesServiceProduct>();
            services.AddTransient<IQueriesService<User>, QueriesServiceUser>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Web Store request", Version = "v1"});
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
    }
}
