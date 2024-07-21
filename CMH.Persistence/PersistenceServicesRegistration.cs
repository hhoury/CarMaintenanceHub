using CMH.Application.Contracts.Identity;
using CMH.Application.Contracts.Persistence;
using CMH.Domain.Entities;
using CMH.Persistence.DatabaseContext;
using CMH.Persistence.Repositories;
using CMH.Persistence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CMH.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CMHDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CMHConnectionString"));
            });
            services.AddIdentity<User, IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<User>>("CMH.API")
               .AddEntityFrameworkStores<CMHDbContext>().AddDefaultTokenProviders();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICarRepository,CarRepository >();
            services.AddScoped<IMaintenanceGarageRepository,MaintenanceGarageRepository >();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))

                };
            });
            return services;

        }
    }
}
