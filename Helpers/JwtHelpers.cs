﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Primer_proyecto.Models.DataModels;

namespace Primer_proyecto.Helpers;
public static class JwtHelpers
{
    public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid id)
    {
        List<Claim> claims = new List<Claim>{
            new Claim("Id", userAccounts.Id.ToString()),
            new Claim(ClaimTypes.Name,userAccounts.UserName),
            new Claim(ClaimTypes.Email,userAccounts.EmailId),
            new Claim(ClaimTypes.NameIdentifier,id.ToString()),
            new Claim(ClaimTypes.Expiration,DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt")),
        };
        if (userAccounts.UserName == "Admin")
        {
            claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
        }
        else
        {
            claims.Add(new Claim(ClaimTypes.Role, "User"));
            claims.Add(new Claim("UserOnly", "User1"));
        }
        return claims;

    }

    public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid id)
    {
        id = Guid.NewGuid();
        return GetClaims(userAccounts, id);

    }

    public static UserTokens GetTokenKey(UserTokens model, JwtSettings jwtSettings)
    {
        try
        {
            var userToken = new UserTokens();
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            // Obtener clave secreta
            var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);

            Guid Id;
            // Expira en 1 dia
            DateTime expireTime = DateTime.UtcNow.AddDays(1);
            // Validacion  nuestro token
            userToken.Validity = expireTime.TimeOfDay;
            // Generar la clave secreta
            var jwbToken = new JwtSecurityToken(
                issuer: jwtSettings.ValidIssuer,
                audience: jwtSettings.ValidAudience,
                claims: GetClaims(model, out Id),
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(expireTime).DateTime,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256
                )
            );
            userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwbToken);
            userToken.UserName = model.UserName;
            userToken.Id = model.Id;
            userToken.GuidId = Id;

            return userToken;

        }
        catch (Exception ex)
        {
            throw new Exception("Error Generting the JWT", ex);
        }
    }

}
