using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Primer_proyecto.Models.DataModels;

namespace Primer_proyecto;
public static class AddJwtTokenServicesExtensions
{
    public static void AddJwtTokenServices(this IServiceCollection services, IConfiguration configuration)
    {
        //add los setting de nuestro jwtsettings
        var bindJwtSetting = new JwtSettings();
        configuration.Bind("JsonWebTokenKeys", bindJwtSetting);

        // add un Singleton de el JwtSettings
        services.AddSingleton(bindJwtSetting);

        //add autienticacion
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = bindJwtSetting.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSetting.IssuerSigningKey)),
                ValidIssuer = bindJwtSetting.ValidIssuer,
                ValidateAudience = bindJwtSetting.ValidateAudience,
                ValidAudience = bindJwtSetting.ValidAudience,
                RequireExpirationTime = bindJwtSetting.RequiereExpirationTime,
                ClockSkew = TimeSpan.FromDays(1)
            };
        });
    }
}
