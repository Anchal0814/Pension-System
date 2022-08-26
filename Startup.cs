using APIPension.Models;
using APIPension.Repositories;
using APIPension.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace APIPension
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
            services.AddCors(options =>
            { 
            options.AddPolicy(name: "AllowOrigin", builder =>
             {
                 builder.WithOrigins("https://localhost:44364").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                 builder.WithOrigins("https://localhost:4200").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

             });
            });

            services.AddDbContext<PensionerContext>(x => x.UseSqlServer(Configuration.GetConnectionString("ConStr")));
            //services.AddDbContext<PensionerContext>(options => options.UseSqlServer("Server=tcp:test-pensionerdb.database.windows.net,1433;Initial Catalog=PensionerPortalDb;Persist Security Info=False;User ID=hiadmin;Password=@qwerty1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; "));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwtConfig:key"])),
                    ClockSkew = TimeSpan.Zero

                };
            });
            services.AddControllersWithViews();
            services.AddScoped<ICalculatePension, CalculatePensionService>();
            services.AddTransient<ILogin, LoginService>();
            services.AddTransient<IPensionerDetail, PensionerDetailService>();
            services.AddTransient<IPensionerCsvToList, PensionerCSVFileService>();
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
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();


            
            app.UseCors("AllowOrigin");
            app.UseAuthentication();
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
