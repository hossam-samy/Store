using Application.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repos;
using Infrastructure.Services.Authentication;
using Infrastructure.Services.Media;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddPersistence(configuration);

            return services;
        }
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(o => o.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("constr")));
            services.AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<AppDBContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
            services.AddScoped<IMediaServicecs, MediaService>();

            return services;
        }

    }
}
