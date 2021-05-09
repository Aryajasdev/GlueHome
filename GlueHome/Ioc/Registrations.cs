using GlueHome.Data.Context;
using GlueHome.Domain.DeliveryServices;
using GlueHome.Domain.UserServices;
using GlueHome.Model.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GlueHome.Ioc
{
    [ExcludeFromCodeCoverage]
    public static class Registrations
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DeliveryContext>(opt =>             
                opt.UseInMemoryDatabase(databaseName: "DeliveryDatabase").EnableSensitiveDataLogging());

            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IUserService, UserService>();

            var appSettingSection = configuration.GetSection("AppSettings");

            services.Configure<AppSettings>(appSettingSection);

            //JWT Authentication
            var appSettings = appSettingSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Key);

            services.AddAuthentication(au =>
            {
                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        }
    }
}
