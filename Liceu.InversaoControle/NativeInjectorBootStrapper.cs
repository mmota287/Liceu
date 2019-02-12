using Liceu.Dados.Contexto;
using Liceu.Dados.Repositorios;
using Liceu.Dominio.Compartilhado;
using Liceu.Dominio.Servicos;
using Liceu.Dominio.Servicos.Usuarios;
using Liceu.Seguranca.Autorizacao;
using Liceu.Seguranca.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Liceu.InversaoControle
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LiceuDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Liceu.WebApp")));

     
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();


            // Infra - Data
            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));


            services.AddScoped<ILivroServico, LivroServico>();

            // Infra - Identity
            services.AddScoped<IUsuarioServico, UsuarioServico>();
        }
    }
}
