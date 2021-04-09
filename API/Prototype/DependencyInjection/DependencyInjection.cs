using Microsoft.Extensions.DependencyInjection;
using Prototype.Application.Interfaces;
using Prototype.Application.Services;
using Prototype.Domain.Handlers;
using Prototype.Domain.Interfaces.IUnitOfWork;
using Prototype.Infra.Data;
using Prototype.Infra.Data.Interfaces;
using Prototype.Infra.Data.UnitOfWork;
using Prototype.Shared.Auth;

namespace Prototype.Api.DependencyInjection
{
    public static class DependencyInjection
    {
 
        public static void ResoluteDependencies(IServiceCollection services)
        {
            ServicesDependencies(services);
            HandlresDependecies(services);                 
        }

        static void ServicesDependencies(IServiceCollection services)
        {
            services.AddScoped<IPromocaoService, PromocaoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICarrinhoService, CarrinhoService>();
            services.AddScoped<IUnitOfWork, UnitOfWork<PrototypeDataContext>>();
            services.AddScoped<IUser, UserNet>();
        }

        static void HandlresDependecies(IServiceCollection services)
        {
            services.AddScoped<PromocaoHandler, PromocaoHandler>();
            services.AddScoped<ProdutoHandler, ProdutoHandler>();
            services.AddScoped<CarrinhoHandler, CarrinhoHandler>();
        }
    }



}
