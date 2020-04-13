using Covid19.Application.Common.Interfaces;
using Covid19.Infrastructure.Files;
using Covid19.Infrastructure.Identity;
using Covid19.Infrastructure.Persistence;
using Covid19.Infrastructure.Services;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Security.Claims;

namespace Covid19.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            //services.AddDefaultIdentity<ApplicationUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            if (environment.IsEnvironment("Test"))
            {
                //services.AddIdentityServer()
                //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
                //    {
                //        options.Clients.Add(new Client
                //        {
                //            ClientId = "Covid19.IntegrationTests",
                //            AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
                //            ClientSecrets = { new Secret("secret".Sha256()) },
                //            AllowedScopes = { "Covid19.WebUIAPI", "openid", "profile" }
                //        });
                //    }).AddTestUsers(new List<TestUser>
                //    {
                //        new TestUser
                //        {
                //            SubjectId = "f26da293-02fb-4c90-be75-e4aa51e0bb17",
                //            Username = "jason@clean-architecture",
                //            Password = "Covid19!",
                //            Claims = new List<Claim>
                //            {
                //                new Claim(JwtClaimTypes.Email, "jason@clean-architecture")
                //            }
                //        }
                //    });
            }
            else
            {
                //services.AddIdentityServer()
                //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

                services.AddTransient<IDateTime, DateTimeService>();
                //services.AddTransient<IIdentityService, IdentityService>();
                services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
            }

            //services.AddAuthentication()
            //    .AddIdentityServerJwt();

            return services;
        }
    }
}
