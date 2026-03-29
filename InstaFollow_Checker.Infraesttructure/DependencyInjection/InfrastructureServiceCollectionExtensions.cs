using Microsoft.Extensions.DependencyInjection;
using InstaFollow_Checker.Application.Interfaces;
using InstaFollow_Checker.Infraesttructure.Services;
using InstaFollow_Checker.Infraesttructure.Parsers;

namespace InstaFollow_Checker.Infraesttructure.DependencyInjection
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IFileReader, FileReaderService>();
            services.AddScoped<IGetFollowers, FollowersParserService>();
            services.AddScoped<IGetFollowing, FollowingParserService>();

            return services;
        }
    }
}
