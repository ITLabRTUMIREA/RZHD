﻿using Microsoft.Extensions.Options;
using RZHD.Models.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RZHD.Services.Authorize
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtOptions options;

        public JwtFactory(IOptions<JwtOptions> options)
        {
            this.options = options.Value;
        }

        public string GenerateAccessToken(int userId)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow + options.LifeTime).ToString(), ClaimValueTypes.Integer64)
            };

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                issuer: options.Issuer,
                audience: options.Audience,
                claims: claims,
                expires: DateTime.UtcNow + options.LifeTime,
                signingCredentials: options.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() -
                               new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                              .TotalSeconds);
    }
}
