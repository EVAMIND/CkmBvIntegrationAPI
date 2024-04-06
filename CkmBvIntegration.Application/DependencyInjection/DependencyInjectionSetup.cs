using CkmBvIntegration.Application.Applications.Authentication;
using CkmBvIntegration.Application.Interfaces.Authentication;
using CkmBvIntegration.Application.Interfaces.PDECOffer;
using CkmBvIntegration.Application.Interfaces.ProposalStatus;
using CkmBvIntegration.Domain.Exceptions.Models;
using CkmBvIntegration.Domain.Models.HttpClientSettings;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces._Base;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Authentication;
using CkmBvIntegration.Infraestructure.BvNet.Interfaces.Proposal;
using CkmBvIntegration.Infraestructure.BvNet.Repositories._Base;
using CkmBvIntegration.Infraestructure.BvNet.Repositories.Authentication;
using CkmBvIntegration.Infraestructure.BvNet.Repositories.ProposalRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CkmBvIntegration.Application.DependencyInjection
{
    public static class DependencyInjectionSetup
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureApplications(services);
            ConfigureRepositories(services);
            AddConfiguredHttpClient(services, configuration);
            ConfigureMessagesAndExceptions(services, configuration);
        }

        public static void ConfigureApplications(IServiceCollection services) {
            services.AddScoped<IAuthenticationApplication, AuthenticationApplication>();
            services.AddScoped<IProposalApplication, ProposalApplication>();
            services.AddScoped<IProposalStatusApplication, ProposalStatusApplication>();
            services.AddScoped<IPDECOfferApplication, PDECOfferApplication>();
        }

        public static void ConfigureRepositories(IServiceCollection services) {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));   
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IProposalRepository, ProposalRepository>();
            services.AddScoped<IProposalStatusRepository, ProposalStatusRepository>();
            services.AddScoped<IPDECOfferRepository, PDECOfferRepository>();
        }

        public static void ConfigureMessagesAndExceptions(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthenticationExceptions>(configuration.GetSection("ExceptionMessages"));
            services.Configure<ProposalExceptions>(configuration.GetSection("ProposalMessages"));
            services.Configure<ProposalStatusExceptions>(configuration.GetSection("ProposalStatusMessages"));
            services.Configure<PDECOfferExceptions>(configuration.GetSection("PDECOfferMessages"));
        }

        
        public static IServiceCollection AddConfiguredHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            var httpClientSettings = configuration.GetSection("HttpClientSettings").Get<HttpClientConfiguration>()?? new HttpClientConfiguration();

            services.AddHttpClient("BvTokenAPI", client =>
            {
                client.BaseAddress = new Uri(httpClientSettings.BaseTokenUrl);
                // Configurações adicionais, se necessário
            }); 
            
            services.AddHttpClient("BvProposalAPI", client =>
            {
                client.BaseAddress = new Uri(httpClientSettings.BaseProposalURL);
                // Configurações adicionais, se necessário
            }); 
            
            services.AddHttpClient("BvPDECOfferAPI", client =>
            {
                client.BaseAddress = new Uri(httpClientSettings.BasePDECOfferURL);
                // Configurações adicionais, se necessário
            }); 
            
            services.AddHttpClient("BvStatusAPI", client =>
            {
                client.BaseAddress = new Uri(httpClientSettings.BaseStatusURL);
                // Configurações adicionais, se necessário
            });

            return services;
        }
    }
}
