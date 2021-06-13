using Galaxy.ApiRest.Configs;
using Galaxy.ApiRest.Manager;
using Galaxy.ApiRest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.ApiRest.Helper
{

    //public class Demo {

    //    public static string Saludo { get; set; }
    //}

    public static class Extensiones
    {

        /// <summary>
        /// Estes es mi contador de catacteres especial
        /// </summary>
        /// <param name="cadena">El valor a evaluar :)</param>
        /// <returns></returns>
        public static int ContadorCaracteres(this string cadena)
        {
            int cant = cadena.Length;
            return cant;
        }


        public static void InyectaDependencias(this IServiceCollection services)
        {


            services.AddTransient<ISeguridadManager, SeguridadManager>();
            services.AddTransient<IUsuarioService, UsuarioServiceMemoria>();

            services.AddTransient<ISeguridadService, SeguridadService>();

        }

        public static void GestionExcepciones(this IApplicationBuilder app, ILogger<Startup> logger)
        {


            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Sucedio un errror inesperado: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }

        public class ErrorDetails
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
    }
}
