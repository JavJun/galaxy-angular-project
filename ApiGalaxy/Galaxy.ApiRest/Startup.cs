using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Galaxy.ApiRest.Configs;
using Galaxy.ApiRest.Contexto;
using Galaxy.ApiRest.Helper;
using Galaxy.ApiRest.Manager;
using Galaxy.ApiRest.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Galaxy.ApiRest
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
            //string pruebas = "Demo";
            //pruebas.ContadorCaracteres();
            services.AddDbContext<VentasContext>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetSection("ConnectionStrings")["BdSql"]);
                    //options.UseMySQL(Configuration.GetSection("ConnectionStrings")["BdMysql"]);
                }

                );


            services.InyectaDependencias();

            services.Configure<ConnectionStringsConfig>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<DatosAWSConfig>(Configuration.GetSection("DatosAWS"));
            services.Configure<JwtParameterConfig>(Configuration.GetSection("JwtParameter"));

            //Generar la semilla
            string semilla = "Miguel123abc098673";
            byte[] semillaByte = Encoding.UTF8.GetBytes(semilla);
            SymmetricSecurityKey key = new SymmetricSecurityKey(semillaByte);


            services.AddAuthentication
                (JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidIssuer = "demo.com",
                        ValidAudience = "demo.com",
                        ValidateLifetime = true,
                        IssuerSigningKey = key,
                        ValidateAudience = true,
                        ValidateIssuer = true
                    };
                });

            services.AddCors(options =>
            {

                options.AddPolicy("PublicApi", builder =>
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

                options.AddPolicy("Internas", b =>
                {
                    b.WithOrigins("http://localhost:4200").WithMethods(new string[] { "Get", "Post" }).AllowAnyHeader();
                });

            });

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.GestionExcepciones(logger);
            }


            app.UseRouting();

            app.UseCors("PublicApi");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
