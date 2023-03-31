using API.Services;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using System.Text;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {
            //services.AddIdentity<AppUser, IdentityRole>(opt =>
            //{
            //    opt.Password.RequireNonAlphanumeric = false;
            //})
            //   .AddEntityFrameworkStores<AppDbContext>();

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //   .AddJwtBearer(opt =>
            //   {
            //       opt.TokenValidationParameters = new TokenValidationParameters
            //       {
            //           ValidateIssuerSigningKey = true,
            //           IssuerSigningKey = key,
            //           ValidateIssuer = false,
            //           ValidateAudience = false,

            //       };
            //   });

            services.AddIdentity<AppUser, IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>()
               .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                // Adding Jwt Bearer  
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = config["JWT:ValidAudience"],
                        ValidIssuer = config["JWT:ValidIssuer"],
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"])),
                        ValidateIssuerSigningKey = true,
                    };
                });

            services.AddScoped<TokenService>();

            return services;
        }
    }
}
