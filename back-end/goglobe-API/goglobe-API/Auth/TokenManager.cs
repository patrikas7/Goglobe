﻿using goglobe_API.Data.Entities;
using goglobe_API.Auth.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace goglobe_API.Auth
{
    public interface ITokenManager
    {
        Task<string> CreateAccessTokenAsync(User user);
    }
    public class TokenManager: ITokenManager
    {
        private readonly SymmetricSecurityKey _authSigningKey;
        private readonly UserManager<User> _userManager;
        private readonly string _issuer;
        private readonly string _audience;
        public TokenManager(IConfiguration configuration, UserManager<User> userManager)
        {
            _authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            _userManager = userManager;
            _issuer = configuration["JWT:ValidIssuer"];
            _audience = configuration["JWT:ValidAudience"];
        }

        public async Task<string> CreateAccessTokenAsync(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(CustomClaims.UserId, user.Id.ToString())
            };

            authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));
            var accessSecurityToken = new JwtSecurityToken
            (
                issuer: _issuer,
                audience: _audience,
                expires: DateTime.UtcNow.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(_authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(accessSecurityToken);
        }
    }
}
