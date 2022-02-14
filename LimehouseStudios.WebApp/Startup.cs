using FluentValidation;
using LimehouseStudios.Application.Behaviours;
using LimehouseStudios.JsonPlaceholder.Api.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace LimehouseStudios.WebApp
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
            services.AddControllersWithViews();

            services.AddHttpClient();

            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(Application.AssemblyHook));

            services.AddMediatR(typeof(Application.AssemblyHook));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehaviour<,>));

            services.AddValidatorsFromAssembly(typeof(Application.AssemblyHook).Assembly);

            services.Configure<JsonPlaceholder.Api.Configuration.ApiConfiguration>(Configuration.GetSection("JsonPlaceholderApiConfiguration"));
            services.AddScoped(serviceProvider =>
                serviceProvider.GetRequiredService<IOptionsSnapshot<JsonPlaceholder.Api.Configuration.ApiConfiguration>>().Value);

            services.AddScoped<IUserSearchService, UserSearchService>();
            services.AddScoped<IPostSearchService, PostSearchService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
